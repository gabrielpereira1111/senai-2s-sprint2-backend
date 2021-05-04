using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai.spmed.webApi.Domains;

#nullable disable

namespace senai.spmed.webApi.Contexts
{
    public partial class SPMedContext : DbContext
    {
        public SPMedContext()
        {
        }

        public SPMedContext(DbContextOptions<SPMedContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clinica> Clinicas { get; set; }
        public virtual DbSet<Consulta> Consultas { get; set; }
        public virtual DbSet<Especialidade> Especialidades { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<TiposUsuario> TiposUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = DSK_PHD001\\SQLEXPRESS; initial catalog= SP_MED_GROUP;user Id = sa;pwd = senai@132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.Idclinicas)
                    .HasName("PK__clinicas__7ACE69EF3C71D976");

                entity.ToTable("clinicas");

                entity.HasIndex(e => e.Endereco, "UQ__clinicas__9456D4067E5A46D0")
                    .IsUnique();

                entity.HasIndex(e => e.RazaoSocial, "UQ__clinicas__9BF93A30BD176EE5")
                    .IsUnique();

                entity.HasIndex(e => e.Cnpj, "UQ__clinicas__AA57D6B4924931E8")
                    .IsUnique();

                entity.Property(e => e.Idclinicas).HasColumnName("idclinicas");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ")
                    .IsFixedLength(true);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("endereco");

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nomeFantasia");

                entity.Property(e => e.RazaoSocial)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("razaoSocial");
            });

            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.HasKey(e => e.Idconsultas)
                    .HasName("PK__consulta__2244BACA7F174D5F");

                entity.ToTable("consultas");

                entity.Property(e => e.Idconsultas).HasColumnName("idconsultas");

                entity.Property(e => e.DataConsulta)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("dataConsulta");

                entity.Property(e => e.Idmedicos).HasColumnName("idmedicos");

                entity.Property(e => e.Idpacientes).HasColumnName("idpacientes");

                entity.Property(e => e.Situacao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("situacao");
                

                entity.HasOne(d => d.IdmedicosNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.Idmedicos)
                    .HasConstraintName("FK__consultas__idmed__3A81B327");

                entity.HasOne(d => d.IdpacientesNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.Idpacientes)
                    .HasConstraintName("FK__consultas__idpac__3B75D760");
            });

            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.HasKey(e => e.Idespecialidades)
                    .HasName("PK__especial__A8D84D286CFC91C6");

                entity.ToTable("especialidades");

                entity.Property(e => e.Idespecialidades).HasColumnName("idespecialidades");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.Idmedicos)
                    .HasName("PK__medicos__F4E64039F7DE016C");

                entity.ToTable("medicos");

                entity.Property(e => e.Idmedicos).HasColumnName("idmedicos");

                entity.Property(e => e.Crm)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CRM")
                    .IsFixedLength(true);

                entity.Property(e => e.Idclinicas).HasColumnName("idclinicas");

                entity.Property(e => e.Idespecialidades).HasColumnName("idespecialidades");

                entity.Property(e => e.Idusuarios).HasColumnName("idusuarios");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.HasOne(d => d.IdclinicasNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.Idclinicas)
                    .HasConstraintName("FK__medicos__idclini__32E0915F");

                entity.HasOne(d => d.IdespecialidadesNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.Idespecialidades)
                    .HasConstraintName("FK__medicos__idespec__31EC6D26");

                entity.HasOne(d => d.IdusuariosNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.Idusuarios)
                    .HasConstraintName("FK__medicos__idusuar__33D4B598");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.Idpacientes)
                    .HasName("PK__paciente__736AFA5F84E2D189");

                entity.ToTable("pacientes");

                entity.HasIndex(e => e.Cpf, "UQ__paciente__C1F8973118A14AE0")
                    .IsUnique();

                entity.Property(e => e.Idpacientes).HasColumnName("idpacientes");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CPF")
                    .IsFixedLength(true);

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("date")
                    .HasColumnName("dataNascimento");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("endereco");

                entity.Property(e => e.Idusuarios).HasColumnName("idusuarios");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RG")
                    .IsFixedLength(true);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("telefone")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdusuariosNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.Idusuarios)
                    .HasConstraintName("FK__pacientes__idusu__37A5467C");
            });

            modelBuilder.Entity<TiposUsuario>(entity =>
            {
                entity.HasKey(e => e.IdtiposUsuarios)
                    .HasName("PK__tiposUsu__13F81BBFF6754505");

                entity.ToTable("tiposUsuarios");

                entity.HasIndex(e => e.Tipo, "UQ__tiposUsu__E7F956492914A79A")
                    .IsUnique();

                entity.Property(e => e.IdtiposUsuarios).HasColumnName("idtiposUsuarios");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuarios)
                    .HasName("PK__usuarios__500509C0832A2A2D");

                entity.ToTable("usuarios");

                entity.HasIndex(e => e.Email, "UQ__usuarios__AB6E61643A0BA938")
                    .IsUnique();

                entity.Property(e => e.Idusuarios).HasColumnName("idusuarios");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdtiposUsuarios).HasColumnName("idtiposUsuarios");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdtiposUsuariosNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdtiposUsuarios)
                    .HasConstraintName("FK__usuarios__idtipo__2F10007B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
