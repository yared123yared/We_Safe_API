using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeSafe.Models;

namespace WeSafe.Data
{
    public class PersonRepository : IRepository<Person>
    {
        private readonly DataContext _context;
        public PersonRepository(DataContext context)
        {
            _context = context;
        }

        public PersonRepository()
        {
        }

        public async Task<List<Person>> GetData()
        {
            var data = await _context.Persons.Include(e=>e.Role).ToListAsync();
            return data;
        }

        public Task<Person> GetDataById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Person> InsertData(Person service)
        {
            throw new NotImplementedException();
        }

        public Task<Person> UpdateData(Person service)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteData(Person service)
        {
            throw new NotImplementedException();
        }

        public Task<List<Person>> GetPaginatedData(int pageNumber, int pageSize, string orderBy, string search)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalPage(int pageSize, string search)
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}