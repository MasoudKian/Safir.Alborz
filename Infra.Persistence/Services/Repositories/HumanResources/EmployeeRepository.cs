using Domain.Entities.HumanResources.EmployeeManagement;
using Domain.Interfaces.Repositories.HumanResources;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Services.Repository;

namespace Persistence.Services.Repositories.HumanResources
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
            var isExistIrCode = await _context.Employees
                .SingleOrDefaultAsync(e => e.IRCode == irCode);
            return isExistIrCode!;
        }

        public async Task<Employee> EmployeeExistsByBirthCertificateNumberAsync(string birthCertificateNumber)
        {
            var isExist = await _context.Employees.SingleOrDefaultAsync(e => e.BirthCertificateNumber == birthCertificateNumber);
            return isExist!;
        }

        public async Task<Employee> EmployeeExistsByMobileAsync(string mobile)
        {
            var isMobileExist = await _context.Employees.SingleOrDefaultAsync(e => e.Mobile == mobile);
            return isMobileExist!;
        }

        public async Task<Employee> EmployeeExistsByEmailAsync(string email)
        {
            var isEmailExist = await _context.Employees.SingleOrDefaultAsync(e => e.Email == email);
            return isEmailExist!;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var employees = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Position)
                .Where(e => !e.IsDelete).ToListAsync();

            return employees;
        }

        public async Task<int> GetTotalEmployeesCount()
        {
            return await _context.Employees.CountAsync();
        }
    }
}
