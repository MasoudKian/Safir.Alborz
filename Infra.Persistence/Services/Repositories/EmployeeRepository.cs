using Application.Contracts.Interfaces.Repositories;
using Domain.Entities.HumanResources.EmployeeManagement;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Services.Repository;

namespace Persistence.Services.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly SafirDbContext _context;
        public EmployeeRepository(SafirDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Employee> GetEmployeeByIrCodeAsync(string irCode)
        {
            var employee = await _context.Employees
                .SingleOrDefaultAsync(e => e.IRCode == irCode);
            return employee;
        }
    }
}
