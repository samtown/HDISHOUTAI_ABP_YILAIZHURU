using System.ComponentModel.DataAnnotations;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// UpdateCupMACInput
    /// </summary>
    public class UpdateCupMACInput
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        [Required]
        public long PatientId { get; set; }

        /// <summary>
        /// 身高
        /// </summary>
        [Required]
        [StringLength(64)]
        public string CupMAC { get; set; }
    }
}
