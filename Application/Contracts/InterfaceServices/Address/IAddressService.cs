using Application.DTOs.Address;
using Application.DTOs.Address.CRUD;
using System.Xml.Linq;

namespace Application.Contracts.InterfaceServices.Address
{
    public interface IAddressService
    {
        #region Provinces

        Task<List<ProvinceDto>> GetAllProvincesAsync();
        Task<ProvinceDto?> GetProvinceByIdAsync(int id);
        Task<ProvinceDto> CreateProvinceAsync(CreateProvinceDto dto, string currentUser);
        Task<bool> UpdateProvinceAsync(ProvinceDto dto);


        #endregion


        #region Cities
        Task<List<CityDto>> GetAllCitiesAsync();
        Task<CityDto?> GetCityByIdAsync(int id);
        Task<CityDto> CreateCityAsync(CreateCityDto dto);
        Task<bool> UpdateCityAsync(CityDto dto);

        Task<List<CityDto>> GetCitiesByProvinceIdAsync(int provinceId);
        #endregion

        #region Regions
        Task<List<RegionDto>> GetListRegionsByProvincesAndCity(int provinceId, int cityId);
        Task<List<RegionDto>> GetAllRegionsAsync();
        Task<RegionDto?> GetRegionByIdAsync(int id);
        Task CreateRegionAsync(CreateRegionDto dto);
        Task<bool> UpdateRegionAsync(RegionDto dto);
        Task<bool> CheckDuplicateRegionName(CheckRegion dto);
        #endregion
    }
}
