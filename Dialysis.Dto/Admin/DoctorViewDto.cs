using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.Admin
{
    /// <summary>
    /// 医护人员显示Dto
    /// </summary>
    public class DoctorViewDto
    {
        /// <summary>
        /// 医护人员Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public string UserType { get; set; }

        /// <summary>
        /// 医生头像
        /// </summary>
        public string DoctorFace { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public string Brithdate { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }

        /// <summary>
        /// 科室
        /// </summary>
        public string DeptName { get; set; }

        /// <summary>
        /// 职称
        /// </summary>
        public string TitleName { get; set; }

        /// <summary>
        /// 个人简介
        /// </summary>
        public string SelfDesc { get; set; }

        /// <summary>
        /// 透析医护人员Id（华墨系统Id）
        /// </summary>
        public string DialysisDoctorId { get; set; }
    }
}
