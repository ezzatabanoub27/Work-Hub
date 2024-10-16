using Easy_Job.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Easy_Job.Data.AppDBContext
{
    public class EasyContext : IdentityDbContext<AppUser>
    {
        public EasyContext(DbContextOptions<EasyContext> options) : base(options)
        {

        }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AppUser>()
                .HasOne(u => u.profile)
                .WithOne(u => u.appuser)
                .HasForeignKey<Profile>(p => p.appuser_Id);
        }

    }
}
