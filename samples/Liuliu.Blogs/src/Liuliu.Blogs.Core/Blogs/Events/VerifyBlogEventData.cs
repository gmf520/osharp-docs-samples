using System;
using System.Collections.Generic;
using System.Text;
using OSharp.EventBuses;

namespace Liuliu.Blogs.Blogs.Events
{
    /// <summary>
    /// 审核博客事件数据
    /// </summary>
    public class VerifyBlogEventData : EventDataBase
    {
        /// <summary>
        /// 获取或设置 博客名称
        /// </summary>
        public string BlogName { get; set; }

        /// <summary>
        /// 获取或设置 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 获取或设置 审核是否通过
        /// </summary>
        public bool IsEnabled { get; set; }
    }
}
