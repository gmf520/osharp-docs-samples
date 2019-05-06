using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OSharp.Core.Packs;

namespace Liuliu.Blogs.Blogs
{
    /// <summary>
    /// 博客模块
    /// </summary>
    public class BlogsPack : OsharpPack
    {
        /// <summary>
        /// 获取 模块级别，级别越小越先启动
        /// </summary>
        public override PackLevel Level { get; } = PackLevel.Business;

        /// <summary>将模块服务添加到依赖注入服务容器中</summary>
        /// <param name="services">依赖注入服务容器</param>
        /// <returns></returns>
        public override IServiceCollection AddServices(IServiceCollection services)
        {
            services.TryAddScoped<IBlogsContract, BlogsService>();

            return services;
        }
    }
}
