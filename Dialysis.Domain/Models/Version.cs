using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dialysis.Domain.Models
{
    /// <summary>
    /// 版本
    /// </summary>
    public class Version
    {
        /// <summary>
        /// 主键
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public int VersionCode { get; set; }

        /// <summary>
        /// 版本类型（0-医护端，1-患者端）
        /// </summary>
        public int VersionType { get; set; }

        /// <summary>
        /// 版本名称
        /// </summary>
        [Required]
        [StringLength(20)]
        public string VersionName { get; set; }

        /// <summary>
        /// 更新日志
        /// </summary>
        [Required]
        [StringLength(500)]
        public string UpdateLog { get; set; }

        /// <summary>
        /// 下载地址
        /// </summary>
        [Required]
        [StringLength(200)]
        public string DownloadUrl { get; set; }

        /// <summary>
        /// 文件MD5
        /// </summary>
        [Required]
        [StringLength(50)]
        public string FileMD5 { get; set; }

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
