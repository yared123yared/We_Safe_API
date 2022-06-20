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

        public async Task<bool> DeleteData(Report report)
        {
            _context.Reports.Remove(report);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<Report> GetDataByPhone(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Report>> GetData()
        {
            var data = await _context.Reports
            .Include(e=>e.ReportedBy).ThenInclude(e=>e.Person).ThenInclude(e=>e.Role)
            .Include(e=>e.ReportedBy).ThenInclude(e=>e.Person).ThenInclude(e=>e.Address)
            .Include(e=>e.Evidence).ThenInclude(e=>e.Attachment).ToListAsync();
            return data;
        }

        public async Task<Report> GetDataById(int id)
        {
          return await _context.Reports.Include(e=>e.ReportedBy).ThenInclude(e=>e.Person).ThenInclude(e=>e.Role)
            .Include(e=>e.ReportedBy).ThenInclude(e=>e.Person).ThenInclude(e=>e.Address)
            .Include(e=>e.Evidence).ThenInclude(e=>e.Attachment).FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<Report>> GetPaginatedData(int pageNumber, int pageSize, string orderBy, string search)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalPage(int pageSize, string search)
        {
            throw new NotImplementedException();
        }

        public async Task<Report> InsertData(Report report)
        {
              _context.Reports.Add(report);
            await _context.SaveChangesAsync();
            return report;
        }

        public async Task<Report> UpdateData(Report report)
        {
              _context.Update(report).Property(x => x.Id).IsModified = false;
            await _context.SaveChangesAsync();
            return report;
        }

        public async Task<List<Report>> GetDataByUserId(int id)
        {
          var data = await _context.Reports
            .Include(e=>e.ReportedBy).ThenInclude(e=>e.Person).ThenInclude(e=>e.Role)
            .Include(e=>e.ReportedBy).ThenInclude(e=>e.Person).ThenInclude(e=>e.Address)
            .Include(e=>e.Evidence).ThenInclude(e=>e.Attachment).ToListAsync();
            data=data.Where(e=>e.UserId==id).ToList();
            return data;
        }
    }
}