using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// 患者列表输入
    /// </summary>
    public class PatientListInput
    {
        /// <summary>
        /// 用户类型（0：医生，1：护士长，2：护士）
        /// </summary>
        public int UserType { get; set; }

        /// <summary>
        /// 医护人员Id
        /// </summary>
        public long DoctorId { get; set; }

        /// <summary>
        /// 医院Id
        /// </summary>
        public long HospitalId { get; set; }
    }
}
