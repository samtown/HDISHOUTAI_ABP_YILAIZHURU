using System;
using System.ComponentModel.DataAnnotations;

namespace Dialysis.Dto.WebApi
{
    /// <summary>
    /// AddPatientContactSync
    /// </summary>
    public class AddPatientContactSync
    {
        /// <summary>
        /// 透析患者联系人Id（华墨系统Id）
        /// </summary>
        [Required]
        public int DialysisContactId { get; set; }

        /// <summary>
        /// 透析患者Id（华墨系统Id）
        /// </summary>
        [Required]
        public int DialysisPatientId { get; set; }

        /// <summary>
        /// 医院ID
        /// </summary>
        [Required]
        public long HospitalId { get; set; }

        /// <summary>
        /// 联系人姓名
        /// </summary>
        [StringLength(50)]
        public string ContatctName { get; set; }

        /// <summary>
        /// 与患者关系
        /// </summary>
        [StringLength(20)]
        public string Relationship { get; set; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        [StringLength(64)]
        public string Email { get; set; }

        /// <summary>
        /// 固定电话
        /// </summary>
        [StringLength(16)]
        public string Telephone { get; set; }

        /// <summary>
        /// 移动电话
        /// </summary>
        [StringLength(16)]
        public string MobilePhone { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        [StringLength(8)]
        public string Country { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        [StringLength(8)]
        public string Province { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        [StringLength(8)]
        public string City { get; set; }

        /// <summary>
        /// 区
        /// </summary>
        [StringLength(8)]
        public string Area { get; set; }

        /// <summary>
        /// 地址1
        /// </summary>
        [StringLength(64)]
        public string Address1 { get; set; }

        /// <summary>
        /// 地址2
        /// </summary>
        [StringLength(64)]
        public string Address2 { get; set; }

        /// <summary>
        /// 邮政编码
        /// </summary>
        [StringLength(8)]
        public string PostCode { get; set; }
    }
}
