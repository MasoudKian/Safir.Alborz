namespace Application.DTOs.HumanResources.Employee
{
    public class GetEmployeeByCode
    {
        public string EmployeeID { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

        public string PositionName { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;

        public string Phone { get; set; }
    }
}
