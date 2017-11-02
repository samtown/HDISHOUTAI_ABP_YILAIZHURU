using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dialysis.Domain.Models
{
    /// <summary>
    /// 患者
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        /// <summary>
        /// 透析患者Id（华墨系统Id）
        /// </summary>
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
        /// 用户状态（0：未激活，1：正常，2：转院，3：死亡，4：移植）
        /// </summary>
        public int UserStatus { get; set; }

        /// <summary>
        /// 患者头像
        /// </summary>
        [StringLength(200)]
        public string PatientFace { get; set; }

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
        /// 医院Id
        /// </summary>
        public long HospitalId { get; set; }

        /// <summary>
        /// 所属医护人员Id
        /// </summary>
        public long? DoctorId { get; set; }

        /// <summary>
        /// 水杯MAC地址
        /// </summary>
        [StringLength(64)]
        public string CupMAC { get; set; }

        /// <summary>
        /// 新增时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 医院
        /// </summary>
        public virtual Hospital Hospital { get; set; }

        /// <summary>
        /// 医护人员
        /// </summary>
        public virtual Doctor Doctor { get; set; }

        /// <summary>
        /// 报警
        /// </summary>
        public virtual ICollection<Alarm> Alarms { get; set; }

        /// <summary>
        /// 血压
        /// </summary>
        public virtual ICollection<BloodPressure> BloodPressures { get; set; }

        /// <summary>
        /// 体重
        /// </summary>
        public virtual ICollection<Weight> Weights { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public virtual ICollection<PatientContact> PatientContacts { get; set; }
    }
}
