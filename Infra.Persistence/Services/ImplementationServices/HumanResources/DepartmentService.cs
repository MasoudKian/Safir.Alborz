using Application.Contracts.Interfaces.Repositories.HumanResources;
using Application.Contracts.InterfaceServices.HumanResources;
using Application.DTOs.HumanResources.Department;
using AutoMapper;
using Domain.Entities.HumanResources.EmployeeManagement;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services.ImplementationServices.HumanResources
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
            return departments;
        }

        public async Task<GetDepartmentDTO> GetDepartmentByIdAsync(int id)
        {
            var dep = await _departmentRepository.GetByIdAsync(id);
            return new GetDepartmentDTO
            {
                DepartmentId = dep.Id,
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
