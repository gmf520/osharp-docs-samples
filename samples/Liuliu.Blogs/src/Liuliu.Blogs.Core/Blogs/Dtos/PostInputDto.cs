using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Liuliu.Blogs.Blogs.Entities;
using OSharp.Entity;
using OSharp.Mapping;

namespace Liuliu.Blogs.Blogs.Dtos
{
    /// <summary>
    /// 输入DTO：文章信息
    /// </summary>
    [MapTo(typeof(Post))]
    public class PostInputDto : IInputDto<int>
    {
        /// <summary>
        /// 获取或设置 文章编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 获取或设置 文章标题
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// 获取或设置 文章内容
        /// </summary>
        [Required]
        public string Content { get; set; }
    }
}
