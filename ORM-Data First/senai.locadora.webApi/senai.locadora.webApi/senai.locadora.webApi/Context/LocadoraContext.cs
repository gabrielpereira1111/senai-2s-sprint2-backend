using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai.locadora.webApi.Domains;

#nullable disable

namespace senai.locadora.webApi.Context
{
    public partial class LocadoraContext : DbContext
    {
        public LocadoraContext()
        {
        }

        public LocadoraContext(DbContextOptions<LocadoraContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aluguei> Alugueis { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Veiculo> Veiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source= DSK_PHD001\\SQLEXPRESS; Initial Catalog=Locadora; user Id=sa; pwd=senai@132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Aluguei>(entity =>
            {
                entity.HasKey(e => e.IdAlugueis)
                    .HasName("PK__Alugueis__DA9DD5D2D48B716E");

                entity.Property(e => e.IdAlugueis).HasColumnName("idAlugueis");

                entity.Property(e => e.DataEntrega).HasColumnType("date");

                entity.Property(e => e.DataRetirada).HasColumnType("date");

                entity.Property(e => e.IdClientes).HasColumnName("idClientes");

                entity.Property(e => e.IdVeiculos).HasColumnName("idVeiculos");

                entity.Property(e => e.ValorAluguel).HasColumnType("smallmoney");

                entity.HasOne(d => d.IdClientesNavigation)
                    .WithMany(p => p.Alugueis)
                    .HasForeignKey(d => d.IdClientes)
                    .HasConstraintName("FK__Alugueis__idClie__47DBAE45");

                entity.HasOne(d => d.IdVeiculosNavigation)
                    .WithMany(p => p.Alugueis)
                    .HasForeignKey(d => d.IdVeiculos)
                    .HasConstraintName("FK__Alugueis__idVeic__3B75D760");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__885457EE0C5543C8");

                entity.ToTable("Cliente");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.IdAlugueis).HasColumnName("idAlugueis");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RG");

                entity.Property(e => e.Telefones)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAlugueisNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdAlugueis)
                    .HasConstraintName("FK__Cliente__idAlugu__412EB0B6");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PK__Empresa__75D2CED48BB02D7E");

                entity.ToTable("Empresa");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Veiculo>(entity =>
            {
                entity.HasKey(e => e.IdVeiculos)
                    .HasName("PK__Veiculos__97A3EB655BF674F5");

                entity.Property(e => e.IdVeiculos).HasColumnName("idVeiculos");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.Marcas)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Modelos)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Placas)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Veiculos)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK__Veiculos__idEmpr__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
