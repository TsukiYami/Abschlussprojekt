using Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendAbschlussprojekt.DB
{
    public class AufraumaktionContext : DbContext
    {
        public AufraumaktionContext(DbContextOptions<AufraumaktionContext> options) : base(options) { }

        public DbSet<LoginEntity> oLogin { get; set; }
        public DbSet<VersionEntity> oVersion { get; set; }

        protected override void OnModelCreating(ModelBuilder oModelBuilder)
        {
            base.OnModelCreating(oModelBuilder);

            oModelBuilder.Entity<LoginEntity>(login =>
            {
                login.ToTable("Login");

                login.HasKey(l => l.nID);

                login.Property(l => l.nID)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(1, 1);
                login.Property(l => l.sUsername)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)");
                login.Property(l => l.sPassword)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)");
            });

            oModelBuilder.Entity<VersionEntity>(oVersion =>
            {
                oVersion.ToTable("Version");

                oVersion.HasKey(v => v.nID);

                oVersion.Property(v => v.nID)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(1, 1);

                oVersion.Property(v => v.sVersionPath)
                .HasColumnType("TEXT");
            });
        }
    }
}