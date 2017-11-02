using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dialysis.Domain.Models
{
    /// <summary>
    /// 患者联系人
    /// </summary>
    public class PatientContact
    {
        /// <summary>
        /// 患者联系人Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        /// <summary>
        /// 透析患者联系人Id（华墨系统Id）
        /// </summary>
        public int DialysisContactId { get; set; }

        /// <summary>
        /// 医院Id
        /// </summary>
        public long HospitalId { get; set; }

        /// <summary>
        /// 患者Id
        /// </summary>
        public long PatientId { get; set; }

        /// <summary>
        /// 联系人姓名
        /// </summary>
        [StringLength(50)]
        public string ContatctName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [StringLength(32)]
        public string Password { get; set; }

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

        /// <summary>
        /// 新增时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 患者
        /// </summary>
        public virtual Patient Patient { get; set; }
    }
}
