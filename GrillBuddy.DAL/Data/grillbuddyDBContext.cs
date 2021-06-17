using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GrillBuddy.DAL.Entities;

#nullable disable

namespace GrillBuddy.DAL.Data
{
    public partial class grillbuddyDBContext : DbContext
    {
        public grillbuddyDBContext()
        {
        }

        public grillbuddyDBContext(DbContextOptions<grillbuddyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Allergy> Allergies { get; set; }
        public virtual DbSet<Drink> Drinks { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAllergy> UserAllergies { get; set; }
        public virtual DbSet<UserReservation> UserReservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:grillbuddyserver.database.windows.net,1433;Initial Catalog=grillbuddyDB;Persist Security Info=False;User ID=buddyadmin;Password=Paperino123*;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Allergy>(entity =>
            {
                entity.Property(e => e.AllergyId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("allergy_id");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Drink>(entity =>
            {
                entity.Property(e => e.DrinkId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("drink_id");

                entity.Property(e => e.Alcol).HasColumnName("alcol");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Quantita)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("quantita");
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.ToTable("Food");

                entity.Property(e => e.FoodId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("food_id");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Weight)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("weight");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.LocationId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("location_id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.People)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("people");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.Property(e => e.ReservationId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("reservation_id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.LocationId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("location_id");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservations_Locations");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("user_id");

                entity.Property(e => e.DrinkId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("drink_id");

                entity.Property(e => e.FoodId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("food_id");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.Drink)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DrinkId)
                    .HasConstraintName("FK_Users_Drinks");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.FoodId)
                    .HasConstraintName("FK_Users_Food");
            });

            modelBuilder.Entity<UserAllergy>(entity =>
            {
                entity.HasKey(e => new { e.AllergyId, e.UserId });

                entity.ToTable("User-Allergies");

                entity.Property(e => e.AllergyId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("allergy_id");

                entity.Property(e => e.UserId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("user_id");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.HasOne(d => d.Allergy)
                    .WithMany(p => p.UserAllergies)
                    .HasForeignKey(d => d.AllergyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User-Allergies_Allergies");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAllergies)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User-Allergies_Users");
            });

            modelBuilder.Entity<UserReservation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("User-Reservation");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Owner)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("owner");

                entity.Property(e => e.ReservationId)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("reservation_id");

                entity.Property(e => e.UserId)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Reservation)
                    .WithMany()
                    .HasForeignKey(d => d.ReservationId)
                    .HasConstraintName("FK_User-Reservation_Reservations");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User-Reservation_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
