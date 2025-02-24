
using Application.Contracts.InterfaceServices.HumanResources;
using Application.DTOs.HumanResources.Department;
using AutoMapper;
using Domain.Entities.HumanResources.EmployeeManagement;
using Domain.Interfaces.Repositories.HumanResources;
using Microsoft.EntityFrameworkCore;

namespace Application.Contracts.Services.ImplementationServices.HumanResources
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<bool> DepartmentExistsAsync(string name)
        {
            return await _departmentRepository.DepartmentExistsAsync(name);
        }

        public async Task<List<DepartmentListDTO>> GetAllDepartmentsAsync()
        {
            var departments = await _departmentRepository.GetAllAsync();

            var dto = departments.Select(d => new DepartmentListDTO
            {
                Id = d.Id,
                Name = d.Name,
                EmployeeCount = d.Employees.Count(),
                RegisteredDate = d.RegisteredDate,
            }).ToList();

            return dto;
        }


        public async Task<GetDepartmentDTO> GetDepartmentByIdAsync(int id)
        {
            var dep = await _departmentRepository.GetByIdAsync(id);
            return new GetDepartmentDTO
            {
                DepartmentId = dep!.Id,
                DepartmentName = dep.Name,
            };
        }

        public async Task<AddDepartmentResult> AddDepartment(AddDepartmentDTO addDepartment)
        {

            if (string.IsNullOrWhiteSpace(addDepartment.Name))
                return AddDepartmentResult.Failure;


            var department = _mapper.Map<Department>(addDepartment);

            department.RegisteredDate = DateTime.UtcNow;
            department.UpdateDate = DateTime.UtcNow;



            await _departmentRepository.AddAsync(department);
            return AddDepartmentResult.Success;


        }

    }
}
