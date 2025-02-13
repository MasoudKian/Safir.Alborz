using Domain.Entities.HumanResources.EmployeeManagement;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.MSCRM
{
    public class Marketer : BaseEntity
    {
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; }


        public IEnumerable<Clue> Clues { get; set; } = new List<Clue>();
        public IEnumerable<Customer> Customers { get; set; } = new List<Customer>();
    }
}
