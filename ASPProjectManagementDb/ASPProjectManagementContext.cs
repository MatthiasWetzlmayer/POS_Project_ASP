using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASPProjectManagementDb
{
    public partial class ASPProjectManagementContext : DbContext
    {
        public ASPProjectManagementContext()
        {
        }

        public ASPProjectManagementContext(DbContextOptions<ASPProjectManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Profession> Professions { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectType> ProjectTypes { get; set; }
        public virtual DbSet<TeamMember> TeamMembers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=(LocalDB)\\mssqllocaldb;attachdbfilename=C:\\Temp\\create_wpf_netcore3\\netcore3\\ASPProjectManagement\\ASPProjectManagementDb\\ProjectTeams.mdf;integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.ProfessionId);

                entity.HasOne(d => d.Profession)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.ProfessionId);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasIndex(e => e.ProjectTypeId);

                entity.HasOne(d => d.ProjectType)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.ProjectTypeId);
            });

            modelBuilder.Entity<TeamMember>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId);

                entity.HasIndex(e => e.ProjectId);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TeamMembers)
                    .HasForeignKey(d => d.EmployeeId);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TeamMembers)
                    .HasForeignKey(d => d.ProjectId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
