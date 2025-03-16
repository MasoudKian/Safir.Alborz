using Domain.Entities.HumanResources.EmployeeManagement;
using Domain.Interfaces.Repositories.HumanResources;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Services.Repository;

namespace Persistence.Services.Repositories.HumanResources
{
    public class EmployeeRepository(SafirDbContext context) : GenericRepository<Employee>(context)
        , IEmployeeRepository
    {
        private readonly SafirDbContext _context = context;


        public async Task<Employee> GetEmployeeByCode(string code)
        {
            var result = await _context.Employees.Where(e=>e.EmployeeID == code)
                .Include(p=>p.Position)
                .Include(d=>d.Department)
                .SingleOrDefaultAsync();
            return result!;
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

        public async Task<int> GetTotalEmployeesCount()
        {
            return await _context.Employees.CountAsync();
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var employees = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Position)
                .Where(e => !e.IsDelete).ToListAsync();

            return employees;
        }        
        public async Task<List<Employee>> GetAllDeactiveEmployees()
        {
            var employees = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Position)
                .Where(e => e.IsDelete).ToListAsync();

            return employees;
        }

        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            var employee = await _context.Employees.Where(e => e.Id == employeeId).FirstOrDefaultAsync();

            return employee!;
        }

        public async Task<bool> DeactiveEmployee(int employeeId,string currentUser)
        {
            var existEmployee = await GetEmployeeById(employeeId);
            if (existEmployee == null) return false;    

            existEmployee.IsDelete = true;
            existEmployee.UpdateDate = DateTime.Now;
            existEmployee.LastModifiedBy = currentUser;

            _context.SaveChanges();
            

            return true;
        }
    }
}
