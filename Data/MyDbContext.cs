using System;
using System.Collections.Generic;
using BookShelf.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShelf.Data;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorie> Categories { get; set; }

    public virtual DbSet<Libri> Libris { get; set; }

    public virtual DbSet<LibriCategorie> LibroCategoria { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=db39279.public.databaseasp.net;Database=db39279;User Id=db39279;Password=Sasso1234!;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC075870D7AB");

            entity.ToTable("Categorie");

            entity.HasIndex(e => e.DescrizioneEn, "UQ__Categori__3C18E47B924DECD9").IsUnique();

            entity.HasIndex(e => e.Descrizione, "UQ__Categori__4964852BEE95FC94").IsUnique();

            entity.Property(e => e.Descrizione)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DescrizioneEn)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DescrizioneEN");
        });

        modelBuilder.Entity<Libri>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Libri__3214EC0783337FEB");

            entity.ToTable("Libri");

            entity.Property(e => e.Autore)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DataFine).HasColumnType("datetime");
            entity.Property(e => e.DataInizio).HasColumnType("datetime");
            entity.Property(e => e.Note)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RatingPersonale).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Titolo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LibriCategorie>(entity =>
        {
            entity.HasKey(e => new { e.IdLibro, e.IdCategoria }).HasName("PK__LibroCat__24374B0C0C0CFFDC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
