using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace whozthere_api.Models;

public partial class VisitorDbContext : DbContext
{
    public VisitorDbContext()
    {
    }

    public VisitorDbContext(DbContextOptions<VisitorDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<PersonVisitor> PersonVisitors { get; set; }

    public virtual DbSet<Visitor> Visitors { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).IsClustered(false);

            entity.ToTable("Person");

            entity.Property(e => e.Email).HasMaxLength(30);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.HouseNumber).HasMaxLength(20);
            entity.Property(e => e.Lastname).HasMaxLength(100);
            entity.Property(e => e.Othernames).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(10);
        });

        modelBuilder.Entity<PersonVisitor>(entity =>
        {
            entity.HasKey(e => e.PersonVisitorId).IsClustered(false);

            entity.ToTable("PersonVisitor");

            entity.Property(e => e.CheckInTime).HasColumnType("datetime");
            entity.Property(e => e.CheckOutTime).HasColumnType("datetime");

            entity.HasOne(d => d.Person).WithMany(p => p.PersonVisitors)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Person_PersonVisitor");

            entity.HasOne(d => d.Visitor).WithMany(p => p.PersonVisitors)
                .HasForeignKey(d => d.VisitorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Visitor_PersonVisitor");
        });

        modelBuilder.Entity<Visitor>(entity =>
        {
            entity.HasKey(e => e.VisitorId).IsClustered(false);

            entity.ToTable("Visitor");

            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.Lastname).HasMaxLength(100);
            entity.Property(e => e.Othernames).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(10);

            entity.HasOne(d => d.Person).WithMany(p => p.Visitors)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RefPerson4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
