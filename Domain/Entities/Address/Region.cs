using Domain.Entities.MSCRM;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Address
{
    public class Region : BaseEntity
    {



        [Display(Name = "نام منطقه")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "کد منطقه")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        [MaxLength(6)]
        public string Code { get; set; } = string.Empty;

        public int ProvinceId { get; set; }
        [ForeignKey("ProvinceId")]
        public virtual Province Province { get; set; }

        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        public virtual ICollection<Marketer> Marketers { get; set; } = new HashSet<Marketer>();
        public virtual ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();
        public virtual ICollection<Driver> Drivers { get; set; } = new HashSet<Driver>();
    }
}
