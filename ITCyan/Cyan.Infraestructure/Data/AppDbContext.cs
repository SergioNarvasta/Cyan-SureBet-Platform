using Cyan.Domain.Entities;
using IS_SureBet.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data
{
    public class AppDbContext : DbContext
    {
        /*
         Add-Migration -Context Infraestructure.Data.AppDbContext -name init_02
         Update-Database -Verbose -Context AppDbContext
         
         Remove-Migration -Context AppDbContext
       */
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        
        public DbSet<BetData> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
