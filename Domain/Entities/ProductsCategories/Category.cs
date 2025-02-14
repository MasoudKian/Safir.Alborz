using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ProductsCategories
{
    public class Category : BaseEntity
    {
        [Display(Name = "نام دسته‌بندی")]
        [Required(ErrorMessage = "{0} ضروری است.")]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        public int? ParentCategoryId { get; set; } // برای پشتیبانی از زیر دسته‌ها
        [ForeignKey("ParentCategoryId")]
        public Category? ParentCategory { get; set; }

        public ICollection<CategoryProduct> CategoryProducts { get; set; } = new List<CategoryProduct>();
    }
}
