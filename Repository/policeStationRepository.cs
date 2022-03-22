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

        public Task<List<PoliceStation>> GetData()
        {
            throw new NotImplementedException();
        }

        public Task<PoliceStation> GetDataById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PoliceStation> InsertData(PoliceStation service)
        {
            throw new NotImplementedException();
        }

        public Task<PoliceStation> UpdateData(PoliceStation service)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteData(PoliceStation service)
        {
            throw new NotImplementedException();
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