using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dialysis.Domain.Models
{
    /// <summary>
    /// 医院
    /// </summary>
    public class Hospital
    {
        /// <summary>
        /// 医院Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        /// <summary>
        /// 城市Id
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// 医院名称
        /// </summary>
        [Required]
        [StringLength(50)]
        public string HospitalName { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public virtual City City { get; set; }

        /// <summary>
        /// 管理员
        /// </summary>
        public virtual ICollection<Administrator> Administrators { get; set; }

        /// <summary>
        /// 医护人员
        /// </summary>
        public virtual ICollection<Doctor> Doctors { get; set; }

        /// <summary>
        /// 患者
        /// </summary>
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
