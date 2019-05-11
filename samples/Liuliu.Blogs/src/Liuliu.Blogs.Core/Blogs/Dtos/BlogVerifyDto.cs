using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using OSharp.Entity;

namespace Liuliu.Blogs.Blogs.Dtos
{
    /// <summary>
    /// 输入DTO：审核博客信息
    /// </summary>
    public class BlogVerifyDto : IInputDto<int>
    {
        /// <summary>
        /// 获取或设置 博客编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 获取或设置 是否开通
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 获取或设置 审核理由
        /// </summary>
        [Required]
        public string Reason { get; set; }
    }
}
