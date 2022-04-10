using Microsoft.EntityFrameworkCore;
using Projektarbete_Avancerad_.NET.API.Models;
using Projektarbete_Avancerad_.NET.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projektarbete_Avancerad_.NET.API.Services
{
    public class EmployeeRepo : IpaANET<Employee>
    {
        private AppDbContext _appDbContext;
        public EmployeeRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Employee> Add(Employee newEntity)
        {
            var result = await _appDbContext.Employees.AddAsync(newEntity);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> Delete(int id)
        {
            var result = await _appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeID == id);
            if (result != null)
            {
                _appDbContext.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _appDbContext.Employees.Include(e => e.Project).ToListAsync();
        }

        public async Task<Employee> GetSingle(int id)
        {
            return await _appDbContext.Employees.Include(e => e.Project)
                .Include(e => e.TimeRepEmployees)
                .ThenInclude(e => e.TimeReport)
                .FirstOrDefaultAsync(e => e.EmployeeID == id);
        }

        public async Task<Employee> Update(Employee Entity)
        {
            var result = await _appDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeID == Entity.EmployeeID);
            if (result != null)
            {
                result.FirstName = Entity.FirstName;
                result.LastName = Entity.LastName;
                result.Email = Entity.Email;
                result.Phone = Entity.Phone;
                result.ProjectID = Entity.ProjectID;

                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
