using Beers.DataAccess.AspIntoDbContext;
using Microsoft.EntityFrameworkCore;

namespace Beers.DataAccess
{
    public partial class IntroAspContext : DbContext
    {
        public IntroAspContext()
        {
        }

        public IntroAspContext(DbContextOptions<IntroAspContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BeerModel> Beers { get; set; } = null!;
        public virtual DbSet<BrandModel> Brands { get; set; } = null!;
        public virtual DbSet<UserProfileModel> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BeerModel>(entity =>
            {
                entity.HasKey(e => e.IdBeer);

                entity.ToTable("Beer");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Beers)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Beer_Brand");
            });

            modelBuilder.Entity<BrandModel>(entity =>
            {
                entity.HasKey(e => e.IdBrand);

                entity.ToTable("Brand");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserProfileModel>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("UserProfileModel");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
