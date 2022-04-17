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

        public async Task<List<User>> GetData()
        {
            var data = await _context.Users.Include(e => e.Person).ThenInclude(e => e.Role)
            .Include(e => e.Person).ThenInclude(e => e.Address).ToListAsync();
            return data;
        }

        public async Task<User> GetDataById(int id)
        {
            return await _context.Users.Include(e => e.Person).ThenInclude(e => e.Role)
            .Include(e => e.Person).ThenInclude(e => e.Address).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> InsertData(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateData(User user)
        {
            _context.Update(user).Property(x => x.Id).IsModified = false;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteData(User user)
        {
            _context.Users.Remove(user);
            _context.Persons.Remove(user.Person);
            await _context.SaveChangesAsync();
            return true;
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