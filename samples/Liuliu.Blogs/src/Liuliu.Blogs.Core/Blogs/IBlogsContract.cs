using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Liuliu.Blogs.Blogs.Dtos;
using Liuliu.Blogs.Blogs.Entities;
using OSharp.Data;

namespace Liuliu.Blogs.Blogs
{
    /// <summary>
    /// 业务契约接口：博客模块
    /// </summary>
    public interface IBlogsContract
    {
        #region 博客信息业务

        /// <summary>
        /// 获取 博客信息查询数据集
        /// </summary>
        IQueryable<Blog> Blogs { get; }

        /// <summary>
        /// 检查博客信息是否存在
        /// </summary>
        /// <param name="predicate">检查谓语表达式</param>
        /// <param name="id">更新的博客信息编号</param>
        /// <returns>博客信息是否存在</returns>
        Task<bool> CheckBlogExists(Expression<Func<Blog, bool>> predicate, int id = 0);

        /// <summary>
        /// 申请博客信息
        /// </summary>
        /// <param name="dto">申请博客信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        Task<OperationResult> ApplyForBlog(BlogInputDto dto);

        /// <summary>
        /// 审核博客信息
        /// </summary>
        /// <param name="dto">审核博客信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        Task<OperationResult> VerifyBlog(BlogVerifyDto dto);

        /// <summary>
        /// 更新博客信息
        /// </summary>
        /// <param name="dtos">包含更新信息的博客信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        Task<OperationResult> UpdateBlogs(params BlogInputDto[] dtos);

        #endregion

        #region 文章信息业务

        /// <summary>
        /// 获取 文章信息查询数据集
        /// </summary>
        IQueryable<Post> Posts { get; }

        /// <summary>
        /// 检查文章信息是否存在
        /// </summary>
        /// <param name="predicate">检查谓语表达式</param>
        /// <param name="id">更新的文章信息编号</param>
        /// <returns>文章信息是否存在</returns>
        Task<bool> CheckPostExists(Expression<Func<Post, bool>> predicate, int id = 0);

        /// <summary>
        /// 添加文章信息
        /// </summary>
        /// <param name="dtos">要添加的文章信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        Task<OperationResult> CreatePosts(params PostInputDto[] dtos);

        /// <summary>
        /// 更新文章信息
        /// </summary>
        /// <param name="dtos">包含更新信息的文章信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        Task<OperationResult> UpdatePosts(params PostInputDto[] dtos);

        /// <summary>
        /// 删除文章信息
        /// </summary>
        /// <param name="ids">要删除的文章信息编号</param>
        /// <returns>业务操作结果</returns>
        Task<OperationResult> DeletePosts(params int[] ids);

        #endregion
    }
}
