using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// 消息
    /// </summary>
    public class MessageDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 类型（0：患教课程，1：产生体重预警，2：确认体重预警）
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 链接地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 发件人Id
        /// </summary>
        public long SendId { get; set; }

        /// <summary>
        /// 发件人姓名
        /// </summary>
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
        /// 外部Id
        /// </summary>
        public string OuterId { get; set; }

        /// <summary>
        /// 发送时间
        /// </summary>
        public string SendTime { get; set; }
    }
}
