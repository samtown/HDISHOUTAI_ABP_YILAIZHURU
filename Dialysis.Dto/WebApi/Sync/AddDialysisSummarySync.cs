using System.ComponentModel.DataAnnotations;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// AddDialysisSummarySync
    /// </summary>
    public class AddDialysisSummarySync
    {
        /// <summary>
        /// 透析记录Id（华墨系统Id）
        /// </summary>
        [Required]
        public int DialysisRecordId { get; set; }

        /// <summary>
        /// 医院Id
        /// </summary>
        [Required]
        public long HospitalId { get; set; }

        /// <summary>
        /// 透析小结
        /// </summary>
        [StringLength(512)]
        public string Summary { get; set; }
    }
}
