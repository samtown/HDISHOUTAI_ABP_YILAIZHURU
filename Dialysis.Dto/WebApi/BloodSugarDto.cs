namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// 血糖
    /// </summary>
    public class BloodSugarDto
    {
        /// <summary>
        /// 血糖记录Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// 测量时间
        /// </summary>
        public string AddTime { get; set; }
    }
}
