using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HouseStore.Models
{
    public partial class HousesContext : DbContext
    {
        
        public HousesContext()
        {
        }

        public HousesContext(DbContextOptions<HousesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<House> Houses { get; set; }
        public virtual DbSet<StateEnum> StateEnums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(Secret.connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<House>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(25);

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.State).HasMaxLength(2);

                entity.HasOne(d => d.StateNavigation)
                    .WithMany(p => p.Houses)
                    .HasForeignKey(d => d.State)
                    .HasConstraintName("FK__Houses__State__286302EC");
            });

            modelBuilder.Entity<StateEnum>(entity =>
            {
                entity.HasKey(e => e.State)
                    .HasName("PK__StateEnu__BA803DACE51F75DA");

                entity.ToTable("StateEnum");

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('MI')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
