using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MovieFusion.Models;

public partial class MovieFusionContext : DbContext
{
    public MovieFusionContext()
    {
    }

    public MovieFusionContext(DbContextOptions<MovieFusionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<MovieList> MovieLists { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MsSqlLocalDb;Initial Catalog=Movie_Fusion;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Admin");

            entity.Property(e => e.Aemail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AEmail");
            entity.Property(e => e.Apass)
                .IsUnicode(false)
                .HasColumnName("APass");
        });

        modelBuilder.Entity<MovieList>(entity =>
        {
            entity.HasKey(e => e.MId).HasName("PK__Movie_Li__188887DFA7A3E05F");

            entity.ToTable("Movie_List");

            entity.Property(e => e.MId).HasColumnName("M_id");
            entity.Property(e => e.Genre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Mname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MName");
            entity.Property(e => e.Mpic).HasColumnName("MPic");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__F1FF84532222C56A");

            entity.Property(e => e.OrderId).HasColumnName("Order_id");
            entity.Property(e => e.MId).HasColumnName("M_id");
            entity.Property(e => e.UId).HasColumnName("U_id");

            entity.HasOne(d => d.MIdNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.MId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Movie_List");

            entity.HasOne(d => d.UIdNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UId).HasName("PK__User__5A39651380FCB342");

            entity.ToTable("User");

            entity.HasIndex(e => e.Email, "UQ__User__A9D105344336E6BD").IsUnique();

            entity.Property(e => e.UId).HasColumnName("U_id");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
