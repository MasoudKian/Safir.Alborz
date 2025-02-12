using Application.DTOs.HumanResources.Department;
using Application.DTOs.HumanResources.Position;
using AutoMapper;
using Domain.Entities.HumanResources.EmployeeManagement;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Department

            CreateMap<AddDepartmentDTO,Department>().ReverseMap();

            #endregion

            #region Position

            CreateMap<CreateOrUpdatePositionDTO, Position>().ReverseMap();

            // اصلاح Mapping برای نمایش نام دپارتمان
            CreateMap<Position, PositionListDTO>()
                .ForMember(dest => dest.PositionId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.RegisteredDate))
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom
                (src => src.Department != null ? src.Department.Name : ""));

            #endregion
        }
    }
}
