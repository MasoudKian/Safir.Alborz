using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.ProductsCategories
{
    public class CategoryProduct : BaseEntity
    {
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
