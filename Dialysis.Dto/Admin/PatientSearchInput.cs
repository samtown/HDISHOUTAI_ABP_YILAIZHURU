using Dialysis.Dto.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.Admin
{
    /// <summary>
    /// 患者搜索输入
    /// </summary>
    public class PatientSearchInput : SearchBase
    {
        /// <summary>
        /// 患者名称
        /// </summary>
        public string PatientName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        public int UserStatus { get; set; }

        /// <summary>
        /// 医院Id
        /// </summary>
        public long HospitalId { get; set; }
    }
}
