using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeSafe.Models;

namespace WeSafe.Data
{
    public class RoleRepository : IRepository<Role>
    {
        private readonly DataContext _context;
        public RoleRepository(DataContext context)
        {
            _context = context;
        }

        public RoleRepository()
        {
        }

        public async Task<bool> DeleteData(Role role)
        {
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<Role>> GetData()
        {
            var data = await _context.Roles.ToListAsync();
            return data;
        }

        public async Task<Role> GetDataById(int id)
        {
            return await _context.Roles.FirstOrDefaultAsync(x => x.RoleId == id);
        }
        public async Task<Role> InsertData(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return role;
        }
        public async Task<Role> UpdateData(Role role)
        {
            _context.Update(role).Property(x => x.RoleId).IsModified = false;
            await _context.SaveChangesAsync();
            return role;
        }
        public Task<List<Role>> GetPaginatedData(int pageNumber, int pageSize, string orderBy, string search)
        {
            throw new NotImplementedException();
        }
        public Task<Role> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }
        public Task<int> GetTotalPage(int pageSize, string search)
        {
            throw new NotImplementedException();
        }




    }
}
