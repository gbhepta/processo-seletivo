using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace processo_seletivo.Models;

public partial class ProcessoseletivoContext : DbContext
{
    public ProcessoseletivoContext()
    {
    }

    public ProcessoseletivoContext(DbContextOptions<ProcessoseletivoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Funcionario> Funcionarios { get; set; }

    public virtual DbSet<Lotacao> Lotacaos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=processoseletivo;user=teste;password=teste", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("funcionarios");

            entity.HasIndex(e => e.IdLotacao, "funcionario_lotacao");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnName("cpf");
            entity.Property(e => e.DataNascimento)
                .HasColumnType("datetime")
                .HasColumnName("data_nascimento");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.IdLotacao).HasColumnName("id_lotacao");
            entity.Property(e => e.Nome)
                .HasMaxLength(200)
                .HasColumnName("nome");

            entity.HasOne(d => d.IdLotacaoNavigation).WithMany(p => p.Funcionarios)
                .HasForeignKey(d => d.IdLotacao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("funcionario_lotacao");
        });

        modelBuilder.Entity<Lotacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("lotacao");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
