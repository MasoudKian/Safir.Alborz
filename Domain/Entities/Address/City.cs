using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Address
{
    public class City : BaseEntity
    {
        [Display(Name = "نام شهر")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public int ProvinceId { get; set; }
        [ForeignKey("ProvinceId")]
        public Province Province { get; set; }

        public ICollection<Region> Regions { get; set; } = new List<Region>();
    }
}
