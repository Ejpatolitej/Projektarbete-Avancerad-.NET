using Microsoft.EntityFrameworkCore;
using Projektarbete_Avancerad_.NET.API.Models;
using Projektarbete_Avancerad_.NET.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projektarbete_Avancerad_.NET.API.Services
{
    public class ProjectRepo : IpaANET<Project>
    {
        private AppDbContext _appDbContext;
        public ProjectRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Project> Add(Project newEntity)
        {
            var result = await _appDbContext.Projects.AddAsync(newEntity);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Project> Delete(int id)
        {
            var result = await _appDbContext.Projects.FirstOrDefaultAsync(p => p.ProjectID == id);
            if (result != null)
            {
                _appDbContext.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _appDbContext.Projects.Include(p => p.Employees).ToListAsync();
        }

        public async Task<Project> GetSingle(int id)
        {
            return await _appDbContext.Projects.Include(p => p.Employees)
                .ThenInclude(p => p.TimeRepEmployees).ThenInclude(p => p.TimeReport)
                .FirstOrDefaultAsync(p => p.ProjectID == id);
        }

        public async Task<Project> Update(Project Entity)
        {
            var result = await _appDbContext.Projects.FirstOrDefaultAsync(p => p.ProjectID == Entity.ProjectID);
            if (result != null)
            {
                result.ProjectName = Entity.ProjectName;

                await _appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
