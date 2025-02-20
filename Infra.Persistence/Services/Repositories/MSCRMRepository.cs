using Application.Contracts.Interfaces.IGeneric;
using Application.Contracts.Interfaces.Repositories;
using Domain.Entities.HumanResources.EmployeeManagement;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services.Repositories
{
    public class MSCRMRepository : IMSCRMRepository
    {
        #region ctor DI

        private readonly IGenericRepository<Employee> _employeeRepository;

        public MSCRMRepository(IGenericRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        #endregion
        public async Task<List<Employee>> GetListCRMEmployeesAsync()
        {
            return await _employeeRepository
                .GetAllEntitiesAsync()
                .Where(e => e.EmployeeID.StartsWith("CRM"))
                .ToListAsync();
        }

    }
}
