using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.data
{
    class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Specify the connection string
            optionsBuilder.UseSqlite("YourConnectionString");
        }
        public DbSet<User> Users { get; set; }
    }
}
