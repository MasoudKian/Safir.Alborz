using Application.Contracts.InterfaceServices.MSCRM;
using Application.DTOs.MSCRMdto;
using Application.Utils;
using AutoMapper;
using Domain.Entities.Address;
using Domain.Entities.MSCRM;
using Domain.Interfaces.Repositories;

namespace Persistence.Services.ImplementationServices.MSCRM
{
    public class MSCRMService : IMSCRMService
    {
        #region ctor DI

        private readonly IMSCRMRepository _mscrmRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public MSCRMService(IMSCRMRepository mscrmRepository, IMapper mapper
            , IAddressRepository addressRepository)
        {
            _mscrmRepository = mscrmRepository;
            _mapper = mapper;
            _addressRepository = addressRepository;
        }

        #endregion

        public async Task<Marketer> AddMarketer(AddMarketerDTO addMarketerDTO)
        {
            var marketer = _mapper.Map<Marketer>(addMarketerDTO);

            // دریافت نام استان، شهر و منطقه به صورت جنریک
            string provinceName = await _addressRepository.GetNameById<Province>(addMarketerDTO.ProvinceId);
            string cityName = await _addressRepository.GetNameById<City>(addMarketerDTO.CityId);
            string regionName = await _addressRepository.GetNameById<Region>(addMarketerDTO.RegionId);

            // تولید MarketerCode
            marketer.MarketerCode = CodeGeneratorMarketer.GenerateMarketerCode(provinceName, cityName, regionName);

            // ذخیره در دیتابیس
            await _mscrmRepository.CreateMarketer(marketer);

            return marketer;
        }


        public async Task<List<GetListEmployeesForMarketer>> GetListEmployeesCRM()
        {
            var list = await _mscrmRepository.GetListCRMEmployeesAsync(); // نام متد ریپازیتوری اصلاح شد
            var map = _mapper.Map<List<GetListEmployeesForMarketer>>(list); // اصلاح مپینگ

            return map;
        }

    }
}
