using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Address
{
    public class Province : BaseEntity
    {
        [Display(Name = "نام استان")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public ICollection<City> Cities { get; set; } = new List<City>();
    }
}
