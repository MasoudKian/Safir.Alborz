namespace Domain.Entities.HumanResources.EmployeeManagement
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = string.Empty;  // نام بخش


        // رابطه یک به چند با Position
        public ICollection<Position> Positions { get; set; } = new List<Position>();

        // رابطه یک به چند با Employee
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
