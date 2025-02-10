using Application.DTOs.HumanResources.Department;
using AutoMapper;
using Domain.Entities.HumanResources.EmployeeManagement;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Department

            CreateMap<Department,AddDepartmentDTO>().ReverseMap();

            #endregion
        }
    }
}
