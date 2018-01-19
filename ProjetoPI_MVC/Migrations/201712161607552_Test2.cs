namespace ProjetoPI_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Ongs", newName: "Doadores");
            CreateTable(
                "dbo.Ongs",
                c => new
                    {
                        id = c.Int(nullable: false),
                        razaoSocial = c.String(nullable: false, maxLength: 45, unicode: false),
                        cnpj = c.String(nullable: false, maxLength: 14, unicode: false),
                        telefone = c.String(nullable: false, maxLength: 10, unicode: false),
                        representante = c.String(maxLength: 45, unicode: false),
                        cargo = c.String(maxLength: 45, unicode: false),
                    })
                .PrimaryKey(t => t.id)
                .Index(t => t.id);
            
            AddForeignKey("dbo.Doadores", "id", "dbo.Usuarios", "id");
            DropColumn("dbo.Usuarios", "razaoSocial");
            DropColumn("dbo.Usuarios", "cnpj");
            DropColumn("dbo.Usuarios", "telefone");
            DropColumn("dbo.Usuarios", "representante");
            DropColumn("dbo.Usuarios", "cargo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "cargo", c => c.String(maxLength: 45, unicode: false));
            AddColumn("dbo.Usuarios", "representante", c => c.String(maxLength: 45, unicode: false));
            AddColumn("dbo.Usuarios", "telefone", c => c.String(maxLength: 10, unicode: false));
            AddColumn("dbo.Usuarios", "cnpj", c => c.String(maxLength: 14, unicode: false));
            AddColumn("dbo.Usuarios", "razaoSocial", c => c.String(maxLength: 45, unicode: false));
            DropForeignKey("dbo.Doadores", "id", "dbo.Usuarios");
            DropIndex("dbo.Ongs", new[] { "id" });
            DropTable("dbo.Ongs");
            RenameTable(name: "dbo.Doadores", newName: "Ongs");
        }
    }
}
