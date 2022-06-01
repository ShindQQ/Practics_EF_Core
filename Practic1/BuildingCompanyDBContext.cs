using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Practic1
{
    public partial class BuildingCompanyDBContext : DbContext
    {
        public BuildingCompanyDBContext()
        {
        }

        public BuildingCompanyDBContext(DbContextOptions<BuildingCompanyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brigade> Brigades { get; set; } = null!;
        public virtual DbSet<BuildingCompany> BuildingCompanies { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Development> Developments { get; set; } = null!;
        public virtual DbSet<DoneJob> DoneJobs { get; set; } = null!;
        public virtual DbSet<InfoForFirstBrigade> InfoForFirstBrigades { get; set; } = null!;
        public virtual DbSet<JobType> JobTypes { get; set; } = null!;
        public virtual DbSet<Material> Materials { get; set; } = null!;
        public virtual DbSet<MaterialsOrder> MaterialsOrders { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Tool> Tools { get; set; } = null!;
        public virtual DbSet<ToolsBrigade> ToolsBrigades { get; set; } = null!;
        public virtual DbSet<Worker> Workers { get; set; } = null!;
        public virtual DbSet<WorkersBrigade> WorkersBrigades { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder().AddUserSecrets<BuildingCompanyDBContext>().Build();
                var connectionString = configuration.GetConnectionString("BuildingCompanyDB");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brigade>(entity =>
            {
                entity.Property(e => e.BrigadeId).HasColumnName("BrigadeID");

                entity.Property(e => e.BuildingCompanyId).HasColumnName("BuildingCompanyID");

                entity.HasOne(d => d.BuildingCompany)
                    .WithMany(p => p.Brigades)
                    .HasForeignKey(d => d.BuildingCompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Brigades__Buildi__36B12243");
            });

            modelBuilder.Entity<BuildingCompany>(entity =>
            {
                entity.ToTable("BuildingCompany");

                entity.Property(e => e.BuildingCompanyId).HasColumnName("BuildingCompanyID");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('undefined')");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Fname)
                    .HasMaxLength(20)
                    .HasColumnName("FName")
                    .HasDefaultValueSql("('undefined')");

                entity.Property(e => e.Lname)
                    .HasMaxLength(20)
                    .HasColumnName("LName")
                    .HasDefaultValueSql("('undefined')");

                entity.Property(e => e.PassportId).HasColumnName("PassportID");

                entity.Property(e => e.Pname)
                    .HasMaxLength(20)
                    .HasColumnName("PName")
                    .HasDefaultValueSql("('undefined')");
            });

            modelBuilder.Entity<Development>(entity =>
            {
                entity.Property(e => e.DevelopmentId).HasColumnName("DevelopmentID");

                entity.Property(e => e.Address)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('undefined')");
            });

            modelBuilder.Entity<DoneJob>(entity =>
            {
                entity.Property(e => e.DoneJobId).HasColumnName("DoneJobID");

                entity.Property(e => e.BrigadeId).HasColumnName("BrigadeID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.JobTypeId).HasColumnName("JobTypeID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.HasOne(d => d.Brigade)
                    .WithMany(p => p.DoneJobs)
                    .HasForeignKey(d => d.BrigadeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DoneJobs__Brigad__5AEE82B9");

                entity.HasOne(d => d.JobType)
                    .WithMany(p => p.DoneJobs)
                    .HasForeignKey(d => d.JobTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DoneJobs__JobTyp__59FA5E80");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.DoneJobs)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DoneJobs__OrderI__5BE2A6F2");
            });

            modelBuilder.Entity<InfoForFirstBrigade>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("InfoForFirstBrigade");

                entity.Property(e => e.BrigadeId).HasColumnName("BrigadeID");

                entity.Property(e => e.Professionalism).HasMaxLength(20);

                entity.Property(e => e.Speciality).HasMaxLength(20);

                entity.Property(e => e.ToolId).HasColumnName("ToolID");

                entity.Property(e => e.WorkerId).HasColumnName("WorkerID");
            });

            modelBuilder.Entity<JobType>(entity =>
            {
                entity.Property(e => e.JobTypeId).HasColumnName("JobTypeID");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('undefined')");

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.Property(e => e.MaterialId).HasColumnName("MaterialID");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('undefined')");

                entity.Property(e => e.PriceForOne).HasColumnType("money");

                entity.Property(e => e.Shape)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('undefined')");
            });

            modelBuilder.Entity<MaterialsOrder>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.MaterialId).HasColumnName("MaterialID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.HasOne(d => d.Material)
                    .WithMany()
                    .HasForeignKey(d => d.MaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Materials__Mater__5535A963");

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Materials__Order__5441852A");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.BuildingCompanyId).HasColumnName("BuildingCompanyID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DevelopmentId).HasColumnName("DevelopmentID");

                entity.Property(e => e.EstimatedPrice).HasColumnType("money");

                entity.HasOne(d => d.BuildingCompany)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.BuildingCompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__Building__4BAC3F29");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__Customer__4AB81AF0");

                entity.HasOne(d => d.Development)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DevelopmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__Developm__49C3F6B7");
            });

            modelBuilder.Entity<Tool>(entity =>
            {
                entity.Property(e => e.ToolId).HasColumnName("ToolID");

                entity.Property(e => e.DateEnd).HasColumnType("datetime");

                entity.Property(e => e.DateStart).HasColumnType("datetime");
            });

            modelBuilder.Entity<ToolsBrigade>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BrigadeId).HasColumnName("BrigadeID");

                entity.Property(e => e.ToolId).HasColumnName("ToolID");

                entity.HasOne(d => d.Brigade)
                    .WithMany()
                    .HasForeignKey(d => d.BrigadeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ToolsBrig__Briga__46E78A0C");

                entity.HasOne(d => d.Tool)
                    .WithMany()
                    .HasForeignKey(d => d.ToolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ToolsBrig__ToolI__45F365D3");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.Property(e => e.WorkerId).HasColumnName("WorkerID");

                entity.Property(e => e.DateEnd).HasColumnType("datetime");

                entity.Property(e => e.DateStart).HasColumnType("datetime");

                entity.Property(e => e.Professionalism)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('undefined')");

                entity.Property(e => e.Speciality)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('undefined')");
            });

            modelBuilder.Entity<WorkersBrigade>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BrigadeId).HasColumnName("BrigadeID");

                entity.Property(e => e.WorkerId).HasColumnName("WorkerID");

                entity.HasOne(d => d.Brigade)
                    .WithMany()
                    .HasForeignKey(d => d.BrigadeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WorkersBr__Briga__403A8C7D");

                entity.HasOne(d => d.Worker)
                    .WithMany()
                    .HasForeignKey(d => d.WorkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WorkersBr__Worke__3F466844");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
