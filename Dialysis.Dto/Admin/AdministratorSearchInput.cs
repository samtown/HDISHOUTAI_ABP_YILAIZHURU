using Dialysis.Dto.Common;

namespace Dialysis.Dto.Admin
{
    /// <summary>
    /// 管理员搜索输入
    /// </summary>
    public class AdministratorSearchInput : SearchBase
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 医院Id
        /// </summary>
        public long HospitalId { get; set; }
    }
}
