using System;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// PatientLoginOutput
    /// </summary>
    public class PatientLoginOutput
    {
        /// <summary>
        /// 患者ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PatientName { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactPhone { get; set; }

        /// <summary>
        /// 性别（0：男，1：女）
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 治疗状态
        /// </summary>
        public string TherapyStatus { get; set; }

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
        public string PatientFace { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime Brithdate { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 医院ID
        /// </summary>
        public long HospitalId { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }

        /// <summary>
        /// 水杯MAC地址
        /// </summary>
        public string CupMAC { get; set; }
    }
}
