using System.ComponentModel.DataAnnotations;

namespace Dialysis.Dto.Admin
{
    /// <summary>
    /// AdministratorViewDto
    /// </summary>
    public class AdministratorViewDto
    {
        /// <summary>
        /// 管理员ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 是否超级管理员
        /// </summary>
        public bool IsSuperManager { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName { get; set; }
    }
}
