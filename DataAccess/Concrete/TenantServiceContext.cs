using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class TenantServiceContext : DbContext
    {
        public TenantServiceContext(DbContextOptions<TenantServiceContext> contextOptions) : base(contextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<TenantService> TenantServices { get; set; }
        public DbSet<Connection> Connections { get; set; }
    }
}
