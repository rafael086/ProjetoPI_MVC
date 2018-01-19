namespace ProjetoPI_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VoltaAoNormal : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Usuarios", new[] { "idEndereco" });
            DropIndex("dbo.Usuarios", new[] { "idImagem" });
            AlterColumn("dbo.Usuarios", "idEndereco", c => c.Int(nullable: false));
            AlterColumn("dbo.Usuarios", "idImagem", c => c.Int(nullable: false));
            CreateIndex("dbo.Usuarios", "idEndereco");
            CreateIndex("dbo.Usuarios", "idImagem");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Usuarios", new[] { "idImagem" });
            DropIndex("dbo.Usuarios", new[] { "idEndereco" });
            AlterColumn("dbo.Usuarios", "idImagem", c => c.Int());
            AlterColumn("dbo.Usuarios", "idEndereco", c => c.Int());
            CreateIndex("dbo.Usuarios", "idImagem");
            CreateIndex("dbo.Usuarios", "idEndereco");
        }
    }
}
