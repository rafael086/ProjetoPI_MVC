namespace ProjetoPI_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizaSobre : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Sobre", new[] { "idUsuario" });
            DropIndex("dbo.Sobre", new[] { "idImagem" });
            CreateIndex("dbo.Sobre", "IdUsuario");
            CreateIndex("dbo.Sobre", "IdImagem");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Sobre", new[] { "IdImagem" });
            DropIndex("dbo.Sobre", new[] { "IdUsuario" });
            CreateIndex("dbo.Sobre", "idImagem");
            CreateIndex("dbo.Sobre", "idUsuario");
        }
    }
}
