﻿using Geardao.Deploy.Supervisor.Ef.Model;
using Microsoft.EntityFrameworkCore;

namespace Geardao.Deploy.Supervisor.Ef
{
    public partial class SupervisorContext : DbContext
    {
        public SupervisorContext()
        {
        }

        public SupervisorContext(DbContextOptions<SupervisorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Execute> Execute { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<Model.Worker> Worker { get; set; }
        public virtual DbSet<Auth> Auth { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Execute>(entity =>
            {
                entity.ToTable("execute");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("BIGINT")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Executetime).HasColumnName("executetime");

                entity.Property(e => e.Returnlog).HasColumnName("returnlog");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(e => e.Worker).WithMany(w=>w.Executes);
                entity.HasOne(e => e.Task).WithMany(t => t.Executes);
                entity.Property(e => e.Timeout).HasColumnName("timeout");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("task");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("BIGINT").
                    ValueGeneratedOnAdd();

                entity.Property(e => e.CreateTime)
                    .HasColumnName("createtime")
                    .HasColumnType("DATETIME");

                entity.Property(e => e.Executetime).HasColumnName("executetime");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(255)");

                entity.Property(e => e.Retrytime).HasColumnName("retrytime");

                entity.Property(e => e.Starttime)
                    .HasColumnName("starttime")
                    .HasColumnType("DATETIME");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Timeout).HasColumnName("timeout");

                entity.HasMany(t => t.Executes).WithOne(t => t.Task);
            });

            modelBuilder.Entity<Model.Worker>(entity =>
            {
                entity.ToTable("worker");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();
                
                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .ValueGeneratedNever();
                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .ValueGeneratedNever();
                
                entity.Property(e => e.Healthy).HasColumnName("healthy");

                entity.Property(e => e.Instanceinpool).HasColumnName("instanceinpool");

                entity.Property(e => e.Ip)
                    .HasColumnName("ip")
                    .HasColumnType("VARCHAR(10)");

                entity.Property(e => e.Maxinstanceinpool).HasColumnName("maxinstanceinpool");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("VARCHAR(255)");
                
                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("VARCHAR(255)");
                
                entity.HasMany(t => t.Executes).WithOne(w => w.Worker);
            });

            modelBuilder.Entity<Auth>(entity =>
            {
                entity.ToTable("Auth");
                
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();
                
                entity.Property(e => e.Token)
                    .HasColumnName("token")
                    .HasColumnType("VARCHAR(255)");
                
                entity.Property(e => e.CreateTime)
                    .HasColumnName("createtime")
                    .HasColumnType("DATETIME");

                entity.Property(e => e.ExpiredTime)
                    .HasColumnName("expiredtime")
                    .HasColumnType("DATETIME");

            });
        }
    }
}
