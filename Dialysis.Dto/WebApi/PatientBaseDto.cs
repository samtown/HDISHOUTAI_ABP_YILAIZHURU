using System;
using System.Collections.Generic;
using System.Text;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// 患者输出
    /// </summary>
    public class PatientBaseDto
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
        /// 患者姓名拼音码
        /// </summary>
        public string PinyinCode { get; set; }

        /// <summary>
        /// 患者头像
        /// </summary>
        public string PatientFace { get; set; }

        /// <summary>
        /// 用户状态（0：未激活，1：正常，2：转院，3：死亡，4：移植）
        /// </summary>
        public int UserStatus { get; set; }
    }
}
