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
    /// 输出DTO：文章信息
    /// </summary>
    [MapFrom(typeof(Post))]
    public class PostOutputDto : IOutputDto, IDataAuthEnabled
    {
        /// <summary>
        /// 获取或设置 文章编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 获取或设置 文章标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 获取或设置 文章内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 获取或设置 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 获取或设置 所属博客编号
        /// </summary>
        public int BlogId { get; set; }

        /// <summary>
        /// 获取或设置 作者编号
        /// </summary>
        [UserFlag]
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
