using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataEncryptor.Data
{
    public class AuthenticationDbContextContext : IdentityDbContext<IdentityUser>
    {
        public AuthenticationDbContextContext(DbContextOptions<AuthenticationDbContextContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}