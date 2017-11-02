using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.Admin
{
    /// <summary>
    /// 后台患者Dto
    /// </summary>
    public class PatientDetailViewDto : PatientViewDto
    {
        /// <summary>
        /// 透析病案号
        /// </summary>
        public string PatientNo { get; set; }

        /// <summary>
        /// 证件类型
        /// </summary>
        public string CertType { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public string CertNo { get; set; }

        /// <summary>
        /// 医保类型
        /// </summary>
        public string MedicalInsuranceType { get; set; }

        /// <summary>
        /// 首次透析日期
        /// </summary>
        public string FirstDialysisDate { get; set; }

        /// <summary>
        /// 入科日期
        /// </summary>
        public string DateOfEntry { get; set; }

        /// <summary>
        /// 死亡日期
        /// </summary>
        public string DateOfDeath { get; set; }

        /// <summary>
        /// 治疗状态
        /// </summary>
        public string TherapyStatus { get; set; }

        /// <summary>
        /// 患者姓名拼音码
        /// </summary>
        public string PinyinCode { get; set; }

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
        public string PatientFace { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 联系人内容
        /// </summary>
        public string ContactContent { get; set; }
    }
}
