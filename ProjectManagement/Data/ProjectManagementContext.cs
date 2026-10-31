using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Models;

public partial class ProjectManagementContext : DbContext
{
    public ProjectManagementContext()
    {
    }

    public ProjectManagementContext(DbContextOptions<ProjectManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectTask> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Idemployee).HasName("employees_pkey");

            entity.ToTable("employees");

            entity.HasIndex(e => e.Email, "employees_email_key").IsUnique();

            entity.Property(e => e.Idemployee)
                .ValueGeneratedNever()
                .HasColumnName("idemployee");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("createdat");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.Fullname)
                .HasMaxLength(200)
                .HasColumnName("fullname");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Idproject).HasName("projects_pkey");

            entity.ToTable("projects");

            entity.Property(e => e.Idproject)
                .ValueGeneratedNever()
                .HasColumnName("idproject");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("createdat");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ProjectTask>(entity =>
        {
            entity.HasKey(e => e.Idtask).HasName("tasks_pkey");

            entity.ToTable("tasks");

            entity.Property(e => e.Idtask)
                .ValueGeneratedNever()
                .HasColumnName("idtask");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("createdat");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Duedate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("duedate");
            entity.Property(e => e.Idemployee).HasColumnName("idemployee");
            entity.Property(e => e.Idproject).HasColumnName("idproject");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .HasDefaultValueSql("'New'::character varying")
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");

            entity.HasOne(d => d.IdemployeeNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.Idemployee)
                .HasConstraintName("tasks_idemployee_fkey");

            entity.HasOne(d => d.IdprojectNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.Idproject)
                .HasConstraintName("tasks_idproject_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
