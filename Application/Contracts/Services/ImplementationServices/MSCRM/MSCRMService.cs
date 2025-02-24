using Application.Contracts.InterfaceServices.MSCRM;
using Application.DTOs.MSCRMdto;
using Application.Utils;
using AutoMapper;
using Domain.Entities.Address;
using Domain.Entities.MSCRM;
using Domain.Enums;
using Domain.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Application.Contracts.Services.ImplementationServices.MSCRM
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

        public async Task<bool> CheckMarketerExists(int marketerId)
        {
            var marketer = await _mscrmRepository.GetMarketerById(marketerId);
            return marketer != null; // اگر مقدار نال نبود، یعنی این بازاریاب وجود دارد
        }


        public async Task<ValidationsResult> AddMarketer(AddMarketerDTO addMarketerDTO
            , string currentUser)
        {
            var marketer = _mapper.Map<Marketer>(addMarketerDTO);

            // دریافت نام استان، شهر و منطقه به صورت جنریک
            string provinceName = await _addressRepository.GetNameById<Province>(addMarketerDTO.ProvinceId);
            string cityName = await _addressRepository.GetNameById<City>(addMarketerDTO.CityId);
            string regionName = await _addressRepository.GetNameById<Region>(addMarketerDTO.RegionId);

            // تولید MarketerCode
            marketer.MarketerCode = CodeGeneratorMarketer.GenerateMarketerCode(provinceName, cityName, regionName);
            marketer.RegisteredBy = currentUser;

            // ذخیره در دیتابیس
            await _mscrmRepository.CreateMarketer(marketer);

            return ValidationsResult.Success;
        }


        public async Task<List<GetListEmployeesForMarketer>> GetListEmployeesCRM()
        {
            var list = await _mscrmRepository.GetListCRMEmployeesAsync(); // نام متد ریپازیتوری اصلاح شد
            var map = _mapper.Map<List<GetListEmployeesForMarketer>>(list); // اصلاح مپینگ

            return map;
        }

    }
}
