using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Liuliu.Blogs.Identity.Entities;
using OSharp.Entity;

namespace Liuliu.Blogs.Blogs.Entities
{
    /// <summary>
    /// 实体类：文章信息
    /// </summary>
    [Description("文章信息")]
    public class Post : EntityBase<int>, ICreatedTime, ISoftDeletable
    {
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

        /// <summary>
        /// 获取或设置 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 获取或设置 数据逻辑删除时间，为null表示正常数据，有值表示已逻辑删除，同时删除时间每次不同也能保证索引唯一性
        /// </summary>
        public DateTime? DeletedTime { get; set; }

        /// <summary>
        /// 获取或设置 所属博客编号
        /// </summary>
        public int BlogId { get; set; }

        /// <summary>
        /// 获取或设置 所属博客
        /// </summary>
        public virtual Blog Blog { get; set; }

        /// <summary>
        /// 获取或设置 作者编号
        /// </summary>
        [UserFlag]
        public int UserId { get; set; }

        /// <summary>
        /// 获取或设置 作者
        /// </summary>
        public virtual User User { get; set; }
    }
}
