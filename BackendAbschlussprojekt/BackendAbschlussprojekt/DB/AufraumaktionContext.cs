using Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendAbschlussprojekt.DB
{
    public class AufraumaktionContext : DbContext
    {
        public AufraumaktionContext(DbContextOptions<AufraumaktionContext> options) : base(options) { }

        public DbSet<LoginEntity> Login { get; set; }

        protected override void OnModelCreating(ModelBuilder oModelBuilder)
        {
            base.OnModelCreating(oModelBuilder);

            oModelBuilder.Entity<LoginEntity>(login =>
            {
                login.ToTable("Login");

                login.HasKey(l => l.nID);
                login.Property(l => l.sUsername).IsRequired();
                login.Property(l => l.sPassword).IsRequired();
            });
        }
    }
}
