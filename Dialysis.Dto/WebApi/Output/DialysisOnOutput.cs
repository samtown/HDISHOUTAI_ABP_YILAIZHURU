namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// DialysisOnOutput
    /// </summary>
    public class DialysisOnOutput
    {
        /// <summary>
        /// 上机时间
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// 预计下机时间
        /// </summary>
        public string PlannedEndTime { get; set; }

        /// <summary>
        /// 床位
        /// </summary>
        public string BedNo { get; set; }

        /// <summary>
        /// 干体重(kg)
        /// </summary>
        public decimal? DryWeight { get; set; }

        /// <summary>
        /// 透前体重(kg)
        /// </summary>
        public decimal? PreWeight { get; set; }

        /// <summary>
        /// 预脱
        /// </summary>
        public decimal? PlannedUFV { get; set; }

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
        /// 治疗方式
        /// </summary>
        public string DialysisWay { get; set; }
    }
}
