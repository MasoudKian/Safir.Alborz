using Application.Utils;

namespace Application.DTOs.HumanResources.Department
{
    public class DepartmentListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;    
        public int EmployeeCount { get; set; }
        public DateTime CreatedDate { get; set; } // تاریخ ثبت

        public string CreatedDateShamsi => CreatedDate.ToShamsi(true);
    }
}
