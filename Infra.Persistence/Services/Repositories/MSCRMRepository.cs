﻿using Domain.Entities.HumanResources.EmployeeManagement;
using Domain.Entities.MSCRM;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services.Repositories
{
    public class MSCRMRepository : IMSCRMRepository
    {
        #region ctor DI

        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IGenericRepository<Marketer> _marketerRepository;

        public MSCRMRepository(IGenericRepository<Employee> employeeRepository
            , IGenericRepository<Marketer> marketerRepository)
        {
            _employeeRepository = employeeRepository;
            _marketerRepository = marketerRepository;
        }

        public async Task<Marketer> CreateMarketer(Marketer marketer)
        {
            return await _marketerRepository.CreateAsync(marketer);
        }

        public async Task<Marketer?> GetMarketerById(int id)
        {
            var marketers = await _marketerRepository
                .GetAllEntitiesAsync()
                .ToListAsync(); // ابتدا تمام رکوردها را واکشی کنید

            return marketers.SingleOrDefault(m => m.EmployeeId == id);
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
