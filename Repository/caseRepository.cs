using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeSafe.Models;

namespace WeSafe.Data
{
    public class CaseRepository : IRepository<Case>
    {
        private readonly DataContext _context;
        public CaseRepository(DataContext context)
        {
            _context = context;
        }

        public CaseRepository()
        {
        }

        public async Task<List<Case>> GetData()
        {
            var data = await _context.Cases
           .Include(e => e.AssignedPolice)
           .Include(e => e.ReporterAdmin)
            .Include(e => e.Evidence)
           .ToListAsync();
            return data;
        }

        public async Task<Case> GetDataById(int id)
        {
             return await _context.Cases.Include(e => e.AssignedPolice)
           .Include(e => e.ReporterAdmin)
            .Include(e => e.Evidence).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Case> InsertData(Case cases)
        {
            _context.Cases.Add(cases);
            await _context.SaveChangesAsync();
            return cases;
        }

        public async Task<Case> UpdateData(Case cases)
        {
          _context.Cases.Update(cases).Property(x => x.Id).IsModified = false;
            await _context.SaveChangesAsync();
            return cases;
        }

        public async Task<bool> DeleteData(Case cases)
        {
             _context.Cases.Remove(cases);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<List<Case>> GetPaginatedData(int pageNumber, int pageSize, string orderBy, string search)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalPage(int pageSize, string search)
        {
            throw new NotImplementedException();
        }

        public Task<Case> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}