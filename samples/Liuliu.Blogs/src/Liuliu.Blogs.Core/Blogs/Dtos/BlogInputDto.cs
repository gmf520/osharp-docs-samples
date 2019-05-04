using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using OSharp.Entity;

namespace Liuliu.Blogs.Blogs.Dtos
{
    /// <summary>
    /// 输入DTO：博客信息
    /// </summary>
    public class BlogInputDto : IInputDto<int>
    {
        /// <summary>
        /// 获取或设置 博客编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 获取或设置 博客地址
        /// </summary>
        [Required]
        public string Url { get; set; }

        /// <summary>
        /// 获取或设置 显示名称
        /// </summary>
        [Required]
        public string Display { get; set; }
    }
}
