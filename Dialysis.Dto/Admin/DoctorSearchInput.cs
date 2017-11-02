using Dialysis.Dto.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.Admin
{
    /// <summary>
    /// 医护人员搜索输入
    /// </summary>
    public class DoctorSearchInput : SearchBase
    {
        /// <summary>
        /// 医护人员名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 用户类型
        /// </summary>
        public int UserType { get; set; }

        /// <summary>
        /// 医院Id
        /// </summary>
        public long HospitalId { get; set; } = -1;

        /// <summary>
        /// 部门Id
        /// </summary>
        public int DeptId { get; set; }

        /// <summary>
        /// 职称Id
        /// </summary>
        public int TitleId { get; set; }
    }
}
