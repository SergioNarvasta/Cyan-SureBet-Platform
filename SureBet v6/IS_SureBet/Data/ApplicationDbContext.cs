using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IS_SureBet.Models;

namespace IS_SureBet.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          optionsBuilder.UseSqlServer("Server=DESKTOP-2NA2N4M\\SQLEXPRESS;Database=IS_SureBet;Trusted_Connection=true; MultipleActiveResultSets=true;");
        }
        public DbSet<IS_SureBet.Models.BetData>? BetData { get; set; }
    }
}