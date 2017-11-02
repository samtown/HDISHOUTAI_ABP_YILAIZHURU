namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// DialysisDetailOutput
    /// </summary>
    public class DialysisDetailOutput
    {
        /// <summary>
        /// 上机时间
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// 下机时间
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// 床位
        /// </summary>
        public string BedNo { get; set; }

        /// <summary>
        /// 透前体重(kg)
        /// </summary>
        public decimal? PreWeight { get; set; }

        /// <summary>
        /// 透后体重(kg)
        /// </summary>
        public decimal? PostWeight { get; set; }

        /// <summary>
        /// 预脱
        /// </summary>
        public decimal? PlannedUFV { get; set; }

        /// <summary>
        /// 实脱
        /// </summary>
        public decimal? ActualUFV { get; set; }

        /// <summary>
        /// 上机收缩压(mmHg)
        /// </summary>
        public int? OnSystolicPressure { get; set; }

        /// <summary>
        /// 上机舒张压(mmHg)
        /// </summary>
        public int? OnDiastolicPressure { get; set; }

        /// <summary>
        /// 上机心率(次/分)
        /// </summary>
        public int? OnPulseRate { get; set; }

        /// <summary>
        /// 下机收缩压(mmHg)
        /// </summary>
        public int? OffSystolicPressure { get; set; }

        /// <summary>
        /// 下机舒张压(mmHg)
        /// </summary>
        public int? OffDiastolicPressure { get; set; }

        /// <summary>
        /// 下机心率(次/分)
        /// </summary>
        public int? OffPulseRate { get; set; }

        /// <summary>
        /// 治疗方式
        /// </summary>
        public string DialysisWay { get; set; }

        /// <summary>
        /// 透析小结
        /// </summary>
        public string Summary { get; set; }
    }
}
