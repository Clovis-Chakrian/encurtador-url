using Microsoft.AspNetCore.Mvc;

namespace UrlShortener.Models
{
    public class Url
    {
        public int id { get; set; }
        public string url { get; set; }
        public string shortenerUrl { get; set; }
    }
}