using Application.DTOs.Address.CRUD;
using Application.DTOs.Address;
using Application.DTOs.HumanResources.Department;
using Application.DTOs.HumanResources.Employee;
using Application.DTOs.HumanResources.Position;
using AutoMapper;
using Domain.Entities.Address;
using Domain.Entities.HumanResources.EmployeeManagement;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Employee

            CreateMap<Employee, EmployeeListDTO>()
                .ForMember(e => e.EId, el => el.MapFrom(eld => eld.Id))
                .ForMember(e => e.FirstName, el => el.MapFrom(eld => eld.FirstName))
                .ForMember(e => e.LastName, el => el.MapFrom(eld => eld.LastName))
                .ForMember(e => e.IRCode, el => el.MapFrom(eld => eld.IRCode))
                .ForMember(e => e.BirthDate, el => el.MapFrom(eld => eld.BirthDate))
                .ForMember(e => e.BirthCertificateNumber, el => el.MapFrom(eld => eld.BirthCertificateNumber))
                .ForMember(e => e.Mobile, el => el.MapFrom(eld => eld.Mobile))
                .ForMember(e => e.Email, el => el.MapFrom(eld => eld.Email))
                .ForMember(e => e.Address, el => el.MapFrom(eld => eld.Address))
                .ForMember(e => e.RegisteredDate, el => el.MapFrom(eld => eld.RegisteredDate))
                .ForMember(e => e.EmployeeCode, el => el.MapFrom(eld => eld.EmployeeID))
                .ForMember(e => e.ProfileImage, el => el.MapFrom(eld => eld.ImageAddress))
                .ForMember(e => e.Education, el => el.MapFrom(eld => eld.Education))
                .ForMember(e => e.DateOfEmployment, el => el.MapFrom(eld => eld.DateOfEmployment))
                .ForMember(e => e.FamiliarPhone, el => el.MapFrom(eld => eld.FamiliarPhone))
                .ForMember(e => e.IsDelete, el => el.MapFrom(eld => eld.IsDelete))

                .ForMember(e => e.DepartmentId, el => el.MapFrom(eld => eld.DepartmentId))

                .ForMember(e => e.DepartmentName, el => el.MapFrom
                (eld => eld.Department != null ? eld.Department.Name : ""))

                .ForMember(e => e.PositionId, el => el.MapFrom(eld => eld.PositionId))

                .ForMember(e => e.PositionName, el => el.MapFrom
                (eld => eld.Position != null ? eld.Position.Title : ""));


            #endregion

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

            #region Address

            // Province Mapping
            CreateMap<Province, ProvinceDto>().ReverseMap();
            CreateMap<CreateProvinceDto, Province>()
            .ForMember(dest => dest.RegisteredBy, opt => opt.Ignore()) // مقدار را در سرویس مقداردهی می‌کنیم
            .ForMember(dest => dest.RegisteredDate, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(_ => DateTime.UtcNow));

            // City Mapping
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<City, CreateCityDto>().ReverseMap();

            // Region Mapping
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<Region, CreateRegionDto>().ReverseMap();



            #endregion
        }
    }
}
