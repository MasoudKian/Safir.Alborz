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

        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }

        public ICollection<Marketer> Marketers { get; set; } = new List<Marketer>();
        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
        public ICollection<Driver> Drivers { get; set; } = new List<Driver>();
    }
}
