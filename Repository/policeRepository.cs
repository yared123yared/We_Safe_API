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

        public Task<List<Police>> GetData()
        {
            throw new NotImplementedException();
        }

        public Task<Police> GetDataById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Police> InsertData(Police service)
        {
            throw new NotImplementedException();
        }

        public Task<Police> UpdateData(Police service)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteData(Police service)
        {
            throw new NotImplementedException();
        }

        public Task<List<Police>> GetPaginatedData(int pageNumber, int pageSize, string orderBy, string search)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalPage(int pageSize, string search)
        {
            throw new NotImplementedException();
        }

        public Task<Police> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        // public PoliceRepository()
        // {
        // }


    }
}