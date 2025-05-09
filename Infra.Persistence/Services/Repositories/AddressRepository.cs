﻿using Application.DTOs.Address.CRUD;
using Domain.Entities.Address;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Services.Repository;

namespace Persistence.Services.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        #region ctor DI

        private readonly IGenericRepository<Province> _provinceRepository;
        private readonly IGenericRepository<City> _cityRepository;
        private readonly IGenericRepository<Region> _regionRepository;

        public AddressRepository(IGenericRepository<Province> provinceRepository,
                                 IGenericRepository<City> cityRepository,
                                 IGenericRepository<Region> regionRepository)
        {
            _provinceRepository = provinceRepository;
            _cityRepository = cityRepository;
            _regionRepository = regionRepository;
        }
        #endregion

        public async Task<string> GetNameById<T>(int id) 
        {
            if (typeof(T) == typeof(Province))
            {
                var province = await _provinceRepository.GetEntityById(id) as Province;
                return province?.Name ?? "نامشخص";
            }
            if (typeof(T) == typeof(City))
            {
                var city = await _cityRepository.GetEntityById(id) as City;
                return city?.Name ?? "نامشخص";
            }
            if (typeof(T) == typeof(Region))
            {
                var region = await _regionRepository.GetEntityById(id) as Region;
                return region?.Name ?? "نامشخص";
            }

            return "نامشخص";
        }

        #region Province Methods



        public async Task<List<Province>> GetAllProvincesAsync()
        {
            return (await _provinceRepository.GetAllEntitiesAsyncJustForRead()).ToList();
        }

        public async Task<Province?> GetProvinceByIdAsync(int id)
        {
            return await _provinceRepository.GetEntityById(id);
        }

        public async Task<Province> CreateProvinceAsync(Province province)
        {
            return await _provinceRepository.CreateAsync(province);
        }

        public async Task<bool> UpdateProvinceAsync(Province province)
        {
            var existingProvince = await _provinceRepository.GetEntityById(province.Id);
            if (existingProvince == null)
                return false;

            existingProvince.Name = province.Name;
            _provinceRepository.Update(existingProvince);
            await _provinceRepository.SaveChangesAsync();
            return true;
        }
        #endregion

        #region City Methods



        public async Task<List<City>> GetCitiesByProvinceIdAsync(int provinceId)
        {
            return await _cityRepository.GetAllEntitiesAsync()
                .Include(c => c.Province) // 👈 جلوگیری از `null` شدن `Province`
                .Where(c => c.ProvinceId == provinceId)
                .ToListAsync();
        }

        public async Task<List<City>> GetAllCitiesAsync()
        {
            return (await _cityRepository.GetAllEntitiesAsyncJustForRead()).ToList();
        }

        public async Task<City?> GetCityByIdAsync(int id)
        {
            return await _cityRepository.GetEntityById(id);
        }

        public async Task<City> CreateCityAsync(City city)
        {
            return await _cityRepository.CreateAsync(city);
        }

        public async Task<bool> UpdateCityAsync(City city)
        {
            var existingCity = await _cityRepository.GetEntityById(city.Id);
            if (existingCity == null)
                return false;

            existingCity.Name = city.Name;
            existingCity.ProvinceId = city.ProvinceId;
            _cityRepository.Update(existingCity);
            await _cityRepository.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Region Methods



        public async Task<List<Region>> GetRegionByProvinceIdAndCityIdAsync(int provinceId, int cityId)
        {
            var regoins = await _regionRepository.GetAllEntitiesAsync()
                .Include(r => r.Province)
                .Where(p => p.ProvinceId == provinceId)
                .Include(r => r.City)
                .Where(c => c.CityId == cityId).ToListAsync();
            return regoins;
        }

        public async Task<List<Region>> GetAllRegionsAsync()
        {
            return (await _regionRepository.GetAllEntitiesAsyncJustForRead()).ToList();
        }

        public async Task<Region?> GetRegionByIdAsync(int id)
        {
            return await _regionRepository.GetEntityById(id);
        }

        public async Task<Region> CreateRegionAsync(Region region)
        {
            return await _regionRepository.CreateAsync(region);
        }

        public async Task<bool> UpdateRegionAsync(Region region)
        {
            var existingRegion = await _regionRepository.GetEntityById(region.Id);
            if (existingRegion == null)
                return false;

            existingRegion.Name = region.Name;
            existingRegion.CityId = region.CityId;
            _regionRepository.Update(existingRegion);
            await _regionRepository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CheckDuplicateRegionByName(string name, int provinceId, int cityId)
        {
            return await _regionRepository.IsExistEntity
                (r => r.Name == name && r.ProvinceId == provinceId && r.CityId == cityId);

        }



        #endregion
    }
}
