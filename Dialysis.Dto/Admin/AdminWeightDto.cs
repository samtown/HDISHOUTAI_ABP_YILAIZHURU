using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.Admin
{
    /// <summary>
    /// 后台体重Dto
    /// </summary>
    public class AdminWeightDto
    {
        /// <summary>
        /// 体重记录Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 测量类型
        /// </summary>
        public string MeasureType { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// 测量时间
        /// </summary>
        public string MeasureTime { get; set; }
    }
}
