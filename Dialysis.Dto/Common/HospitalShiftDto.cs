namespace Dialysis.Dto.Common
{
    /// <summary>
    /// 医院排班信息
    /// </summary>
    public class HospitalShiftDto
    {
        /// <summary>
        /// 班次名称
        /// </summary>
        public string ShiftName { get; set; }

        /// <summary>
        /// 班次类别
        /// </summary>
        public string ShiftType { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string EndTime { get; set; }
    }
}
