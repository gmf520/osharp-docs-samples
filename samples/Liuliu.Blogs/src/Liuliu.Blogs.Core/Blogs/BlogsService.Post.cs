using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Liuliu.Blogs.Blogs.Dtos;
using Liuliu.Blogs.Blogs.Entities;
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
        /// 获取 文章信息查询数据集
        /// </summary>
        public virtual IQueryable<Post> Posts => PostRepository.Query();

        /// <summary>
        /// 检查文章信息是否存在
        /// </summary>
        /// <param name="predicate">检查谓语表达式</param>
        /// <param name="id">更新的文章信息编号</param>
        /// <returns>文章信息是否存在</returns>
        public virtual Task<bool> CheckPostExists(Expression<Func<Post, bool>> predicate, int id = 0)
        {
            Check.NotNull(predicate, nameof(predicate));
            return PostRepository.CheckExistsAsync(predicate, id);
        }

        /// <summary>
        /// 添加文章信息
        /// </summary>
        /// <param name="dtos">要添加的文章信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        public virtual async Task<OperationResult> CreatePosts(params PostInputDto[] dtos)
        {
            Check.Validate<PostInputDto, int>(dtos, nameof(dtos));
            if (dtos.Length == 0)
            {
                return OperationResult.NoChanged;
            }

            // 文章是以当前用户身份来添加的
            ClaimsPrincipal principal = _serviceProvider.GetCurrentUser();
            if (principal == null || !principal.Identity.IsAuthenticated)
            {
                throw new OsharpException("用户未登录或登录已失效");
            }
            // 检查当前用户的博客状态
            int userId = principal.Identity.GetUserId<int>();
            Blog blog = BlogRepository.TrackQuery(m => m.UserId == userId).FirstOrDefault();
            if (blog == null || !blog.IsEnabled)
            {
                throw new OsharpException("当前用户的博客未开通，无法添加文章");
            }

            // 没有前置检查，checkAction为null
            return await PostRepository.InsertAsync(dtos, null, (dto, entity) =>
            {
                // 给新建的文章关联博客和作者
                entity.BlogId = blog.Id;
                entity.UserId = userId;
                return Task.FromResult(entity);
            });
        }

        /// <summary>
        /// 更新文章信息
        /// </summary>
        /// <param name="dtos">包含更新信息的文章信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        public virtual Task<OperationResult> UpdatePosts(params PostInputDto[] dtos)
        {
            Check.Validate<PostInputDto, int>(dtos, nameof(dtos));

            return PostRepository.UpdateAsync(dtos);
        }

        /// <summary>
        /// 删除文章信息
        /// </summary>
        /// <param name="ids">要删除的文章信息编号</param>
        /// <returns>业务操作结果</returns>
        public virtual Task<OperationResult> DeletePosts(params int[] ids)
        {
            Check.NotNull(ids, nameof(ids));
            return PostRepository.DeleteAsync(ids);
        }
    }
}
