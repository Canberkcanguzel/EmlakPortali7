using EmlakPortali7.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace EmlakPortali7.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
        }
        public DbSet<EmlakModels> EmlakModels { get; set; }
        public DbSet<UserModels> userModels{ get; set; }
    }
}
