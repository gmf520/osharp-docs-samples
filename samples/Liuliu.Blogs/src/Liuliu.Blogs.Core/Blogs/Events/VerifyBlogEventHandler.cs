using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OSharp.EventBuses;

namespace Liuliu.Blogs.Blogs.Events
{
    /// <summary>
    /// 审核博客事件处理器
    /// </summary>
    public class VerifyBlogEventHandler : EventHandlerBase<VerifyBlogEventData>
    {
        private readonly ILogger _logger;

        /// <summary>
        /// 初始化一个<see cref="VerifyBlogEventHandler"/>类型的新实例
        /// </summary>
        public VerifyBlogEventHandler(IServiceProvider serviceProvider)
        {
            _logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<VerifyBlogEventHandler>();
        }

        /// <summary>事件处理</summary>
        /// <param name="eventData">事件源数据</param>
        public override void Handle(VerifyBlogEventData eventData)
        {
            _logger.LogInformation(
                $"触发 审核博客事件处理器，用户“{eventData.UserName}”的博客“{eventData.BlogName}”审核结果：{(eventData.IsEnabled ? "通过" : "未通过")}");
        }
    }
}
