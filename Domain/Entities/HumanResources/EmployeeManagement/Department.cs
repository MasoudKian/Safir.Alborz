using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.HumanResources.EmployeeManagement
{
    public class Department : BaseEntity
    {
        [MaxLength(300)]
        public string Name { get; set; } = string.Empty;  // نام بخش


        // رابطه یک به چند با Position
        public ICollection<Position> Positions { get; set; } = new List<Position>();

        // رابطه یک به چند با Employee
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
