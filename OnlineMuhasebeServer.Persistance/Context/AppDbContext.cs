using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using OnlineMuhasebeServer.Domain.Abstractions;
using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;

namespace OnlineMuhasebeServer.Persistance.Context
{
    public sealed class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Company> Companies { get; set; }
        public DbSet<MainRole> MainRoles { get; set; }
        public DbSet<MainRoleAndRoleRelationship> MainRoleAndRoleRelationships { get; set; }
        public DbSet<UserAndCompanyRelationship> UserAndCompanyRelationships { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<OnlineMuhasebeServer.Domain.Abstractions.Entity>();

            foreach (var entry in entries)
            {
                if(entry.State == EntityState.Added)
                {                   
                    entry.Property(p => p.CreatedDate)
                        .CurrentValue = DateTime.Now;
                }

                if(entry.State == EntityState.Modified)
                {
                    entry.Property(p => p.UpdateDate)
                        .CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityUserRole<string>>();
            builder.Ignore<IdentityUserClaim<string>>();
            builder.Ignore<IdentityUserToken<string>>();
            builder.Ignore<IdentityRoleClaim<string>>();
        }

        public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
        {
            public AppDbContext CreateDbContext(string[] args)
            {                
                var optionsBuilder = new DbContextOptionsBuilder();

                var connectionString = "Data Source=DESKTOP-3BJ5GK9;Initial Catalog=MuhasebeMasterDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                optionsBuilder.UseSqlServer(connectionString);

                return new AppDbContext(optionsBuilder.Options);
            }
        }

    }
}
