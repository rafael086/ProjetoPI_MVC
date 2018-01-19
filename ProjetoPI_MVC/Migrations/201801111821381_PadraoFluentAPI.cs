namespace ProjetoPI_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PadraoFluentAPI : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Usuarios", new[] { "idEndereco" });
            DropIndex("dbo.Usuarios", new[] { "idImagem" });
            DropIndex("dbo.Projetos", new[] { "banner" });
            DropIndex("dbo.Projetos", new[] { "idUsuario" });
            DropIndex("dbo.Voluntarios", new[] { "idOng" });
            DropIndex("dbo.Voluntarios", new[] { "idDoador" });
            DropIndex("dbo.Doadores", new[] { "id" });
            DropIndex("dbo.Ongs", new[] { "id" });
            AlterColumn("dbo.Ongs", "Representante", c => c.String(nullable: false, maxLength: 45, unicode: false));
            AlterColumn("dbo.Ongs", "Cargo", c => c.String(nullable: false, maxLength: 45, unicode: false));
            CreateIndex("dbo.Usuarios", "Email", unique: true, name: "email_UNIQUE");
            CreateIndex("dbo.Usuarios", "IdEndereco");
            CreateIndex("dbo.Usuarios", "IdImagem");
            CreateIndex("dbo.Projetos", "Banner");
            CreateIndex("dbo.Projetos", "IdUsuario");
            CreateIndex("dbo.Imagens", "Nome", unique: true, name: "nome_UNIQUE");
            CreateIndex("dbo.Enderecos", new[] { "CEP", "Numero", "Bairro", "Rua", "Cidade", "Estado" }, unique: true, name: "Endereco_UNIQUE");
            CreateIndex("dbo.Voluntarios", "IdOng");
            CreateIndex("dbo.Voluntarios", "IdDoador");
            CreateIndex("dbo.Doadores", "Id");
            CreateIndex("dbo.Ongs", "Id");
            CreateIndex("dbo.Ongs", "RazaoSocial", unique: true, name: "razaoSocial_UNIQUE");
            CreateIndex("dbo.Ongs", "CNPJ", unique: true, name: "cnpj_UNIQUE");
            CreateIndex("dbo.Ongs", "Telefone", unique: true, name: "telefone_UNIQUE");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Ongs", "telefone_UNIQUE");
            DropIndex("dbo.Ongs", "cnpj_UNIQUE");
            DropIndex("dbo.Ongs", "razaoSocial_UNIQUE");
            DropIndex("dbo.Ongs", new[] { "Id" });
            DropIndex("dbo.Doadores", new[] { "Id" });
            DropIndex("dbo.Voluntarios", new[] { "IdDoador" });
            DropIndex("dbo.Voluntarios", new[] { "IdOng" });
            DropIndex("dbo.Enderecos", "Endereco_UNIQUE");
            DropIndex("dbo.Imagens", "nome_UNIQUE");
            DropIndex("dbo.Projetos", new[] { "IdUsuario" });
            DropIndex("dbo.Projetos", new[] { "Banner" });
            DropIndex("dbo.Usuarios", new[] { "IdImagem" });
            DropIndex("dbo.Usuarios", new[] { "IdEndereco" });
            DropIndex("dbo.Usuarios", "email_UNIQUE");
            AlterColumn("dbo.Ongs", "Cargo", c => c.String(maxLength: 45, unicode: false));
            AlterColumn("dbo.Ongs", "Representante", c => c.String(maxLength: 45, unicode: false));
            CreateIndex("dbo.Ongs", "id");
            CreateIndex("dbo.Doadores", "id");
            CreateIndex("dbo.Voluntarios", "idDoador");
            CreateIndex("dbo.Voluntarios", "idOng");
            CreateIndex("dbo.Projetos", "idUsuario");
            CreateIndex("dbo.Projetos", "banner");
            CreateIndex("dbo.Usuarios", "idImagem");
            CreateIndex("dbo.Usuarios", "idEndereco");
        }
    }
}
