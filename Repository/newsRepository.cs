using System.Collections.Generic;
using System.Device.Location;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeSafe.Models;

namespace WeSafe.Data
{
    public class NewsRepository : IRepository<News>
    {
        private readonly DataContext _context;
        public NewsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteData(News news)
        {
            _context.News.Remove(news);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<News>> GetData()
        {
            var data = await _context.News.ToListAsync();
            return data;
        }

        public async Task<News> GetDataById(int id)
        {
            return await _context.News.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<News> GetDataByPhone(string email)
        {
            throw new NotImplementedException();
        }

        public Task<List<News>> GetPaginatedData(int pageNumber, int pageSize, string orderBy, string search)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalPage(int pageSize, string search)
        {
            throw new NotImplementedException();
        }

        public async Task<News> InsertData(News news)
        {
            _context.News.Add(news);
            await _context.SaveChangesAsync();
            return news;
        }

        public async Task<News> UpdateData(News news)
        {
            _context.News.Update(news).Property(x => x.Id).IsModified = false;
            await _context.SaveChangesAsync();
            return news;
        }
        public async Task<List<News>> GetNearestNews(double Latitude, double Longtiude)
        {
            List<News> data = await _context.News.ToListAsync();
            foreach (var news in data)
            {
                var firstCordinate = new GeoCoordinate(Latitude, Longtiude);
                var secondCordinate = new GeoCoordinate(news.Latitude, news.Longtiude);

                double distance = firstCordinate.GetDistanceTo(secondCordinate);
                news.Distance = distance;

            }
            data = (List<News>)data.OrderBy(s => s.Distance);
            return data;
        }

        public Task<List<News>> GetDataByUserId(int id)
        {
            throw new NotImplementedException();
        }
    }
}