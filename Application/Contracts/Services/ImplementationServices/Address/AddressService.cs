using Application.Contracts.InterfaceServices.Address;
using Application.DTOs.Address;
using Application.DTOs.Address.CRUD;
using Application.Utils;
using AutoMapper;
using Domain.Entities.Address;
using Domain.Interfaces.Repositories;

namespace Application.Contracts.Services.ImplementationServices.Address
{
    public class AddressService : IAddressService
    {
        #region ctor DI

        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressService(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        #endregion

        #region Province Methods

        /// <summary>
        /// ثبت استان 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<ProvinceDto> CreateProvinceAsync(CreateProvinceDto dto, string currentUser)
        {
            var province = _mapper.Map<Province>(dto);
            province.RegisteredBy = currentUser; // مقداردهی بعد از Map کردن
            province.IsDelete = false;

            province = await _addressRepository.CreateProvinceAsync(province);
            return _mapper.Map<ProvinceDto>(province);
        }


        /// <summary>
        /// لیست تمامی استان ها
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProvinceDto>> GetAllProvincesAsync()
        {
            var provinces = await _addressRepository.GetAllProvincesAsync();
            return _mapper.Map<List<ProvinceDto>>(provinces);
        }

        /// <summary>
        ///  یک استان
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProvinceDto?> GetProvinceByIdAsync(int id)
        {
            var province = await _addressRepository.GetProvinceByIdAsync(id);
            return _mapper.Map<ProvinceDto>(province);
        }
        

        /// <summary>
        /// ویرایش استان
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> UpdateProvinceAsync(ProvinceDto dto)
        {
            var existingProvince = await _addressRepository.GetProvinceByIdAsync(dto.Id);
            if (existingProvince == null)
                return false;

            _mapper.Map(dto, existingProvince);
            return await _addressRepository.UpdateProvinceAsync(existingProvince);
        }
        #endregion

        #region City Methods

        public async Task<List<CityDto>> GetCitiesByProvinceIdAsync(int provinceId)
        {
            var cities = await _addressRepository.GetCitiesByProvinceIdAsync(provinceId);
            return _mapper.Map<List<CityDto>>(cities);
        }



        /// <summary>
        /// ثبت شهر
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<CityDto> CreateCityAsync(CreateCityDto dto)
        {
            var city = _mapper.Map<City>(dto);
            city = await _addressRepository.CreateCityAsync(city);
            return _mapper.Map<CityDto>(city);
        }

        /// <summary>
        /// لیست شهرها
        /// </summary>
        /// <returns></returns>
        public async Task<List<CityDto>> GetAllCitiesAsync()
        {
            var cities = await _addressRepository.GetAllCitiesAsync();
            return _mapper.Map<List<CityDto>>(cities);
        }

        /// <summary>
        /// یک شهر
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CityDto?> GetCityByIdAsync(int id)
        {
            var city = await _addressRepository.GetCityByIdAsync(id);
            return _mapper.Map<CityDto>(city);
        }

        /// <summary>
        /// ویرایش شهر
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> UpdateCityAsync(CityDto dto)
        {
            var existingCity = await _addressRepository.GetCityByIdAsync(dto.Id);
            if (existingCity == null)
                return false;

            _mapper.Map(dto, existingCity);
            return await _addressRepository.UpdateCityAsync(existingCity);
        }
        #endregion

        #region Region Methods

        public async Task<List<RegionDto>> GetListRegionsByProvincesAndCity(int provinceId, int cityId)
        {
            var regions = await _addressRepository.GetRegionByProvinceIdAndCityIdAsync(provinceId, cityId);
            return _mapper.Map<List<RegionDto>>(regions);
        }

        /// <summary>
        /// ثبت یک منطقه 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        //public async Task<RegionDto> CreateRegionAsync(CreateRegionDto dto)
        //{
        //    var region = _mapper.Map<Region>(dto);
        //    region = await _addressRepository.CreateRegionAsync(region);
        //    return _mapper.Map<RegionDto>(region);
        //}
        public async Task CreateRegionAsync(CreateRegionDto dto)
        {
            var region = _mapper.Map<Region>(dto);

            // مقداردهی فیلد Code بر اساس نام منطقه
            region.Code = CodeGeneratorRegion.GenerateRegionCode(region.Name);

            await _addressRepository.CreateRegionAsync(region);
        }


        /// <summary>
        /// لیست تمام بخش ها
        /// </summary>
        /// <returns></returns>
        public async Task<List<RegionDto>> GetAllRegionsAsync()
        {
            var regions = await _addressRepository.GetAllRegionsAsync();
            return _mapper.Map<List<RegionDto>>(regions);
        }

        /// <summary>
        /// یک بخش
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<RegionDto?> GetRegionByIdAsync(int id)
        {
            var region = await _addressRepository.GetRegionByIdAsync(id);
            return _mapper.Map<RegionDto>(region);
        }

        /// <summary>
        /// ویرایش بخش
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> UpdateRegionAsync(RegionDto dto)
        {
            var existingRegion = await _addressRepository.GetRegionByIdAsync(dto.Id);
            if (existingRegion == null)
                return false;

            _mapper.Map(dto, existingRegion);
            return await _addressRepository.UpdateRegionAsync(existingRegion);
        }

        /// <summary>
        /// بررسی تکراری بودن منطقه
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> CheckDuplicateRegionName(CheckRegion dto)
        {
            var region = _mapper.Map<CheckRegion>(dto);

            var existRegion = await _addressRepository.CheckDuplicateRegionByName(region.Name);
            if (existRegion == null) return false;

            return true;
        }
        #endregion
    }
}
