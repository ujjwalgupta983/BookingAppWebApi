using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookingApp3.Models
{
    public partial class aContext : DbContext
    {
        public aContext()
        {
        }

        public aContext(DbContextOptions<aContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assets> Assets { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }
        public virtual DbSet<Room> Room { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=root;database=a");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assets>(entity =>
            {
                entity.HasKey(e => e.AId);

                entity.ToTable("assets");

                entity.HasIndex(e => e.AAdd1)
                    .HasName("a_add1_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.OId)
                    .HasName("o_id_idx");

                entity.Property(e => e.AId)
                    .HasColumnName("a_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AAdd1)
                    .IsRequired()
                    .HasColumnName("a_add1")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.AAdd2)
                    .HasColumnName("a_add2")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.AName)
                    .IsRequired()
                    .HasColumnName("a_name")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.OId)
                    .HasColumnName("o_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("varchar(45)");

                entity.HasOne(d => d.O)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.OId)
                    .HasConstraintName("o_id");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.ToTable("owner");

                entity.HasIndex(e => e.Email)
                    .HasName("Email_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.OwnerId)
                    .HasColumnName("owner_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Passcode)
                    .IsRequired()
                    .HasColumnName("passcode")
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.RId);

                entity.ToTable("room");

                entity.HasIndex(e => e.AId)
                    .HasName("a_id_idx");

                entity.Property(e => e.RId)
                    .HasColumnName("r_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AId)
                    .HasColumnName("a_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RCategory)
                    .IsRequired()
                    .HasColumnName("r_category")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.RNo)
                    .HasColumnName("r_no")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RRate)
                    .HasColumnName("r_rate")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RStatus)
                    .HasColumnName("r_status")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.A)
                    .WithMany(p => p.Room)
                    .HasForeignKey(d => d.AId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("a_id");
            });
        }
    }
}
