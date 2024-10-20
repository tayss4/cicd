using Fiap.Web.Trafego.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Trafego.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Cruzamento> Cruzamentos { get; set; }
        public virtual DbSet<HorarioPico> HorariosPico { get; set; }
        public virtual DbSet<Previsao> Previsoes { get; set; }
        public virtual DbSet<Registro> Registros { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cruzamento>(e =>
            {
                e.ToTable("CRUZAMENTO");
                e.HasKey(e => e.CruzamentoId);
                e.Property(e => e.Rua1).IsRequired().HasMaxLength(50);
                e.Property(e => e.Rua2).IsRequired().HasMaxLength(50);

                e.HasIndex(e => new { e.Rua1, e.Rua2 })
                .HasName("IDX_RUAS");
            });

            modelBuilder.Entity<HorarioPico>(e =>
            {
                e.ToTable("HORARIOPICO");
                e.HasKey(e => e.HorarioPicoId);
                e.Property(e => e.HoraInicio).IsRequired();
                e.Property(e => e.HoraTermino).IsRequired();

                e.HasOne(e => e.Cruzamento)
                .WithMany()
                .HasForeignKey(e => e.CruzamentoId)
                .IsRequired();
            });

            modelBuilder.Entity<Previsao>(e =>
            {
                e.ToTable("PREVISAO");
                e.HasKey(e => e.PrevisaoId);
                e.Property(e => e.Hora).IsRequired();
                e.Property(e => e.MelhorAlternativa);
                e.Property(e => e.NumeroCarros).IsRequired();

                e.HasOne(e => e.Cruzamento)
                .WithMany()
                .HasForeignKey(e => e.CruzamentoId)
                .IsRequired();
            });

            modelBuilder.Entity<Registro>(e =>
            {
                e.ToTable("REGISTRO");
                e.HasKey(e => e.RegistroId);
                e.Property(e => e.HoraAbertura).IsRequired();
                e.Property(e => e.HoraFechamento).IsRequired();
                e.Property(e => e.NumeroCarros).IsRequired();

                e.HasOne(e => e.Cruzamento)
                .WithMany()
                .HasForeignKey(e => e.CruzamentoId)
                .IsRequired();
            });

        }
                public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        protected DatabaseContext()
        {
        }
    }
}
