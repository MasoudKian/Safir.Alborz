using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ProductsCategories
{
    public class Product : BaseEntity
    {
        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        [MaxLength(300)]
        public string ProductName { get; set; } = string.Empty;

        [Display(Name = "توضیحات")]
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        public decimal Price { get; set; }

        [Display(Name = "موجودی")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        public int Stock { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }


        public ICollection<CategoryProduct> CategoryProducts { get; set; } = new List<CategoryProduct>();

    }
}
