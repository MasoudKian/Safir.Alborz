using Application.Contracts.Interfaces.Repositories;
using Application.Contracts.Interfaces.Repositories.HumanResources;
using Application.Contracts.InterfaceServices.MSCRM;
using Application.DTOs.MSCRMdto;
using AutoMapper;

namespace Persistence.Services.ImplementationServices.MSCRM
{
    public class MSCRMService : IMSCRMService
    {
        #region ctor DI

        private readonly IMSCRMRepository _mscrmRepository;
        private readonly IMapper _mapper;

        public MSCRMService(IMSCRMRepository mscrmRepository, IMapper mapper)
        {
            _mscrmRepository = mscrmRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task<List<GetListEmployeesForMarketer>> GetListEmployeesCRM()
        {
            var list = await _mscrmRepository.GetListCRMEmployeesAsync(); // نام متد ریپازیتوری اصلاح شد
            var map = _mapper.Map<List<GetListEmployeesForMarketer>>(list); // اصلاح مپینگ

            return map;
        }

    }
}
