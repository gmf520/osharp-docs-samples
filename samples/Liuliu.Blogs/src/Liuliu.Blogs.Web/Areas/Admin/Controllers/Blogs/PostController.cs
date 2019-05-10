using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Liuliu.Blogs.Blogs;
using Liuliu.Blogs.Blogs.Dtos;
using Microsoft.AspNetCore.Mvc;
using OSharp.AspNetCore.Mvc.Filters;
using OSharp.AspNetCore.UI;
using OSharp.Data;

namespace Liuliu.Blogs.Web.Areas.Admin.Controllers.Blogs
{
    [Description("管理-文章信息")]
    public class PostController : AdminApiController
    {
        private readonly IBlogsContract _blogsContract;

        /// <summary>
        /// 初始化一个<see cref="PostController"/>类型的新实例
        /// </summary>
        public PostController(IBlogsContract blogsContract)
        {
            _blogsContract = blogsContract;
        }

        [HttpPost]
        [Description("新增")]
        [ServiceFilter(typeof(UnitOfWorkAttribute))]
        public async Task<AjaxResult> Creat(PostInputDto[] dtos)
        {
            OperationResult result = await _blogsContract.CreatePosts(dtos);
            return result.ToAjaxResult();
        }
    }
}
