using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.MSCRMdto
{
    public class AddMarketerDTO
    {
        public string? MarketerCode { get; set; } 

        public int EmployeeId { get; set; }

        public int ProvinceId { get; set; }

        public int CityId { get; set; }

        public int RegionId { get; set; }
    }
}
