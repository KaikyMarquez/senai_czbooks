using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai_czbooks_api.Domains;

#nullable disable

namespace senai_czbooks_api.Contexts
{
    public partial class CzBooksContext : DbContext
    {
        public CzBooksContext()
        {
        }

        public CzBooksContext(DbContextOptions<CzBooksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Livro> Livros { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-M4B6U15; Initial Catalog= senai_czbooks; user Id=sa; pwd=mbc159753123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__8A3D240C2F66CC29");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.NomeCategoria)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PK__Empresa__75D2CED4E7FE16EB");

                entity.ToTable("Empresa");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Livro>(entity =>
            {
                entity.HasKey(e => e.IdLivro)
                    .HasName("PK__Livro__63C546D7B7822FD1");

                entity.ToTable("Livro");

                entity.Property(e => e.IdLivro).HasColumnName("idLivro");

                entity.Property(e => e.DataPublicacao).HasColumnType("date");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Preco)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Sinopse)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Livros)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Livro__idCategor__4316F928");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Livros)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK__Livro__idEmpresa__4222D4EF");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Livros)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Livro__idUsuario__412EB0B6");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__03006BFFAC859708");

                entity.ToTable("TipoUsuario");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A6638FFF40");

                entity.ToTable("Usuario");

                entity.HasIndex(e => e.Email, "UQ__Usuario__A9D105343992DBB6")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeUsuario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__idTipoU__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
