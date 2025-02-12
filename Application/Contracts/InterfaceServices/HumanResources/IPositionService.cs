using Application.DTOs.HumanResources.Position;

namespace Application.Contracts.InterfaceServices.HumanResources
{
    public interface IPositionService
    {
        Task<PositionResult> AddPositionAsync (CreateOrUpdatePositionDTO position);
        Task<bool> PositionExistAsync(string positionName);

        Task<List<PositionListDTO>> GetAllPositionAsync();
    }
}
