using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Liuliu.Blogs.Blogs;
using Liuliu.Blogs.Blogs.Dtos;
using Liuliu.Blogs.Blogs.Entities;
using Microsoft.AspNetCore.Mvc;
using OSharp.AspNetCore.Mvc.Filters;
using OSharp.AspNetCore.UI;
using OSharp.Core.Modules;
using OSharp.Data;
using OSharp.Entity;
using OSharp.Filter;

namespace Liuliu.Blogs.Web.Areas.Admin.Controllers.Blogs
{
    [ModuleInfo(Position = "Blogs", PositionName = "博客模块")]
    [Description("管理-文章信息")]
    public class PostController : AdminApiController
    {
        /// <summary>
        /// 初始化一个<see cref="PostController"/>类型的新实例
        /// </summary>
        protected PostController(IBlogsContract blogsContract,
            IFilterService filterService)
        {
            BlogsContract = blogsContract;
            FilterService = filterService;
        }

        /// <summary>
        /// 获取或设置 数据过滤服务对象
        /// </summary>
        protected IFilterService FilterService { get; }

        /// <summary>
        /// 获取或设置 博客模块业务契约对象
        /// </summary>
        protected IBlogsContract BlogsContract { get; }

        /// <summary>
        /// 读取文章列表信息
        /// </summary>
        /// <param name="request">页请求信息</param>
        /// <returns>文章列表分页信息</returns>
        [HttpPost]
        [ModuleInfo]
        [Description("读取")]
        public virtual PageData<PostOutputDto> Read(PageRequest request)
        {
            Check.NotNull(request, nameof(request));

            Expression<Func<Post, bool>> predicate = FilterService.GetExpression<Post>(request.FilterGroup);
            var page = BlogsContract.Posts.ToPage<Post, PostOutputDto>(predicate, request.PageCondition);

            return page.ToPageData();
        }

        /// <summary>
        /// 新增文章信息
        /// </summary>
        /// <param name="dtos">文章信息输入DTO</param>
        /// <returns>JSON操作结果</returns>
        [HttpPost]
        [ModuleInfo]
        [DependOnFunction("Read")]
        [ServiceFilter(typeof(UnitOfWorkAttribute))]
        [Description("新增")]
        public virtual async Task<AjaxResult> Create(PostInputDto[] dtos)
        {
            Check.NotNull(dtos, nameof(dtos));
            OperationResult result = await BlogsContract.CreatePosts(dtos);
            return result.ToAjaxResult();
        }

        /// <summary>
        /// 更新文章信息
        /// </summary>
        /// <param name="dtos">文章信息输入DTO</param>
        /// <returns>JSON操作结果</returns>
        [HttpPost]
        [ModuleInfo]
        [DependOnFunction("Read")]
        [ServiceFilter(typeof(UnitOfWorkAttribute))]
        [Description("更新")]
        public virtual async Task<AjaxResult> Update(PostInputDto[] dtos)
        {
            Check.NotNull(dtos, nameof(dtos));
            OperationResult result = await BlogsContract.UpdatePosts(dtos);
            return result.ToAjaxResult();
        }

        /// <summary>
        /// 删除文章信息
        /// </summary>
        /// <param name="ids">文章信息编号</param>
        /// <returns>JSON操作结果</returns>
        [HttpPost]
        [ModuleInfo]
        [DependOnFunction("Read")]
        [ServiceFilter(typeof(UnitOfWorkAttribute))]
        [Description("删除")]
        public virtual async Task<AjaxResult> Delete(int[] ids)
        {
            Check.NotNull(ids, nameof(ids));
            OperationResult result = await BlogsContract.DeletePosts(ids);
            return result.ToAjaxResult();
        }
    }
}
