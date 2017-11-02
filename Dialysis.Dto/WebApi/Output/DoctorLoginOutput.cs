using System;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// 医护人员登录输出
    /// </summary>
    public class DoctorLoginOutput : DictDto
    {
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 性别（0：男，1：女）
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 用户类型（0：医生，1：护士长，2：护士）
        /// </summary>
        public int UserType { get; set; }

        /// <summary>
        /// 医生头像
        /// </summary>
        public string DoctorFace { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime Brithdate { get; set; }

        /// <summary>
        /// 医院Id
        /// </summary>
        public long HospitalId { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }

        /// <summary>
        /// 科室名称
        /// </summary>
        public string Dept { get; set; }

        /// <summary>
        /// 职称
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 个人简介
        /// </summary>
        public string SelfDesc { get; set; }

        /// <summary>
        /// 患者数量
        /// </summary>
        public int PatientCount { get; set; }
    }
}
