using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace GymApp.Models
{
    public partial class GymAppContext : DbContext
    {
        public GymAppContext()
        {
        }

        public GymAppContext(DbContextOptions<GymAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CheckIn> CheckIn { get; set; }
        public virtual DbSet<Gym> Gym { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheckIn>(entity =>
            {
                entity.ToTable("CheckIn", "GymApp");

                entity.HasIndex(e => e.ReservationId)
                    .HasName("fk_CheckIn_1_idx");

                entity.Property(e => e.Id).HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ReservationId).HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.CheckIn)
                    .HasForeignKey(d => d.ReservationId)
                    .HasConstraintName("fk_CheckIn_1");
            });

            modelBuilder.Entity<Gym>(entity =>
            {
                entity.ToTable("Gym", "GymApp");

                entity.HasIndex(e => e.OwnerId)
                    .HasName("fk_Gym_1_idx");

                entity.Property(e => e.Id).HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerId).HasColumnType("int(10) unsigned");

                entity.Property(e => e.ProfilePicture)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Gym)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Gym_1");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.ToTable("Reservation", "GymApp");

                entity.HasIndex(e => e.GymId)
                    .HasName("fk_Reservation_2_idx");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_Reservation_1_idx");

                entity.Property(e => e.Id).HasColumnType("int(11) unsigned");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.GymId).HasColumnType("int(10) unsigned");

                entity.Property(e => e.UserId).HasColumnType("int(10) unsigned");

                entity.HasOne(d => d.Gym)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.GymId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Reservation_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_Reservation_1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "GymApp");

                entity.HasIndex(e => e.Email)
                    .HasName("Email_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.UserTypeId)
                    .HasName("fk_User_1_idx");

                entity.HasIndex(e => e.Username)
                    .HasName("Username_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(10) unsigned");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.IsConfirmed)
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.UserTypeId).HasColumnType("int(10) unsigned");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.UserTypeId)
                    .HasConstraintName("fk_User_1");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.ToTable("UserType", "GymApp");

                entity.Property(e => e.Id).HasColumnType("int(10) unsigned");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });
        }
    }
}
