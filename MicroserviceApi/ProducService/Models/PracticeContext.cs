using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProducService.Models;

public partial class PracticeContext : DbContext
{
    public PracticeContext()
    {
    }

    public PracticeContext(DbContextOptions<PracticeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Usernote> Usernotes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__student__3213E83FBB0AA271");

            entity.ToTable("student");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Salaryamt).HasColumnName("salaryamt");
        });

        modelBuilder.Entity<Usernote>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usernote__3213E83FCE94AADA");

            entity.ToTable("usernote");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Datetimes)
                .HasColumnType("datetime")
                .HasColumnName("datetimes");
            entity.Property(e => e.Note)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("note");
            entity.Property(e => e.Noteid)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("noteid");
            entity.Property(e => e.Notetype)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("notetype");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
