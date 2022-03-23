using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeSafe.Models;

namespace WeSafe.Data
{
    public class PoliceStationRepository : IRepository<PoliceStation>
    {
        private readonly DataContext _context;
        public PoliceStationRepository(DataContext context)
        {
            _context = context;
        }

        public PoliceStationRepository()
        {
        }

        public async Task<List<PoliceStation>> GetData()
        {
           var data = await _context.PoliceStations.ToListAsync();
            return data;
        }

        public async Task<PoliceStation> GetDataById(int id)
        {
            return await _context.PoliceStations.FirstOrDefaultAsync(x => x.PoliceStationId == id);
        }

        public async Task<PoliceStation> InsertData(PoliceStation policeStation)
        {
            _context.PoliceStations.Add(policeStation);
            await _context.SaveChangesAsync();
            return policeStation;
        }

        public async Task<PoliceStation> UpdateData(PoliceStation policeStation)
        {
            _context.PoliceStations.Update(policeStation).Property(x => x.PoliceStationId).IsModified = false;
            await _context.SaveChangesAsync();
            return policeStation;
        }

        public async Task<bool> DeleteData(PoliceStation policeStation)
        {
          _context.PoliceStations.Remove(policeStation);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<List<PoliceStation>> GetPaginatedData(int pageNumber, int pageSize, string orderBy, string search)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalPage(int pageSize, string search)
        {
            throw new NotImplementedException();
        }

        public Task<PoliceStation> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        // public PoliceStationRepository()
        // {
        // }


    }
}