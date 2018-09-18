using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FFive.API.Models
{
    public class KookifyDbContext : IdentityDbContext<ApplicationUser>
    {
        public KookifyDbContext(DbContextOptions<KookifyDbContext> options) : base(options)
        {
        }

        protected KookifyDbContext()
        {
        }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RefreshToken>()
                 .HasAlternateKey(c => c.UserId)
                 .HasName("refreshToken_UserId");
            modelBuilder.Entity<RefreshToken>()
                .HasAlternateKey(c => c.Token)
                .HasName("refreshToken_Token");

            base.OnModelCreating(modelBuilder);
        }
    }
}