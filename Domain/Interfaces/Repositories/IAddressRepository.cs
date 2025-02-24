using Domain.Entities.Address;

namespace Domain.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        Task<string> GetNameById<T>(int id);

        #region Province
        // متدهای مربوط به استان
        Task<List<Province>> GetAllProvincesAsync();
        Task<Province?> GetProvinceByIdAsync(int id);
        Task<Province> CreateProvinceAsync(Province province);
        Task<bool> UpdateProvinceAsync(Province province);


        #endregion

        #region City
        Task<List<City>> GetCitiesByProvinceIdAsync(int provinceId);
        Task<List<City>> GetAllCitiesAsync();
        Task<City?> GetCityByIdAsync(int id);
        Task<City> CreateCityAsync(City city);
        Task<bool> UpdateCityAsync(City city);
        #endregion

        #region Region

        Task<List<Region>> GetRegionByProvinceIdAndCityIdAsync(int provinceId,int cityId);
        Task<List<Region>> GetAllRegionsAsync();
        Task<Region?> GetRegionByIdAsync(int id);
        Task<Region> CreateRegionAsync(Region region);
        Task<bool> UpdateRegionAsync(Region region);
        Task<bool> CheckDuplicateRegionByName(string name, int provinceId, int cityId);
        #endregion
    }
}
