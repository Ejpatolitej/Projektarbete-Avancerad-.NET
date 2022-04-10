using Microsoft.EntityFrameworkCore;
using Projektarbete_Avancerad_.NET.API.Models;
using Projektarbete_Avancerad_.NET.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projektarbete_Avancerad_.NET.API.Services
{
    public class TimeReportRepo : IpaANET<TimeReport>
    {
        private AppDbContext _appDbContext;
        public TimeReportRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<TimeReport> Add(TimeReport newEntity)
        {
            var result = await _appDbContext.TimeReports.AddAsync(newEntity);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TimeReport> Delete(int id)
        {
            var result = await _appDbContext.TimeReports.FirstOrDefaultAsync(t => t.TimeReportID == id);
            if (result != null)
            {
                _appDbContext.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<TimeReport>> GetAll()
        {
            return await _appDbContext.TimeReports.ToListAsync();
        }

        public async Task<TimeReport> GetSingle(int id)
        {
            return await _appDbContext.TimeReports.FirstOrDefaultAsync(t => t.TimeReportID == id);
        }

        public async Task<TimeReport> Update(TimeReport Entity)
        {
            var result = await _appDbContext.TimeReports.FirstOrDefaultAsync(t => t.TimeReportID == Entity.TimeReportID);
            if (result != null)
            {
                result.Week = Entity.Week;
                result.HoursWorked = Entity.HoursWorked;

                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
