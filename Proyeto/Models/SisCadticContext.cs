//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;

//namespace Proyeto.Models;

//public partial class SisCadticContext : DbContext
//{
//    public SisCadticContext()
//    {
//    }

//    public SisCadticContext(DbContextOptions<SisCadticContext> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<Autor> Autors { get; set; }

//    public virtual DbSet<Categorium> Categoria { get; set; }

//    public virtual DbSet<Documento> Documentos { get; set; }

//    public virtual DbSet<DocumentoUsuario> DocumentoUsuarios { get; set; }

//    public virtual DbSet<NivelEstudio> NivelEstudios { get; set; }

//    public virtual DbSet<Usuario> Usuarios { get; set; }

//    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        //=> optionsBuilder.UseSqlServer("Server=LAPTOP-UNO2AN77\\SQLEXPRESS; Database=SisCADTIC; Trusted_Connection=True; TrustServerCertificate=True");
//           // => optionsBuilder.UseSqlServer("server=MTYDESJALANI;database=SisCADTIC;uid=sa;pwd=terra123; Trust Server Certificate=true;");

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Autor>(entity =>
//        {
//            entity.HasKey(e => e.IdAutor).HasName("PK__Autor__DD33B031365B3991");

//            entity.ToTable("Autor");

//            entity.Property(e => e.ApeMaterno)
//                .HasMaxLength(15)
//                .IsUnicode(false);
//            entity.Property(e => e.ApePaterno)
//                .HasMaxLength(15)
//                .IsUnicode(false);
//            entity.Property(e => e.AreaEstudios)
//                .HasMaxLength(40)
//                .IsUnicode(false);
//            entity.Property(e => e.CuerpoAcademico)
//                .HasMaxLength(10)
//                .IsUnicode(false);
//            entity.Property(e => e.FechaNaci).HasColumnType("date");
//            entity.Property(e => e.Nombre)
//                .HasMaxLength(40)
//                .IsUnicode(false);
//            entity.Property(e => e.NumTelefono)
//                .HasMaxLength(15)
//                .IsUnicode(false);
//            entity.Property(e => e.TipoCuenta)
//                .HasMaxLength(3)
//                .IsUnicode(false);

//            entity.HasOne(d => d.IdNivelEstudios1Navigation).WithMany(p => p.Autors)
//                .HasForeignKey(d => d.IdNivelEstudios1)
//                .HasConstraintName("fk_AutorNivEstudios");
//        });

//        modelBuilder.Entity<Categorium>(entity =>
//        {
//            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__A3C02A10DA858187");

//            entity.Property(e => e.Descripcion)
//                .HasMaxLength(150)
//                .IsUnicode(false);
//            entity.Property(e => e.Tipo)
//                .HasMaxLength(40)
//                .IsUnicode(false);
//        });

//        modelBuilder.Entity<Documento>(entity =>
//        {
//            entity.HasKey(e => e.IdDocumento).HasName("PK__Document__E5207347043DCFC9");

//            entity.ToTable("Documento");

//            entity.Property(e => e.CoAutor)
//                .HasMaxLength(40)
//                .IsUnicode(false);
//            entity.Property(e => e.Estatus)
//                .HasMaxLength(1)
//                .IsUnicode(false)
//                .IsFixedLength();
//            entity.Property(e => e.Urldocumento)
//                .HasMaxLength(200)
//                .IsUnicode(false)
//                .HasColumnName("URLDocumento");

//            entity.HasOne(d => d.IdCategoria1Navigation).WithMany(p => p.Documentos)
//                .HasForeignKey(d => d.IdCategoria1)
//                .HasConstraintName("fk_DocumentoCate");
//        });

//        modelBuilder.Entity<DocumentoUsuario>(entity =>
//        {
//            entity.HasKey(e => e.IdDu).HasName("PK__Document__B77398B79B0D6CF9");

//            entity.ToTable("DocumentoUsuario");

//            entity.Property(e => e.IdDu).HasColumnName("IdDU");
//            entity.Property(e => e.NombreUsuario1)
//                .HasMaxLength(40)
//                .IsUnicode(false);

//            entity.HasOne(d => d.IdDocumento1Navigation).WithMany(p => p.DocumentoUsuarios)
//                .HasForeignKey(d => d.IdDocumento1)
//                .HasConstraintName("fk_DocumentoUsua");

//            entity.HasOne(d => d.NombreUsuario1Navigation).WithMany(p => p.DocumentoUsuarios)
//                .HasForeignKey(d => d.NombreUsuario1)
//                .HasConstraintName("fk_UsuarioDocume");
//        });

//        modelBuilder.Entity<NivelEstudio>(entity =>
//        {
//            entity.HasKey(e => e.NivelEstudiosId).HasName("PK__NivelEst__97BF6980D280978B");

//            entity.Property(e => e.NivelEstudiosId).ValueGeneratedNever();
//            entity.Property(e => e.NombreNivel)
//                .HasMaxLength(20)
//                .IsUnicode(false);
//        });

//        modelBuilder.Entity<Usuario>(entity =>
//        {
//            entity.HasKey(e => e.NombreUsuario).HasName("PK__Usuario__6B0F5AE1E9AD702E");

//            entity.ToTable("Usuario");

//            entity.Property(e => e.NombreUsuario)
//                .HasMaxLength(40)
//                .IsUnicode(false);
//            entity.Property(e => e.Contrasena)
//                .HasMaxLength(40)
//                .IsUnicode(false);
//            entity.Property(e => e.Correo)
//                .HasMaxLength(40)
//                .IsUnicode(false);

//            entity.HasOne(d => d.IdAutor1Navigation).WithMany(p => p.Usuarios)
//                .HasForeignKey(d => d.IdAutor1)
//                .HasConstraintName("fk_CuentaAutor");
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}
