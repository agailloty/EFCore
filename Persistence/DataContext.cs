using EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Persistence
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connString = "Data Source=appdb.db";
            optionsBuilder.UseSqlite(connString);
        }
        public DbSet<Blog> Post { get; set; }

    }
}