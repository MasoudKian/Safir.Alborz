using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Address
{
    public class Province : BaseEntity
    {
        [Display(Name = "نام استان")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<City> Cities { get; set; } = new HashSet<City>();
    }
}
