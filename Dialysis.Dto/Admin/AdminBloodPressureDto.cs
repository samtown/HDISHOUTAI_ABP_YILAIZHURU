using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.Admin
{
    /// <summary>
    /// 后台血压Dto
    /// </summary>
    public class AdminBloodPressureDto
    {
        /// <summary>
        /// 血压记录Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 测量类型
        /// </summary>
        public string MeasureType { get; set; }

        /// <summary>
        /// 收缩压(mmHg)
        /// </summary>
        public int SystolicPressure { get; set; }

        /// <summary>
        /// 舒张压(mmHg)
        /// </summary>
        public int DiastolicPressure { get; set; }

        /// <summary>
        /// 测量时间
        /// </summary>
        public string MeasureTime { get; set; }
    }
}
