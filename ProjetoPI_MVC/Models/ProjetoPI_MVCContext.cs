namespace ProjetoPI_MVC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.Infrastructure.Annotations;
    using ProjetoPI_MVC.MetodosDeExtensao;

    public partial class ProjetoPI_MVCContext : DbContext
    {
        public ProjetoPI_MVCContext()
            : base("name=ProjetoPI_MVC")
        {
        }

        public virtual DbSet<Apoios> Apoios { get; set; }
        public virtual DbSet<Comentarios> Comentarios { get; set; }
        
        public virtual DbSet<Enderecos> Enderecos { get; set; }
        public virtual DbSet<Imagens> Imagens { get; set; }
        
        public virtual DbSet<Projetos> Projetos { get; set; }
        public virtual DbSet<Sobre> Sobre { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Voluntarios> Voluntarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apoios>()
                .HasKey(a => new { a.IdProjeto, a.IdDoador });//chave composta

            modelBuilder.Entity<Apoios>()
                .Property(e => e.Valor)
                .HasPrecision(19, 4)
                .HasColumnType("money");

            modelBuilder.Entity<Comentarios>()
                .Property(e => e.Comentario)
                .HasMaxLength(245)
                .IsUnicode(false);

            modelBuilder.Entity<Doadores>().ToTable("Doadores");

            modelBuilder.Entity<Doadores>()
                .Property(e => e.CPF)
                .HasMaxLength(11)
                .IsUnicode(false)
                .Unique("cpf_UNIQUE",0);
                        
            modelBuilder.Entity<Doadores>()
                .HasMany(e => e.Apoios)
                .WithRequired(e => e.Doadores)
                .HasForeignKey(e => e.IdDoador)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Doadores>()
                .HasMany(e => e.Voluntarios)
                .WithRequired(e => e.Doadores)
                .HasForeignKey(e => e.IdDoador)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Enderecos>()
                .Property(e => e.CEP)
                .HasMaxLength(8)
                .IsUnicode(false)
                .Unique("Endereco_UNIQUE",0);
                

            modelBuilder.Entity<Enderecos>()
                .Property(e => e.Numero)
                .HasMaxLength(10)
                .IsUnicode(false)
                .Unique("Endereco_UNIQUE",1);

            modelBuilder.Entity<Enderecos>()
                .Property(e => e.Bairro)
                .HasMaxLength(45)
                .IsUnicode(false)
                .Unique("Endereco_UNIQUE", 2);

            modelBuilder.Entity<Enderecos>()
                .Property(e => e.Rua)
                .HasMaxLength(45)
                .IsUnicode(false)
                .Unique("Endereco_UNIQUE", 3);

            modelBuilder.Entity<Enderecos>()
                .Property(e => e.Cidade)
                .HasMaxLength(45)
                .IsUnicode(false)
                .Unique("Endereco_UNIQUE", 4);

            modelBuilder.Entity<Enderecos>()
                .Property(e => e.Estado)
                .HasMaxLength(45)
                .IsUnicode(false)
                .Unique("Endereco_UNIQUE", 5);
                                    
            modelBuilder.Entity<Enderecos>()
                .HasMany(e => e.Usuarios)
                .WithRequired(e => e.Enderecos)
                .HasForeignKey(e => e.IdEndereco)
                .WillCascadeOnDelete(false);
                
            modelBuilder.Entity<Imagens>()
                .Property(e => e.Nome)
                .Unique("nome_UNIQUE",0)
                .IsUnicode(false);

            modelBuilder.Entity<Imagens>()
                .HasMany(e => e.Projetos)
                .WithRequired(e => e.Imagens)
                .HasForeignKey(e => e.Banner)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Imagens>()
                .HasMany(e => e.Sobre)
                .WithOptional(e => e.Imagens)
                .HasForeignKey(e => e.idImagem);

            modelBuilder.Entity<Imagens>()
                .HasMany(e => e.Usuarios)
                .WithRequired(e => e.Imagens)
                .HasForeignKey(e => e.IdImagem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ongs>().ToTable("Ongs");

            modelBuilder.Entity<Ongs>()
                .Property(e => e.RazaoSocial)
                .IsUnicode(false)
                .Unique("razaoSocial_UNIQUE",0);

            modelBuilder.Entity<Ongs>()
                .Property(e => e.CNPJ)
                .IsUnicode(false)
                .Unique("cnpj_UNIQUE", 0);

            modelBuilder.Entity<Ongs>()
                .Property(e => e.Telefone)
                .IsUnicode(false)
                .Unique("telefone_UNIQUE", 0);

            modelBuilder.Entity<Ongs>()
                .Property(e => e.Representante)
                .IsUnicode(false);

            modelBuilder.Entity<Ongs>()
                .Property(e => e.Cargo)
                .IsUnicode(false);

            modelBuilder.Entity<Ongs>()
                .HasMany(e => e.Voluntarios)
                .WithRequired(e => e.Ongs)
                .HasForeignKey(e => e.IdOng)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Projetos>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Projetos>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Projetos>()
                .Property(e => e.Meta)
                .IsUnicode(false);

            modelBuilder.Entity<Projetos>()
                .Property(e => e.Tipo)
                .IsUnicode(false);

            modelBuilder.Entity<Projetos>()
                .Property(e => e.Arrecadado)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Projetos>()
                .HasMany(e => e.Apoios)
                .WithRequired(e => e.Projetos)
                .HasForeignKey(e => e.IdProjeto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Projetos>()
                .HasMany(e => e.Comentarios)
                .WithRequired(e => e.Projetos)
                .HasForeignKey(e => e.IdProjeto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sobre>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Sobre>()
                .Property(e => e.Texto)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Email)
                .IsUnicode(false)
                .Unique("email_UNIQUE", 0); ;

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Senha)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Frase)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .HasMany(e => e.Comentarios)
                .WithRequired(e => e.Usuarios)
                .HasForeignKey(e => e.IdUsuario)
                .WillCascadeOnDelete(false);

            
            modelBuilder.Entity<Usuarios>()
                .HasMany(e => e.Projetos)
                .WithRequired(e => e.Usuarios)
                .HasForeignKey(e => e.IdUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuarios>()
                .HasMany(e => e.Sobre)
                .WithRequired(e => e.Usuarios)
                .HasForeignKey(e => e.idUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Voluntarios>()
                .HasKey(v => new { v.IdOng, v.IdDoador });

            modelBuilder.Entity<Voluntarios>()
                .Property(e => e.Situacao)
                .IsUnicode(false);
        }
    }
}
