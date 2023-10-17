using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Data;
using UrlShortener.Models;
using Microsoft.EntityFrameworkCore;

namespace UrlShortener.Repository
{
    public class UrlRepository : IUrlRepository
    {
        private readonly UrlContext _context;
        public UrlRepository(UrlContext context)
        {
            _context = context;
        }
        public void AddUrl(Url url)
        {
            _context.Add(url);
        }

        public void DeleteUrl(Url url)
        {
            _context.Remove(url);
        }

        public void UpdateUrl(Url url)
        {
            _context.Update(url);
        }

        public async Task<Url> SearchUrl(int id)
        {
            return await _context.Urls.Where(x => x.id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Url>> SearchUrls()
        {
            return await _context.Urls.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    }
}