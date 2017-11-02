using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dialysis.Domain.Models
{
    /// <summary>
    /// 城市
    /// </summary>
    public class City
    {
        /// <summary>
        /// 城市Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// 省份Id
        /// </summary>
        public int ProvinceId { get; set; }

        /// <summary>
        /// 城市名称
        /// </summary>
        [Required]
        [StringLength(20)]
        public string CityName { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        public virtual Province Province { get; set; }

        /// <summary>
        /// 医院
        /// </summary>
        public virtual ICollection<Hospital> Hospitals { get; set; }
    }
}
