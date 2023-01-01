using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserDemo.Models
{
    public class DemoContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ErrorViewModel> Errors { get; set; }

        public DbSet<Image> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=Demo.db");
    }
}
