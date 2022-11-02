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
          optionsBuilder.UseSqlServer("Server=HDVMSQLDES; Database=Z_SureBet; User ID=sa; Password=S0p0rt3; MultipleActiveResultSets=true;");
        }
        public DbSet<IS_SureBet.Models.BetData>? BetData { get; set; }
    }
}