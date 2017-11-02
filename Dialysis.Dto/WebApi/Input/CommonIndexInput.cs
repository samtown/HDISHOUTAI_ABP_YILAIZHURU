namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// 公共指标输入
    /// </summary>
    public class CommonIndexInput
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        public long PatientId { get; set; }

        /// <summary>
        /// top数量
        /// </summary>
        public int TopNumber { get; set; }
    }
}
