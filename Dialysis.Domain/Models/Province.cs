using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dialysis.Domain.Models
{
    /// <summary>
    /// 省份
    /// </summary>
    public class Province
    {
        /// <summary>
        /// 省份Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// 省份名称
        /// </summary>
        [Required]
        [StringLength(20)]
        public string ProvinceName { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public virtual ICollection<City> Cities { get; set; }
    }
}
