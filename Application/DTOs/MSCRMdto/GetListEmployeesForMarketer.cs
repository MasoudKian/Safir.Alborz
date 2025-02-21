using Domain.Enums;

namespace Application.DTOs.MSCRMdto
{
    public class GetListEmployeesForMarketer : BaseDTO
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string IRCode { get; set; } = string.Empty;

        public string EmployeID { get; set; } = string.Empty;


    }
}
