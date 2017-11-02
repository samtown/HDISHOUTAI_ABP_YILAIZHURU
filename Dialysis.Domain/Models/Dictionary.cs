using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dialysis.Domain.Models
{
    /// <summary>
    /// 系统字典
    /// </summary>
    public class Dictionary
    {
        /// <summary>
        /// 字典Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        /// <summary>
        /// Logo
        /// </summary>
        [StringLength(200)]
        public string Logo { get; set; }

        /// <summary>
        /// 父级键值
        /// </summary>
        public int ParentValue { get; set; }

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
    }
}
