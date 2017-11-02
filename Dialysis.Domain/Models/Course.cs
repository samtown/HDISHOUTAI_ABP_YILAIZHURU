using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dialysis.Domain.Models
{
    /// <summary>
    /// 课程
    /// </summary>
    public class Course
    {
        /// <summary>
        /// 课程Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        //[ForeignKey("DictionaryId")]
        public int Type { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        /// <summary>
        /// Logo
        /// </summary>
        [StringLength(200)]
        public string Logo { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [Required]
        [StringLength(5000)]
        public string Content { get; set; }

        /// <summary>
        /// 排序Id
        /// </summary>
        public int SortId { get; set; }

        /// <summary>
        /// 新增时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime UpdateTime { get; set; }

        ///// <summary>
        ///// 资讯类别字典
        ///// </summary>
        //public virtual Dictionary Dictionary { get; set; }
    }
}
