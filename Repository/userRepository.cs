using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeSafe.Models;

namespace WeSafe.Data
{
    public class UserRepository : IRepository<User>
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public UserRepository()
        {
        }

        public Task<List<User>> GetData()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetDataById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> InsertData(User service)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateData(User service)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteData(User service)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetPaginatedData(int pageNumber, int pageSize, string orderBy, string search)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalPage(int pageSize, string search)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        // public UserRepository()
        // {
        // }


    }
}