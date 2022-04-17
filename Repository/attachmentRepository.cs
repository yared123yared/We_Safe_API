using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeSafe.Models;

namespace WeSafe.Data
{
    public class AtttachmentRepository : IRepository<Attachment>
    {
        private readonly DataContext _context;
        public AtttachmentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteData(Attachment attachment)
        {
            _context.Attachments.Remove(attachment);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<Attachment> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Attachment>> GetData()
        {
             var data = await _context.Attachments.ToListAsync();
            return data;
        }

        public async Task<Attachment> GetDataById(int id)
        {
            return await _context.Attachments.FirstOrDefaultAsync(x => x.AttachmentId == id);
        }

        public Task<List<Attachment>> GetPaginatedData(int pageNumber, int pageSize, string orderBy, string search)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalPage(int pageSize, string search)
        {
            throw new NotImplementedException();
        }

        public async Task<Attachment> InsertData(Attachment attachment)
        {
               _context.Attachments.Add(attachment);
            await _context.SaveChangesAsync();
            return attachment;
        }

        public async Task<Attachment> UpdateData(Attachment attachment)
        {
               _context.Update(attachment).Property(x => x.AttachmentId).IsModified = false;
            await _context.SaveChangesAsync();
            return attachment;
        }
    }
}
