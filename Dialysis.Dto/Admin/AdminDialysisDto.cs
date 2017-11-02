using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.Admin
{
    /// <summary>
    /// 后台透析Dto
    /// </summary>
    public class AdminDialysisDto
    {
        /// <summary>
        /// 透析记录单Id(主键)
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 透析日期
        /// </summary>
        public string DialysisDate { get; set; }

        /// <summary>
        /// 透析时长(min)
        /// </summary>
        public int DialysisDuration { get; set; }

        /// <summary>
        /// 床号
        /// </summary>
        public string BedNo { get; set; }

        /// <summary>
        /// 透析方式
        /// </summary>
        public string DialysisWay { get; set; }

        /// <summary>
        /// 开始时间/上机时间
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// 上机护士
        /// </summary>
        public string OnNurse { get; set; }

        /// <summary>
        /// 责任医生
        /// </summary>
        public string Doctor { get; set; }

        /// <summary>
        /// 结束时间/下机时间
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// 下机护士
        /// </summary>
        public string OffNurse { get; set; }

        /// <summary>
        /// 班次名称
        /// </summary>
        public string ShiftName { get; set; }
    }
}
