using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalksApi.Data
{
    public class NZwalksAuthDbContext : IdentityDbContext
    {
        public NZwalksAuthDbContext(DbContextOptions<NZwalksAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "8a4e3831-0c92-4c41-b7f4-ea39651e9492";
            var writerRoleId = "62a729cc-9dd0-4a5c-a05d-ca93351c56f7";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }
            };


            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
