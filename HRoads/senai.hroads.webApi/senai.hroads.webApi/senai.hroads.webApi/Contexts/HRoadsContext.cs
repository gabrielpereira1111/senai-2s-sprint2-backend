using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai.hroads.webApi.Domains;

#nullable disable

namespace senai.hroads.webApi.Contexts
{
    public partial class HRoadsContext : DbContext
    {
        public HRoadsContext()
        {
        }

        public HRoadsContext(DbContextOptions<HRoadsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ClassesHabilidade> ClassesHabilidades { get; set; }
        public virtual DbSet<Habilidade> Habilidades { get; set; }
        public virtual DbSet<Personagem> Personagens { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<TiposHabilidade> TiposHabilidades { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DSK_PHD001\\SQLEXPRESS; Initial Catalog=SENAI_HROADS_MANHA; user Id=sa; pwd=senai@132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.IdClasses)
                    .HasName("PK__Classes__5701067235F5751E");

                entity.Property(e => e.IdClasses).HasColumnName("idClasses");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ClassesHabilidade>(entity =>
            {
                entity.HasKey(e => e.IdClassesHabilidades)
                    .HasName("PK__ClassesH__C86EC776E9E899B3");

                entity.Property(e => e.IdClassesHabilidades).HasColumnName("idClassesHabilidades");

                entity.Property(e => e.IdClasses).HasColumnName("idClasses");

                entity.Property(e => e.IdHabilidades).HasColumnName("idHabilidades");

                entity.HasOne(d => d.IdClassesNavigation)
                    .WithMany(p => p.ClassesHabilidades)
                    .HasForeignKey(d => d.IdClasses)
                    .HasConstraintName("FK__ClassesHa__idCla__403A8C7D");

                entity.HasOne(d => d.IdHabilidadesNavigation)
                    .WithMany(p => p.ClassesHabilidades)
                    .HasForeignKey(d => d.IdHabilidades)
                    .HasConstraintName("FK__ClassesHa__idHab__412EB0B6");
            });

            modelBuilder.Entity<Habilidade>(entity =>
            {
                entity.HasKey(e => e.IdHabilidades)
                    .HasName("PK__Habilida__A5B0BFF59FAF8A91");

                entity.Property(e => e.IdHabilidades).HasColumnName("idHabilidades");

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Habilidades)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK__Habilidad__idTip__38996AB5");
            });

            modelBuilder.Entity<Personagem>(entity =>
            {
                entity.HasKey(e => e.IdPersonagens)
                    .HasName("PK__Personag__F43A00D17AF5AD0D");

                entity.Property(e => e.IdPersonagens).HasColumnName("idPersonagens");

                entity.Property(e => e.DataAtualizacao).HasColumnType("date");

                entity.Property(e => e.DataCriacao).HasColumnType("date");

                entity.Property(e => e.IdClasses).HasColumnName("idClasses");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClassesNavigation)
                    .WithMany(p => p.Personagens)
                    .HasForeignKey(d => d.IdClasses)
                    .HasConstraintName("FK__Personage__idCla__440B1D61");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__tipoUsua__03006BFF462EFCB2");

                entity.ToTable("tipoUsuario");

                entity.HasIndex(e => e.Titulo, "UQ__tipoUsua__38FA640F13835083")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("titulo");
            });

            modelBuilder.Entity<TiposHabilidade>(entity =>
            {
                entity.HasKey(e => e.IdTipo)
                    .HasName("PK__TiposHab__BDD0DFE13FDA7179");

                entity.ToTable("TiposHabilidade");

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuarios)
                    .HasName("PK__Usuarios__3940559A22F455E8");

                entity.HasIndex(e => e.Email, "UQ__Usuarios__AB6E61641E2BB3C6")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "idx_clienteemail")
                    .IsUnique()
                    .HasFilter("([email] IS NOT NULL)");

                entity.Property(e => e.IdUsuarios).HasColumnName("idUsuarios");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuarios__idTipo__0A9D95DB");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
