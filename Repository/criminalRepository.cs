using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeSafe.Models;

namespace WeSafe.Data
{
    public class CriminalRepository : IRepository<Criminal>
    {
        private readonly DataContext _context;
        public CriminalRepository(DataContext context)
        {
            _context = context;
        }

        public CriminalRepository()
        {
        }

        public async Task<List<Criminal>> GetData()
        {
            var data = await _context.Criminals.Include(e => e.Images).ToListAsync();
            return data;
        }

        public async Task<Criminal> GetDataById(int id)
        {
              return await _context.Criminals.Include(e => e.Images).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Criminal> InsertData(Criminal criminal)
        {
             _context.Criminals.Add(criminal);
            await _context.SaveChangesAsync();
            return criminal;
        }

        public async Task<Criminal> UpdateData(Criminal criminal)
        {
             _context.Update(criminal).Property(x => x.Id).IsModified = false;
            await _context.SaveChangesAsync();
            return criminal;
        }

        public async Task<bool> DeleteData(Criminal criminal)
        {
            _context.Criminals.Remove(criminal);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<List<Criminal>> GetPaginatedData(int pageNumber, int pageSize, string orderBy, string search)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalPage(int pageSize, string search)
        {
            throw new NotImplementedException();
        }

        public Task<Criminal> GetDataByPhone(string email)
        {
            throw new NotImplementedException();
        }

        public Task<List<Criminal>> GetDataByUserId(int id)
        {
            throw new NotImplementedException();
        }
    }
}