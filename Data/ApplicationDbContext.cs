using GetMailWithAttachment.Models;
using Microsoft.EntityFrameworkCore;

namespace GetMailWithAttachment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) { }

        public DbSet<EmailViewModel> emailViewModels { get; set; }

    }
}
