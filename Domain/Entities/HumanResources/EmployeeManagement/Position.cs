using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.HumanResources.EmployeeManagement
{
    public class Position : BaseEntity
    {
        public string Title { get; set; } = string.Empty;  // عنوان شغلی


        // شناسه بخش مرتبط
        public int? DepartmentId { get; set; }


        public Department? Department { get; set; }

        // رابطه یک به چند با Employee
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
