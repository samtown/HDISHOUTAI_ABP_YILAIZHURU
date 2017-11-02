using System;
using System.ComponentModel.DataAnnotations;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// AddPatientSync
    /// </summary>
    public class AddPatientSync
    {
        /// <summary>
        /// 透析患者Id（华墨系统Id）
        /// </summary>
        [Required]
        public int DialysisPatientId { get; set; }

        /// <summary>
        /// 透析病案号
        /// </summary>
        [StringLength(10)]
        public string PatientNo { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        [StringLength(8)]
        public string CertType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        [StringLength(32)]
        public string CertNo { get; set; }

        /// <summary>
        /// 医保类型
        /// </summary>
        [StringLength(8)]
        public string MedicalInsuranceType { get; set; }

        /// <summary>
        /// 首次透析日期
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime? FirstDialysisDate { get; set; }

        /// <summary>
        /// 入科日期
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime? DateOfEntry { get; set; }

        /// <summary>
        /// 死亡日期
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime? DateOfDeath { get; set; }

        /// <summary>
        /// 治疗状态
        /// </summary>
        [StringLength(16)]
        public string TherapyStatus { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        [Required]
        [StringLength(20)]
        public string PatientName { get; set; }

        /// <summary>
        /// 患者姓名拼音码
        /// </summary>
        [Required]
        [StringLength(20)]
        public string PinyinCode { get; set; }

        /// <summary>
        /// 性别（0：男，1：女）
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 体重
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// 身高
        /// </summary>
        public decimal Height { get; set; }

        /// <summary>
        /// 患者头像
        /// </summary>
        public Byte[] PatientFace { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime Brithdate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(2000)]
        public string Remark { get; set; }

        /// <summary>
        /// 医院ID
        /// </summary>
        [Required]
        public long HospitalId { get; set; }

        /// <summary>
        /// 所属医护人员ID
        /// </summary>
        public long? DoctorId { get; set; }
    }
}
