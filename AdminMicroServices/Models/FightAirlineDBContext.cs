using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AdminMicroServices.Models
{
    public partial class FightAirlineDBContext : DbContext
    {
        public FightAirlineDBContext()
        {
        }

        public FightAirlineDBContext(DbContextOptions<FightAirlineDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAdminLogin> TblAdminLogins { get; set; }
        public virtual DbSet<TblAirline> TblAirlines { get; set; }
        public virtual DbSet<TblFlightSchedule> TblFlightSchedules { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = CTSDOTNET330;Initial Catalog = FightAirlineDB;User ID = sa;Password = pass@word1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblAdminLogin>(entity =>
            {
                entity.ToTable("tblAdminLogin");

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.UserName).HasMaxLength(100);
            });

            modelBuilder.Entity<TblAirline>(entity =>
            {
                entity.HasKey(e => e.AirlineId);

                entity.ToTable("tblAirlines");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.AirlineLogo).HasMaxLength(50);

                entity.Property(e => e.AirlineName).HasMaxLength(100);

                entity.Property(e => e.Contact).HasMaxLength(20);
            });

            modelBuilder.Entity<TblFlightSchedule>(entity =>
            {
                entity.HasKey(e => e.FlightId);

                entity.ToTable("tblFlightSchedule");

                entity.Property(e => e.AirlineLogo).HasMaxLength(50);

                entity.Property(e => e.AirlineName).HasMaxLength(100);

                entity.Property(e => e.EndDatetime).HasColumnType("datetime");

                entity.Property(e => e.FlightNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FromPlace).HasMaxLength(100);

                entity.Property(e => e.InstrumentUsed).HasMaxLength(100);

                entity.Property(e => e.Meal).HasMaxLength(50);

                entity.Property(e => e.ScheduleDays).HasMaxLength(50);

                entity.Property(e => e.StartDatetime).HasColumnType("datetime");

                entity.Property(e => e.TicketPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ToPlace).HasMaxLength(100);

                entity.HasOne(d => d.Airline)
                    .WithMany(p => p.TblFlightSchedules)
                    .HasForeignKey(d => d.AirlineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblFlightSchedule_tblAirlines");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("tblUser");

                entity.Property(e => e.AirlineName).HasMaxLength(100);

                entity.Property(e => e.Cancelled).HasMaxLength(50);

                entity.Property(e => e.EmailId).HasMaxLength(50);

                entity.Property(e => e.FlightNumber).HasMaxLength(100);

                entity.Property(e => e.Gender).HasMaxLength(20);

                entity.Property(e => e.Meal).HasMaxLength(50);

                entity.Property(e => e.Pnr).HasColumnName("pnr");

                entity.Property(e => e.SeatsNumbers).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
