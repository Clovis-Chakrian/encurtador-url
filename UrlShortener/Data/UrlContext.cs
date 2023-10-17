using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Models;

namespace UrlShortener.Data
{
    public class UrlContext : DbContext
    {
        public UrlContext(DbContextOptions<UrlContext> options) : base(options)
        {
        }

        public DbSet<Url> Urls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var url = modelBuilder.Entity<Url>();
            url.ToTable("urls");
            url.HasKey(x => x.id);
            url.Property(x => x.id).HasColumnName("id").ValueGeneratedOnAdd();
            url.Property(x => x.shortenerUrl).HasColumnName("short_url");
            base.OnModelCreating(modelBuilder);
        }
    }
}