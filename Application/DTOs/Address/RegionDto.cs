namespace Application.DTOs.Address
{
    public class RegionDto : BaseDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Code { get; set; } 
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; } = string.Empty;
        public int CityId { get; set; }
        public string CityName { get; set; } = string.Empty;
    }
}
