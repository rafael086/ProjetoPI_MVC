namespace ProjetoPI_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Teste : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Apoios",
                c => new
                    {
                        idProjeto = c.Int(nullable: false),
                        idDoador = c.Int(nullable: false),
                        valor = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => new { t.idProjeto, t.idDoador })
                .ForeignKey("dbo.Ongs", t => t.idDoador)
                .ForeignKey("dbo.Projetos", t => t.idProjeto)
                .Index(t => t.idProjeto)
                .Index(t => t.idDoador);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 45, unicode: false),
                        email = c.String(nullable: false, maxLength: 100, unicode: false),
                        senha = c.String(nullable: false, maxLength: 45, unicode: false),
                        idEndereco = c.Int(),
                        idImagem = c.Int(),
                        frase = c.String(maxLength: 100, unicode: false),
                        razaoSocial = c.String(maxLength: 45, unicode: false),
                        cnpj = c.String(maxLength: 14, unicode: false),
                        telefone = c.String(maxLength: 10, unicode: false),
                        representante = c.String(maxLength: 45, unicode: false),
                        cargo = c.String(maxLength: 45, unicode: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Enderecos", t => t.idEndereco)
                .ForeignKey("dbo.Imagens", t => t.idImagem)
                .Index(t => t.idEndereco)
                .Index(t => t.idImagem);
            
            CreateTable(
                "dbo.Comentarios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        comentario = c.String(nullable: false, maxLength: 245, unicode: false),
                        idUsuario = c.Int(nullable: false),
                        idProjeto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Projetos", t => t.idProjeto)
                .ForeignKey("dbo.Usuarios", t => t.idUsuario)
                .Index(t => t.idUsuario)
                .Index(t => t.idProjeto);
            
            CreateTable(
                "dbo.Projetos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 45, unicode: false),
                        descricao = c.String(nullable: false, unicode: false),
                        banner = c.Int(nullable: false),
                        meta = c.String(nullable: false, maxLength: 45, unicode: false),
                        idUsuario = c.Int(nullable: false),
                        tipo = c.String(nullable: false, maxLength: 10, unicode: false),
                        arrecadado = c.Decimal(nullable: false, storeType: "money"),
                        finalizado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Imagens", t => t.banner)
                .ForeignKey("dbo.Usuarios", t => t.idUsuario)
                .Index(t => t.banner)
                .Index(t => t.idUsuario);
            
            CreateTable(
                "dbo.Imagens",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 45, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Sobre",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        titulo = c.String(nullable: false, maxLength: 45, unicode: false),
                        texto = c.String(nullable: false, unicode: false),
                        idUsuario = c.Int(nullable: false),
                        idImagem = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Usuarios", t => t.idUsuario)
                .ForeignKey("dbo.Imagens", t => t.idImagem)
                .Index(t => t.idUsuario)
                .Index(t => t.idImagem);
            
            CreateTable(
                "dbo.Enderecos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cep = c.String(nullable: false, maxLength: 8, unicode: false),
                        numero = c.String(nullable: false, maxLength: 10, unicode: false),
                        bairro = c.String(nullable: false, maxLength: 45, unicode: false),
                        rua = c.String(nullable: false, maxLength: 45, unicode: false),
                        cidade = c.String(nullable: false, maxLength: 45, unicode: false),
                        estado = c.String(nullable: false, maxLength: 45, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Voluntarios",
                c => new
                    {
                        idOng = c.Int(nullable: false),
                        idDoador = c.Int(nullable: false),
                        situacao = c.String(nullable: false, maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => new { t.idOng, t.idDoador })
                .ForeignKey("dbo.Usuarios", t => t.idOng)
                .ForeignKey("dbo.Ongs", t => t.idDoador)
                .Index(t => t.idOng)
                .Index(t => t.idDoador);
            
            CreateTable(
                "dbo.Ongs",
                c => new
                    {
                        id = c.Int(nullable: false),
                        cpf = c.String(nullable: false, maxLength: 11, unicode: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Usuarios", t => t.id)
                .Index(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ongs", "id", "dbo.Usuarios");
            DropForeignKey("dbo.Voluntarios", "idDoador", "dbo.Ongs");
            DropForeignKey("dbo.Usuarios", "idImagem", "dbo.Imagens");
            DropForeignKey("dbo.Sobre", "idImagem", "dbo.Imagens");
            DropForeignKey("dbo.Voluntarios", "idOng", "dbo.Usuarios");
            DropForeignKey("dbo.Sobre", "idUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Projetos", "idUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "idEndereco", "dbo.Enderecos");
            DropForeignKey("dbo.Comentarios", "idUsuario", "dbo.Usuarios");
            DropForeignKey("dbo.Projetos", "banner", "dbo.Imagens");
            DropForeignKey("dbo.Comentarios", "idProjeto", "dbo.Projetos");
            DropForeignKey("dbo.Apoios", "idProjeto", "dbo.Projetos");
            DropForeignKey("dbo.Apoios", "idDoador", "dbo.Ongs");
            DropIndex("dbo.Ongs", new[] { "id" });
            DropIndex("dbo.Voluntarios", new[] { "idDoador" });
            DropIndex("dbo.Voluntarios", new[] { "idOng" });
            DropIndex("dbo.Sobre", new[] { "idImagem" });
            DropIndex("dbo.Sobre", new[] { "idUsuario" });
            DropIndex("dbo.Projetos", new[] { "idUsuario" });
            DropIndex("dbo.Projetos", new[] { "banner" });
            DropIndex("dbo.Comentarios", new[] { "idProjeto" });
            DropIndex("dbo.Comentarios", new[] { "idUsuario" });
            DropIndex("dbo.Usuarios", new[] { "idImagem" });
            DropIndex("dbo.Usuarios", new[] { "idEndereco" });
            DropIndex("dbo.Apoios", new[] { "idDoador" });
            DropIndex("dbo.Apoios", new[] { "idProjeto" });
            DropTable("dbo.Ongs");
            DropTable("dbo.Voluntarios");
            DropTable("dbo.Enderecos");
            DropTable("dbo.Sobre");
            DropTable("dbo.Imagens");
            DropTable("dbo.Projetos");
            DropTable("dbo.Comentarios");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Apoios");
        }
    }
}
