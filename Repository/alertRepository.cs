using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeSafe.Models;

namespace WeSafe.Data
{
    public class AlertRepository : IRepository<Alert>
    {
        private readonly DataContext _context;
        public AlertRepository(DataContext context)
        {
            _context = context;
        }

        public AlertRepository()
        {
        }

        public async Task<List<Alert>> GetData()
        {
             var data = await _context.Alerts.Include(e=>e.AlertedBy).ToListAsync();
            return data;
        }

        public async Task<Alert> GetDataById(int id)
        {
            return await _context.Alerts.Include(e=>e.AlertedBy).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Alert> InsertData(Alert alert)
        {
             _context.Alerts.Add(alert);
            await _context.SaveChangesAsync();
            return alert;
        }

        public async Task<Alert> UpdateData(Alert alert)
        {
             _context.Update(alert).Property(x => x.Id).IsModified = false;
            await _context.SaveChangesAsync();
            return alert;
        }

        public async Task<bool> DeleteData(Alert alert)
        {
             _context.Alerts.Remove(alert);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<List<Alert>> GetPaginatedData(int pageNumber, int pageSize, string orderBy, string search)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalPage(int pageSize, string search)
        {
            throw new NotImplementedException();
        }

        public Task<Alert> GetDataByPhone(string email)
        {
            throw new NotImplementedException();
        }
    }
}
