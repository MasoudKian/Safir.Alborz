using Application.Contracts.Interfaces.Repositories;
using Application.Contracts.InterfaceServices;
using Application.DTOs.HumanResources.Department;
using AutoMapper;
using Domain.Entities.HumanResources.EmployeeManagement;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services.ImplementationServices
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

        /// <summary>
        /// ثبت بخش سازمان
        /// </summary>
        /// <param name="addDepartment"></param>
        /// <param name="currentUser"></param>
        /// <returns></returns>
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
