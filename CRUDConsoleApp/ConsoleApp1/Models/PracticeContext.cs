using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Models;

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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ARUNANGSHUD-WIN;Database=practice;User Id=sa;Password=mindfire; Trust Server Certificate = true");

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
