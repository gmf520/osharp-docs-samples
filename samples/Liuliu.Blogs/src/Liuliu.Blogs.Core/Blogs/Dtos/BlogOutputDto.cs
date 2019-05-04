using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using OSharp.Entity;

namespace Liuliu.Blogs.Blogs.Dtos
{
    /// <summary>
    /// 输出DTO：博客信息
    /// </summary>
    public class BlogOutputDto : IOutputDto, IDataAuthEnabled
    {
        /// <summary>
        /// 获取或设置 博客编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 获取或设置 博客地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 获取或设置 显示名称
        /// </summary>
        public string Display { get; set; }

        /// <summary>
        /// 获取或设置 已开通
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 获取或设置 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 获取或设置 作者编号
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 获取或设置 是否可更新的数据权限状态
        /// </summary>
        public bool Updatable { get; set; }

        /// <summary>
        /// 获取或设置 是否可删除的数据权限状态
        /// </summary>
        public bool Deletable { get; set; }
    }
}
