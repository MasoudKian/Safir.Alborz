using Domain.Entities.Address;
using Domain.Entities.HumanResources.EmployeeManagement;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.MSCRM
{
    public class Marketer : BaseEntity
    {
        public string MarketerCode { get; set; } = string.Empty;

        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        public int ProvinceId { get; set; }
        [ForeignKey("ProvinceId")]
        public virtual Province Province { get; set; }

        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        public int RegionId { get; set; }
        [ForeignKey("RegionId")]
        public Region Region { get; set; }

        public ICollection<Clue> Clues { get; set; } = new List<Clue>();
        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
    }
}
