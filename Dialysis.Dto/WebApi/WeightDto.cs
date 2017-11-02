namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// 体重
    /// </summary>
    public class WeightDto
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
