using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using OSharp.AspNetCore.Mvc;
using OSharp.AspNetCore.Mvc.Filters;
using OSharp.AspNetCore.UI;
using OSharp.Caching;
using OSharp.Core.Functions;
using OSharp.Core.Modules;
using OSharp.Data;
using OSharp.Entity;
using OSharp.Filter;
using OSharp.Secutiry;

using Liuliu.Blogs.Blogs;
using Liuliu.Blogs.Blogs.Dtos;
using Liuliu.Blogs.Blogs.Entities;

namespace Liuliu.Blogs.Web.Areas.Admin.Controllers.Blogs
{
    [ModuleInfo(Position = "Blogs", PositionName = "博客模块")]
    [Description("管理-博客信息")]
    public class BlogController : AdminApiController
    {
        /// <summary>
        /// 初始化一个<see cref="BlogController"/>类型的新实例
        /// </summary>
        public BlogController(IBlogsContract blogsContract,
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
        /// 读取博客列表信息
        /// </summary>
        /// <param name="request">页请求信息</param>
        /// <returns>博客列表分页信息</returns>
        [HttpPost]
        [ModuleInfo]
        [Description("读取")]
        public PageData<BlogOutputDto> Read(PageRequest request)
        {
            Check.NotNull(request, nameof(request));

            Expression<Func<Blog, bool>> predicate = FilterService.GetExpression<Blog>(request.FilterGroup);
            var page = BlogsContract.Blogs.ToPage<Blog, BlogOutputDto>(predicate, request.PageCondition);

            return page.ToPageData();
        }

        /// <summary>
        /// 申请开通博客
        /// </summary>
        /// <param name="dto">博客输入DTO</param>
        /// <returns>JSON操作结果</returns>
        [HttpPost]
        [ModuleInfo]
        [DependOnFunction("Read")]
        [ServiceFilter(typeof(UnitOfWorkAttribute))]
        [Description("申请")]
        public async Task<AjaxResult> Apply(BlogInputDto dto)
        {
            Check.NotNull(dto, nameof(dto));
            OperationResult result = await BlogsContract.ApplyForBlog(dto);
            return result.ToAjaxResult();
        }

        /// <summary>
        /// 审核博客
        /// </summary>
        /// <param name="dto">博客输入DTO</param>
        /// <returns>JSON操作结果</returns>
        [HttpPost]
        [ModuleInfo]
        [DependOnFunction("Read")]
        [ServiceFilter(typeof(UnitOfWorkAttribute))]
        [Description("审核")]
        public async Task<AjaxResult> Verify(BlogVerifyDto dto)
        {
            Check.NotNull(dto, nameof(dto));
            OperationResult result = await BlogsContract.VerifyBlog(dto);
            return result.ToAjaxResult();
        }

        /// <summary>
        /// 更新博客信息
        /// </summary>
        /// <param name="dtos">博客信息输入DTO</param>
        /// <returns>JSON操作结果</returns>
        [HttpPost]
        [ModuleInfo]
        [DependOnFunction("Read")]
        [ServiceFilter(typeof(UnitOfWorkAttribute))]
        [Description("更新")]
        public async Task<AjaxResult> Update(BlogInputDto[] dtos)
        {
            Check.NotNull(dtos, nameof(dtos));
            OperationResult result = await BlogsContract.UpdateBlogs(dtos);
            return result.ToAjaxResult();
        }
    }
}
