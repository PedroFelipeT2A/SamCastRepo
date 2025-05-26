using System;
using System.Collections.Generic;
using Painel.Models;
using Microsoft.EntityFrameworkCore;

namespace Painel.Data;

public partial class ctxContext : DbContext
{
    public ctxContext()
    {
    }

    public ctxContext(DbContextOptions<ctxContext> options)
        : base(options)
    {
    }

    public virtual DbSet<revendas> revendas { get; set; }
    public virtual DbSet<streamings> streamings { get; set; }
    public virtual DbSet<servidores> servidores { get; set; }
    public virtual DbSet<configuracoes> configuracoes { get; set; }
    public virtual DbSet<espectadores_conectados> espectadores_conectados { get; set; }
    public virtual DbSet<estatisticas> estatisticas { get; set; }
    public virtual DbSet<Pasta> Pastas { get; set; }
    public virtual DbSet<Video> Videos { get; set; }
    public virtual DbSet<Playlist> Playlists { get; set; }
    public virtual DbSet<VideoPlaylist> VideosPlaylist { get; set; }
    public virtual DbSet<Agendamento> Agendamentos { get; set; }
    public virtual DbSet<Live> Lives { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<revendas>(entity =>
        {
            entity.HasKey(e => e.codigo).HasName("PRIMARY");

            entity.Property(e => e.codigo).HasColumnType("int(10)");
            entity.Property(e => e.api_token).HasMaxLength(255);
            entity.Property(e => e.bitrate).HasColumnType("int(10)");
            entity.Property(e => e.codigo_revenda).HasColumnType("int(10)");
            entity.Property(e => e.data_cadastro).HasColumnType("datetime");
            entity.Property(e => e.dominio_padrao).HasMaxLength(255);
            entity.Property(e => e.email).HasMaxLength(255);
            entity.Property(e => e.espaco).HasColumnType("int(10)");
            entity.Property(e => e.espectadores).HasColumnType("int(10)");
            entity.Property(e => e.id)
                .HasMaxLength(6)
                .IsFixedLength();
            entity.Property(e => e.idioma_painel)
                .HasMaxLength(10)
                .HasDefaultValueSql("'pt-br'")
                .IsFixedLength();
            entity.Property(e => e.nome).HasMaxLength(255);
            entity.Property(e => e.refresh_token).HasMaxLength(255);
            entity.Property(e => e.senha).HasMaxLength(255);
            entity.Property(e => e.srt_status)
                .HasMaxLength(3)
                .HasDefaultValueSql("'nao'")
                .IsFixedLength();
            entity.Property(e => e.status)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(1)");
            entity.Property(e => e.stm_exibir_app_android)
                .HasMaxLength(3)
                .HasDefaultValueSql("'sim'")
                .IsFixedLength();
            entity.Property(e => e.stm_exibir_app_android_painel)
                .HasMaxLength(3)
                .HasDefaultValueSql("'sim'")
                .IsFixedLength();
            entity.Property(e => e.stm_exibir_downloads)
                .HasMaxLength(3)
                .HasDefaultValueSql("'sim'")
                .IsFixedLength();
            entity.Property(e => e.stm_exibir_mini_site)
                .HasMaxLength(3)
                .HasDefaultValueSql("'nao'")
                .IsFixedLength();
            entity.Property(e => e.stm_exibir_tutoriais)
                .HasMaxLength(3)
                .HasDefaultValueSql("'sim'")
                .IsFixedLength();
            entity.Property(e => e.streamings).HasColumnType("int(10)");
            entity.Property(e => e.subrevendas).HasColumnType("int(10)");
            entity.Property(e => e.tipo)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(1)");
            entity.Property(e => e.ultimo_acesso_data).HasColumnType("datetime");
            entity.Property(e => e.ultimo_acesso_ip)
                .HasMaxLength(255)
                .HasDefaultValueSql("'000.000.000.000'");
            entity.Property(e => e.url_suporte).HasColumnType("text");
            entity.Property(e => e.url_tutoriais)
                .HasMaxLength(255)
                .HasDefaultValueSql("'http://'");
        });

        modelBuilder.Entity<Pasta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Pasta");

            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(e => e.UsuarioLogin)
                .HasMaxLength(255);
        });

        modelBuilder.Entity<Video>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Video");

            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(e => e.Caminho)
                .HasMaxLength(255);

            // Relacionamento com Pasta
            entity.HasOne(d => d.Pasta)
                .WithMany(p => p.Videos)
                .HasForeignKey(d => d.PastaId)
                .OnDelete(DeleteBehavior.Cascade);  // Exclui vídeos quando a pasta for excluída
        });

        modelBuilder.Entity<Playlist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Playlist");

            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(e => e.CodigoStreaming)
                .HasMaxLength(100);
        });

        modelBuilder.Entity<VideoPlaylist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_VideoPlaylist");

            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(255);

            entity.HasOne(v => v.Playlist)
                .WithMany(p => p.Videos)
                .HasForeignKey(v => v.PlaylistId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Agendamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Agendamento");

            entity.Property(e => e.DataHora)
                .IsRequired();

            entity.HasOne(a => a.Playlist)
                .WithMany(p => p.Agendamentos)
                .HasForeignKey(a => a.PlaylistId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Live>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PK_Live");

            entity.Property(e => e.DataInicio).IsRequired();
            entity.Property(e => e.DataFim).IsRequired();
            entity.Property(e => e.Tipo).IsRequired().HasMaxLength(50);
            entity.Property(e => e.ServidorStm).IsRequired().HasMaxLength(255);
            entity.Property(e => e.ServidorLive).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Status).IsRequired();
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
