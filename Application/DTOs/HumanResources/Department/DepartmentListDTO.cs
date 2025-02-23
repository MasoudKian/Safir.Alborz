using Application.Utils;

namespace Application.DTOs.HumanResources.Department
{
    public class DepartmentListDTO : BaseDTO
    {
        //public int DepartmentId { get; set; }
        public string Name { get; set; } = string.Empty;    
        public int EmployeeCount { get; set; }
        public DateTime RegisteredDate { get; set; } 

        //public string CreatedDateShamsi => CreatedDate.ToShamsi(true);
    }
}
