using Cyan.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data
{
    public class AppDbContext : DbContext
    {
        /*
         Add-Migration -Context Infraestructure.Data.AppDbContext -name init_01
         Update-Database -Verbose -Context AppDbContext
         
         Remove-Migration -Context AppDbContext
       */
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<BetHistory> BetHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
