using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.Admin
{
    /// <summary>
    /// 患者显示Dto
    /// </summary>
    public class PatientViewDto
    {
        /// <summary>
        /// 患者Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PatientName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        public string UserStatus { get; set; }

        /// <summary>
        /// 用户状态Css
        /// </summary>
        public string UserStatusCss { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public string Brithdate { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }

        /// <summary>
        /// 所属医护人员姓名
        /// </summary>
        public string DoctorName { get; set; }

        /// <summary>
        /// 透析患者Id（华墨系统Id）
        /// </summary>
        public int DialysisPatientId { get; set; }
    }
}
