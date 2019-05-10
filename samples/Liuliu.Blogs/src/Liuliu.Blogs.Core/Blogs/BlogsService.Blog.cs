using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Liuliu.Blogs.Blogs.Dtos;
using Liuliu.Blogs.Blogs.Entities;
using Liuliu.Blogs.Blogs.Events;
using Liuliu.Blogs.Identity.Entities;
using OSharp.Data;
using OSharp.Dependency;
using OSharp.Exceptions;
using OSharp.Mapping;
using OSharp.Secutiry.Claims;

namespace Liuliu.Blogs.Blogs
{
    public partial class BlogsService
    {
        /// <summary>
        /// 获取 博客信息查询数据集
        /// </summary>
        public virtual IQueryable<Blog> Blogs => BlogRepository.Query();

        /// <summary>
        /// 检查博客信息是否存在
        /// </summary>
        /// <param name="predicate">检查谓语表达式</param>
        /// <param name="id">更新的博客信息编号</param>
        /// <returns>博客信息是否存在</returns>
        public virtual Task<bool> CheckBlogExists(Expression<Func<Blog, bool>> predicate, int id = 0)
        {
            Check.NotNull(predicate, nameof(predicate));
            return BlogRepository.CheckExistsAsync(predicate, id);
        }

        /// <summary>
        /// 申请博客信息
        /// </summary>
        /// <param name="dto">申请博客信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        public virtual async Task<OperationResult> ApplyForBlog(BlogInputDto dto)
        {
            Check.Validate(dto, nameof(dto));

            // 博客是以当前用户的身份来申请的
            ClaimsPrincipal principal = _serviceProvider.GetCurrentUser();
            if (principal == null || !principal.Identity.IsAuthenticated)
            {
                return new OperationResult(OperationResultType.Error, "用户未登录或登录已失效");
            }

            int userId = principal.Identity.GetUserId<int>();
            User user = await UserRepository.GetAsync(userId);
            if (user == null)
            {
                return new OperationResult(OperationResultType.QueryNull, $"编号为“{userId}”的用户信息不存在");
            }
            Blog blog = BlogRepository.TrackQuery(m => m.UserId == userId).FirstOrDefault();
            if (blog != null)
            {
                return new OperationResult(OperationResultType.Error, "当前用户已开通博客，不能重复申请");
            }

            if (await CheckBlogExists(m => m.Url == dto.Url))
            {
                return new OperationResult(OperationResultType.Error, $"Url 为“{dto.Url}”的博客已存在，不能重复添加");
            }
            blog = dto.MapTo<Blog>();
            blog.UserId = userId;
            int count = await BlogRepository.InsertAsync(blog);
            return count > 0
                ? new OperationResult(OperationResultType.Success, "博客申请成功")
                : OperationResult.NoChanged;
        }

        /// <summary>
        /// 审核博客信息
        /// </summary>
        /// <param name="id">博客编号</param>
        /// <param name="isEnabled">是否通过</param>
        /// <returns>业务操作结果</returns>
        public virtual async Task<OperationResult> VerifyBlog(int id, bool isEnabled)
        {
            Blog blog = await BlogRepository.GetAsync(id);
            if (blog == null)
            {
                return new OperationResult(OperationResultType.QueryNull, $"编号为“{id}”的博客信息不存在");
            }

            // 更新博客
            blog.IsEnabled = isEnabled;
            int count = await BlogRepository.UpdateAsync(blog);

            User user = await UserRepository.GetAsync(blog.UserId);
            if (user == null)
            {
                return new OperationResult(OperationResultType.QueryNull, $"编号为“{blog.UserId}”的用户信息不存在");
            }

            // 如果开通博客，给用户开通博主身份
            if (isEnabled)
            {
                // 查找博客主的角色，博主角色名可由配置系统获得
                const string roleName = "博主";
                // 用于CUD操作的实体，要用 TrackQuery 方法来查询出需要的数据，不能用 Query，因为 Query 会使用 AsNoTracking
                Role role = RoleRepository.TrackQuery(m => m.Name == roleName).FirstOrDefault();
                if (role == null)
                {
                    return new OperationResult(OperationResultType.QueryNull, $"名称为“{roleName}”的角色信息不存在");
                }

                UserRole userRole = UserRoleRepository.TrackQuery(m => m.UserId == user.Id && m.RoleId == role.Id)
                    .FirstOrDefault();
                if (userRole == null)
                {
                    userRole = new UserRole() { UserId = user.Id, RoleId = role.Id, IsLocked = false };
                    count += await UserRoleRepository.InsertAsync(userRole);
                }
            }

            OperationResult result = count > 0
                ? new OperationResult(OperationResultType.Success, $"博客“{blog.Display}”审核 {(isEnabled ? "通过" : "未通过")}")
                : OperationResult.NoChanged;
            if (result.Succeeded)
            {
                VerifyBlogEventData eventData = new VerifyBlogEventData()
                {
                    BlogName = blog.Display,
                    UserName = user.NickName,
                    IsEnabled = isEnabled
                };
                EventBus.Publish(eventData);
            }

            return result;
        }

        /// <summary>
        /// 更新博客信息
        /// </summary>
        /// <param name="dtos">包含更新信息的博客信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        public virtual Task<OperationResult> UpdateBlogs(params BlogInputDto[] dtos)
        {
            return BlogRepository.UpdateAsync(dtos, async (dto, entity) =>
            {
                if (await BlogRepository.CheckExistsAsync(m => m.Url == dto.Url, dto.Id))
                {
                    throw new OsharpException($"Url为“{dto.Url}”的博客已存在，不能重复");
                }
            });
        }

        /// <summary>
        /// 删除博客信息
        /// </summary>
        /// <param name="ids">要删除的博客信息编号</param>
        /// <returns>业务操作结果</returns>
        public virtual Task<OperationResult> DeleteBlogs(params int[] ids)
        {
            return BlogRepository.DeleteAsync(ids, entity =>
            {
                if (PostRepository.Query(m => m.BlogId == entity.Id).Any())
                {
                    throw new OsharpException($"博客“{entity.Display}”中还有文章未删除，请先删除所有文章，再删除博客");
                }
                return Task.FromResult(0);
            });
        }
    }
}
