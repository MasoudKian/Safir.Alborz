namespace Application.DTOs.Address
{
    public class CityDto : BaseDTO
    {
        public string Name { get; set; } = string.Empty;
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; } = string.Empty;
    }
}
