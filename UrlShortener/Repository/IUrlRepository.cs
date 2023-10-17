
using UrlShortener.Models;

namespace UrlShortener.Repository
{
    public interface IUrlRepository
    {
        Task<IEnumerable<Url>> SearchUrls();
        Task<Url> SearchUrl(int id);
        void AddUrl(Url url);
        void UpdateUrl(Url url);
        void DeleteUrl(Url url);
        Task<bool> SaveChangesAsync();
    }
}