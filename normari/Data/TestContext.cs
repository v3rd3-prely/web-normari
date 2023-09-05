using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using normari.Models;

namespace normari.Data;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Norme> Normes { get; set; }

    public virtual DbSet<Operatiestandard> Operatiestandards { get; set; }

    public virtual DbSet<Operatietip> Operatietips { get; set; }

    public virtual DbSet<Postlucru> Postlucrus { get; set; }

    public virtual DbSet<Sectii> Sectiis { get; set; }

    public virtual DbSet<Timpi> Timpis { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Norme>(entity =>
        {
            entity.HasKey(e => e.Normaid).HasName("norme_pkey");

            entity.ToTable("norme", "normari");

            entity.Property(e => e.Normaid).HasColumnName("normaid");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.NrOperatii)
                .HasDefaultValueSql("1")
                .HasColumnName("nrOperatii");
            entity.Property(e => e.Operatiemultipla)
                .HasDefaultValueSql("false")
                .HasColumnName("operatiemultipla");
            entity.Property(e => e.Operatiesimpla)
                .HasDefaultValueSql("true")
                .HasColumnName("operatiesimpla");
            entity.Property(e => e.Operatiestandard).HasColumnName("operatiestandard");
            entity.Property(e => e.Operatietip).HasColumnName("operatietip");
            entity.Property(e => e.Postlucru).HasColumnName("postlucru");
            entity.Property(e => e.Sectie).HasColumnName("sectie");

            entity.HasOne(d => d.OperatiestandardNavigation).WithMany(p => p.Normes)
                .HasForeignKey(d => d.Operatiestandard)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("norme_operatiestandard_fkey");

            entity.HasOne(d => d.OperatietipNavigation).WithMany(p => p.Normes)
                .HasForeignKey(d => d.Operatietip)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("norme_operatietip_fkey");

            entity.HasOne(d => d.PostlucruNavigation).WithMany(p => p.Normes)
                .HasForeignKey(d => d.Postlucru)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("norme_postlucru_fkey");

            entity.HasOne(d => d.SectieNavigation).WithMany(p => p.Normes)
                .HasForeignKey(d => d.Sectie)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("norme_sectie_fkey");
        });

        modelBuilder.Entity<Operatiestandard>(entity =>
        {
            entity.HasKey(e => e.Operatiestadnardid).HasName("operatiestandard_pkey");

            entity.ToTable("operatiestandard", "normari");

            entity.Property(e => e.Operatiestadnardid).HasColumnName("operatiestadnardid");
            entity.Property(e => e.Operatiestandard1)
                .HasMaxLength(50)
                .HasColumnName("operatiestandard");
        });

        modelBuilder.Entity<Operatietip>(entity =>
        {
            entity.HasKey(e => e.Operatietipid).HasName("operatietip_pkey");

            entity.ToTable("operatietip", "normari");

            entity.Property(e => e.Operatietipid).HasColumnName("operatietipid");
            entity.Property(e => e.Operatietip1)
                .HasMaxLength(40)
                .HasColumnName("operatietip");
        });

        modelBuilder.Entity<Postlucru>(entity =>
        {
            entity.HasKey(e => e.Postid).HasName("postlucru_pkey");

            entity.ToTable("postlucru", "normari");

            entity.Property(e => e.Postid).HasColumnName("postid");
            entity.Property(e => e.Postdelucru)
                .HasMaxLength(100)
                .HasColumnName("postdelucru");
        });

        modelBuilder.Entity<Sectii>(entity =>
        {
            entity.HasKey(e => e.Sectieid).HasName("sectii_pkey");

            entity.ToTable("sectii", "normari");

            entity.Property(e => e.Sectieid).HasColumnName("sectieid");
            entity.Property(e => e.Sectie)
                .HasMaxLength(10)
                .HasColumnName("sectie");
        });

        modelBuilder.Entity<Timpi>(entity =>
        {
            entity.HasKey(e => e.Timpid).HasName("timpi_pkey");

            entity.ToTable("timpi", "normari");

            entity.Property(e => e.Timpid).HasColumnName("timpid");
            entity.Property(e => e.Endtime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("endtime");
            entity.Property(e => e.Normaid).HasColumnName("normaid");
            entity.Property(e => e.Starttime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("starttime");
            entity.Property(e => e.Timp1).HasColumnName("timp_1");
            entity.Property(e => e.Timp10).HasColumnName("timp_10");
            entity.Property(e => e.Timp11).HasColumnName("timp_11");
            entity.Property(e => e.Timp12).HasColumnName("timp_12");
            entity.Property(e => e.Timp13).HasColumnName("timp_13");
            entity.Property(e => e.Timp14).HasColumnName("timp_14");
            entity.Property(e => e.Timp15).HasColumnName("timp_15");
            entity.Property(e => e.Timp2).HasColumnName("timp_2");
            entity.Property(e => e.Timp3).HasColumnName("timp_3");
            entity.Property(e => e.Timp4).HasColumnName("timp_4");
            entity.Property(e => e.Timp5).HasColumnName("timp_5");
            entity.Property(e => e.Timp6).HasColumnName("timp_6");
            entity.Property(e => e.Timp7).HasColumnName("timp_7");
            entity.Property(e => e.Timp8).HasColumnName("timp_8");
            entity.Property(e => e.Timp9).HasColumnName("timp_9");
            entity.Property(e => e.Timptotal).HasColumnName("timptotal");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
