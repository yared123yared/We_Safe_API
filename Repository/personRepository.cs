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
            var data = await _context.Persons
            .Include(e=>e.Role)
            .Include(e=>e.Address)
            .ToListAsync();
            return data;
        }

        public async Task<Person> GetDataById(int id)
        {
             return await _context.Persons.Include(e=>e.Role)
            .Include(e=>e.Address).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Person> InsertData(Person person)
        {
             _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public Task<Person> UpdateData(Person service)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteData(Person person)
        {
              _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return true;
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