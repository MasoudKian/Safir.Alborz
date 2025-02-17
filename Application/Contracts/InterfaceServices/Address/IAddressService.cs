using Application.DTOs.Address;
using Application.DTOs.Address.CRUD;

namespace Application.Contracts.InterfaceServices.Address
{
    public interface IAddressService
    {
        #region Provinces

        Task<List<ProvinceDto>> GetAllProvincesAsync();
        Task<ProvinceDto?> GetProvinceByIdAsync(int id);
        Task<ProvinceDto> CreateProvinceAsync(CreateProvinceDto dto);
        Task<bool> UpdateProvinceAsync(ProvinceDto dto);


        #endregion


        #region Cities
        Task<List<CityDto>> GetAllCitiesAsync();
        Task<CityDto?> GetCityByIdAsync(int id);
        Task<CityDto> CreateCityAsync(CreateCityDto dto);
        Task<bool> UpdateCityAsync(CityDto dto);
        #endregion

        #region Regions
        Task<List<RegionDto>> GetAllRegionsAsync();
        Task<RegionDto?> GetRegionByIdAsync(int id);
        Task<RegionDto> CreateRegionAsync(CreateRegionDto dto);
        Task<bool> UpdateRegionAsync(RegionDto dto);
        #endregion
    }
}
