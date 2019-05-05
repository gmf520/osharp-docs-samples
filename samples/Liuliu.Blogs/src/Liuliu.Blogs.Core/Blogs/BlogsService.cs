using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Liuliu.Blogs.Blogs.Entities;
using Liuliu.Blogs.Identity.Entities;
using OSharp.Entity;

namespace Liuliu.Blogs.Blogs
{
/// <summary>
/// 业务服务实现：博客模块
/// </summary>
public partial class BlogsService : IBlogsContract
{
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// 初始化一个<see cref="BlogsService"/>类型的新实例
    /// </summary>
    public BlogsService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// 获取 博客仓储对象
    /// </summary>
    protected IRepository<Blog, int> BlogRepository => _serviceProvider.GetService<IRepository<Blog, int>>();

    /// <summary>
    /// 获取 文章仓储对象
    /// </summary>
    protected IRepository<Post, int> PostRepository => _serviceProvider.GetService<IRepository<Post, int>>();

    /// <summary>
    /// 获取 用户仓储对象
    /// </summary>
    protected IRepository<User, int> UserRepository => _serviceProvider.GetService<IRepository<User, int>>();
}
}
