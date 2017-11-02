using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.Admin
{
    /// <summary>
    /// 后台手环Dto
    /// </summary>
    public class AdminHandRingDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// 步数
        /// </summary>
        public int Steps { get; set; }

        /// <summary>
        /// 距离(米)
        /// </summary>
        public int Distance { get; set; }

        /// <summary>
        /// 睡眠时间(分钟)
        /// </summary>
        public int SleepTime { get; set; }

        /// <summary>
        /// 能量
        /// </summary>
        public decimal Energy { get; set; }
    }
}
