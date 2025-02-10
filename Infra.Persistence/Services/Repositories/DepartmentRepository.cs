using Application.Contracts.Interfaces.Repositories;
using Domain.Entities.HumanResources.EmployeeManagement;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Services.Repository;

namespace Persistence.Services.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>,IDepartmentRepository
    {
        private readonly SafirDbContext _context;
        public DepartmentRepository(SafirDbContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// ثبت در دیتابیس
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public async Task AddAsync(Department department)
        {
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
        }

        public async Task<Department?> GetByIdAsync(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task<bool> DepartmentExistsAsync(string departmentName)
        {
            return await _context.Departments.AnyAsync(d => d.Name == departmentName);
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _context.Departments.Where(d=>!d.IsDelete).ToListAsync();
        }
    }
}
