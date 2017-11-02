using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dialysis.Domain.Models
{
    /// <summary>
    /// 资讯
    /// </summary>
    public class Infomation
    {
        /// <summary>
        /// 资讯Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        /// <summary>
        /// 资讯类别
        /// </summary>
        //[ForeignKey("DictionaryId")]
        public int InfoCategory { get; set; }

        /// <summary>
        /// 资讯标题
        /// </summary>
        [Required]
        [StringLength(200)]
        public string InfoTitle { get; set; }

        /// <summary>
        /// 资讯Logo
        /// </summary>
        [StringLength(200)]
        public string InfoLogo { get; set; }

        /// <summary>
        /// 资讯内容
        /// </summary>
        [StringLength(5000)]
        public string InfoContent { get; set; }

        /// <summary>
        /// 是否首页轮播
        /// </summary>
        public bool IsHomePageSlide { get; set; }

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
