using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dialysis.Dto.WebApi.Input
{
    /// <summary>
    /// 添加手环数据请求输入
    /// </summary>
    public class AddHandRingInput
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        [Required]
        public long PatientId { get; set; }

        /// <summary>
        /// 手环数据
        /// </summary>
        [Required]
        public List<AddHandRingBaseInput> HandRingList { get; set; }
    }

    /// <summary>
    /// 添加手环基础数据请求输入
    /// </summary>
    public class AddHandRingBaseInput
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Date { get; set; }

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
