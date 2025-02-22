using Application.Contracts.InterfaceServices.HumanResources;
using Application.DTOs.HumanResources.Position;
using AutoMapper;
using Domain.Entities.HumanResources.EmployeeManagement;
using Domain.Interfaces.Repositories.HumanResources;

namespace Application.Contracts.Services.ImplementationServices.HumanResources
{
    public class PositionService : IPositionService
    {
        #region ctor DI

        private readonly IPositionRepository _positionRepository;
        private readonly IMapper _mapper;

        public PositionService(IPositionRepository positionRepository, IMapper maapper)
        {
            _positionRepository = positionRepository;
            _mapper = maapper;
        }

        #endregion
        public async Task<PositionResult> AddPositionAsync(CreateOrUpdatePositionDTO position)
        {
            var positionExist =  await PositionExistAsync(position.Title);
            if (positionExist) return PositionResult.IsThere;

            var pos = _mapper.Map<Position>(position);

            pos.RegisteredDate = DateTime.Now;
            pos.UpdateDate = DateTime.Now;

            await _positionRepository.AddPosiitionAsync(pos); 

            return PositionResult.Success;

        }

        public async Task<List<PositionListDTO>> GetAllPositionAsync()
        {
            var positions = await _positionRepository.GetAllAsync();
            var positionDtos = _mapper.Map<List<PositionListDTO>>(positions);
            return positionDtos;
        }

        public async Task<bool> PositionExistAsync(string positionName)
        {
            return await _positionRepository.PositionExistAsync(positionName);
        }
    }
}
