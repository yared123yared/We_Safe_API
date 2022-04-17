using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeSafe.Models;

namespace WeSafe.Data
{
    public class ReportRepository : IRepository<Report>
    {
        private readonly DataContext _context;
        public ReportRepository(DataContext context)
        {
            _context = context;
        }

        public ReportRepository()
        {
        }

        public async Task<List<Report>> GetData()
        {
            var data = await _context.Reports.ToListAsync();
            return data;
        }

        public async Task<Report> GetDataById(int id)
        {
            return await _context.Reports.FirstOrDefaultAsync(x => x.Id == id);
  
        }

        public async Task<Report> InsertData(Report report)
        {
             _context.Reports.Add(report);
            await _context.SaveChangesAsync();
            return report;
        }

        public async Task<Report> UpdateData(Report service)
        {
            _context.Update(service).Property(x => x.Id).IsModified = false;
            await _context.SaveChangesAsync();
            return service;
        }

        public Task<bool> DeleteData(Report service)
        {
            throw new NotImplementedException();
        }

        public Task<List<Report>> GetPaginatedData(int pageNumber, int pageSize, string orderBy, string search)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalPage(int pageSize, string search)
        {
            throw new NotImplementedException();
        }

        public Task<Report> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}