using Microsoft.EntityFrameworkCore;
using Projektarbete_Avancerad_.NET.API.Models;
using Projektarbete_Avancerad_.NET.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projektarbete_Avancerad_.NET.API.Services
{
    public class TimeRepEmpRepo : IpaANET<TimeRepEmployee>
    {
        private AppDbContext _appDbContext;
        public TimeRepEmpRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<TimeRepEmployee> Add(TimeRepEmployee newEntity)
        {
            var result = await _appDbContext.TimeRepEmployees.AddAsync(newEntity);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TimeRepEmployee> Delete(int id)
        {
            var result = await _appDbContext.TimeRepEmployees.FirstOrDefaultAsync(t => t.TimeRepEmployeeID == id);
            if (result != null)
            {
                _appDbContext.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<TimeRepEmployee>> GetAll()
        {
            return await _appDbContext.TimeRepEmployees.ToListAsync();
        }

        public async Task<TimeRepEmployee> GetSingle(int id)
        {
            return await _appDbContext.TimeRepEmployees.FirstOrDefaultAsync(t => t.TimeRepEmployeeID == id);
        }

        public async Task<TimeRepEmployee> Update(TimeRepEmployee Entity)
        {
            var result = await _appDbContext.TimeRepEmployees.FirstOrDefaultAsync(t => t.TimeRepEmployeeID == Entity.TimeRepEmployeeID);
            if (result != null)
            {
                result.EmployeeID = Entity.EmployeeID;
                result.TimeReportID = Entity.TimeReportID;

                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
