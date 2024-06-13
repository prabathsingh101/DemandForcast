using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DemandForcast.API.Data
{
    public class ApplicationDbAuthContext: IdentityDbContext
    {
        public ApplicationDbAuthContext(DbContextOptions<ApplicationDbAuthContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "f0ace2d4-5bf5-49e4-8ede-f640a568e97f";

            var writerRoleId = "5e191eed-40c6-47ae-85cb-86f6695b7931";

            var roles = new List<IdentityRole> {
              new IdentityRole
              {
                  Id= readerRoleId,
                  ConcurrencyStamp = readerRoleId,
                  Name="Reader",
                  NormalizedName="Reader".ToUpper()
              },
              new IdentityRole
              {
                  Id= writerRoleId,
                  ConcurrencyStamp = writerRoleId,
                  Name="Writer",
                  NormalizedName="Writer".ToUpper()
              }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
