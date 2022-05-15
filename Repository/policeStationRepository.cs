using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeSafe.Models;

namespace WeSafe.Data
{
    public class StationRepository : IRepository<Station>
    {
        private readonly DataContext _context;
        public StationRepository(DataContext context)
        {
            _context = context;
        }

        public StationRepository()
        {
        }

        public async Task<List<Station>> GetData()
        {
            var data = await _context.Stations.ToListAsync();
            return data;
        }

        public async Task<Station> GetDataById(int id)
        {
            return await _context.Stations.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Station> InsertData(Station policeStation)
        {
            _context.Stations.Add(policeStation);
            await _context.SaveChangesAsync();
            return policeStation;
        }

        public async Task<Station> UpdateData(Station policeStation)
        {   
            Console.WriteLine("Entered to the Update repo");
            _context.Stations.Update(policeStation).Property(x => x.Id).IsModified = false;
            await _context.SaveChangesAsync();
            Console.WriteLine("finished updating");
            return policeStation;
        }

        public async Task<bool> DeleteData(Station policeStation)
        {
            _context.Stations.Remove(policeStation);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<List<Station>> GetPaginatedData(int pageNumber, int pageSize, string orderBy, string search)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalPage(int pageSize, string search)
        {
            throw new NotImplementedException();
        }

        public Task<Station> GetDataByPhone(string email)
        {
            throw new NotImplementedException();
        }

        // public PoliceStationRepository()
        // {
        // }


    }
}