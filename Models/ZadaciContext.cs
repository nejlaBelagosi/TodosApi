using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Todos.Models;

public partial class ZadaciContext : DbContext
{
    public ZadaciContext()
    {
    }

    public ZadaciContext(DbContextOptions<ZadaciContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Zadaci> Zadacis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-MAC1B56\\SQLEXPRESS;Database=Zadaci;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Zadaci>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ZADACI__3213E83F82B16AB8");

            entity.ToTable("ZADACI");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.NazivZadatka)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nazivZadatka");
            entity.Property(e => e.Stanje)
                .HasMaxLength(1024)
                .HasColumnName("stanje");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
