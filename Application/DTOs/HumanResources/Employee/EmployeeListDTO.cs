using Domain.Entities.HumanResources.EmployeeManagement;
using Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.HumanResources.Employee
{
    public class EmployeeListDTO
    {
        public int EId { get; set; }
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string IRCode { get; set; } = string.Empty;

        public string BirthDate { get; set; } = string.Empty;

        public string BirthCertificateNumber { get; set; } = string.Empty;

        public string Mobile { get; set; } = string.Empty;

        public string? Email { get; set; }

        public string Address { get; set; } = string.Empty;

        public string EmployeeCode { get; set; } = string.Empty;

        public string? ProfileImage { get; set; }

        public DateTime RegisteredDate { get; set; }
        


        public Education Education { get; set; }

        public string FieldOfStudy { get; set; } = string.Empty;

        public DateTime DateOfEmployment { get; set; }

        public string FamiliarPhone { get; set; } = string.Empty;

        public bool IsDelete { get; set; }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public int PositionId { get; set; }
        public string PositionName { get; set; } = string.Empty;
    }
}
