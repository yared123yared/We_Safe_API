using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeSafe.Models;

namespace WeSafe.Data
{
    public class PoliceRepository : IRepository<Police>
    {
        private readonly DataContext _context;
        public PoliceRepository(DataContext context)
        {
            _context = context;
        }

        public PoliceRepository()
        {
        }

        public async Task<List<Police>> GetData()
        {
            var data = await _context.Polices.Include(e => e.Person).ThenInclude(e => e.Role)
            .Include(e => e.Person).ThenInclude(e => e.Address).Include(e => e.Station).ToListAsync();
            return data;
        }

        public async Task<Police> GetDataById(int id)
        {
            return await _context.Polices.Include(e => e.Person).ThenInclude(e => e.Role)
            .Include(e => e.Person).ThenInclude(e => e.Address)
             .Include(e => e.Station).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Police> InsertData(Police police)
        {
            _context.Polices.Add(police);
            await _context.SaveChangesAsync();
            return police;
        }

        public async Task<Police> UpdateData(Police police)
        {
            _context.Update(police).Property(x => x.Id).IsModified = false;
            await _context.SaveChangesAsync();
            return police;
        }

        public async Task<bool> DeleteData(Police police)
        {
            _context.Polices.Remove(police);
            _context.Persons.Remove(police.Person);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<List<Police>> GetPaginatedData(int pageNumber, int pageSize, string orderBy, string search)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalPage(int pageSize, string search)
        {
            throw new NotImplementedException();
        }

        public async Task<Police> GetDataByPhone(string phone)
        {
       return await _context.Polices.Include(e => e.Person).ThenInclude(e => e.Role)
            .Include(e => e.Person).ThenInclude(e => e.Address)
             .Include(e => e.Station).FirstOrDefaultAsync(x => x.Person.Phone == phone);
        }

        // public PoliceRepository()
        // {
        // }


    }
}