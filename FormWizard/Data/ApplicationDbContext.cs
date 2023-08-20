using FormWizard.Model;
using Microsoft.EntityFrameworkCore;

namespace FormWizard.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Country> Country { get; set; }

    }
}
