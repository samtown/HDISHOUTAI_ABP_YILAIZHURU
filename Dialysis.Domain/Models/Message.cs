using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dialysis.Domain.Models
{
    /// <summary>
    /// 消息
    /// </summary>
    public class Message
    {
        /// <summary>
        /// 消息Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        /// <summary>
        /// 类型（0：患教课程，1：产生体重预警，2：确认体重预警，3：透析上机，4：透析下机）
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [Required]
        [StringLength(5000)]
        public string Content { get; set; }

        /// <summary>
        /// 链接地址
        /// </summary>
        [StringLength(200)]
        public string Url { get; set; }

        /// <summary>
        /// 发件人Id
        /// </summary>
        public long SendId { get; set; }

        /// <summary>
        /// 发件人姓名
        /// </summary>
        [Required]
        [StringLength(50)]
        public string SendName { get; set; }

        /// <summary>
        /// 收件人Id
        /// </summary>
        public long ReceiveId { get; set; }

        /// <summary>
        /// 是否已读
        /// </summary>
        public bool IsRead { get; set; }

        /// <summary>
        /// App类型（0：两端，1：医护端，2：患者端）
        /// </summary>
        public int AppType { get; set; }

        /// <summary>
        /// 外部Id
        /// </summary>
        [StringLength(60)]
        public string OuterId { get; set; }

        /// <summary>
        /// 发件时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime SendTime { get; set; }
    }
}
