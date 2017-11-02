using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dialysis.Common.Enum
{
    /// <summary>
    /// 时间段类型枚举
    /// </summary>
    public enum TimeRangTypeEnum
    {
        /// <summary>
        /// 一星期
        /// </summary>
        [Display(Description = "一星期")]
        OneWeek = 0,

        /// <summary>
        /// 一个月
        /// </summary>
        [Display(Description = "一个月")]
        OneMonth = 1,

        /// <summary>
        /// 三个月
        /// </summary>
        [Display(Description = "三个月")]
        ThreeMonths = 2
    }
}
