namespace ProjetoPI_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueAoCPF : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Apoios", new[] { "idProjeto" });
            DropIndex("dbo.Apoios", new[] { "idDoador" });
            DropIndex("dbo.Comentarios", new[] { "idUsuario" });
            DropIndex("dbo.Comentarios", new[] { "idProjeto" });
            CreateIndex("dbo.Apoios", "IdProjeto");
            CreateIndex("dbo.Apoios", "IdDoador");
            CreateIndex("dbo.Comentarios", "IdUsuario");
            CreateIndex("dbo.Comentarios", "IdProjeto");
            CreateIndex("dbo.Doadores", "CPF", unique: true, name: "cpf_UNIQUE");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Doadores", "cpf_UNIQUE");
            DropIndex("dbo.Comentarios", new[] { "IdProjeto" });
            DropIndex("dbo.Comentarios", new[] { "IdUsuario" });
            DropIndex("dbo.Apoios", new[] { "IdDoador" });
            DropIndex("dbo.Apoios", new[] { "IdProjeto" });
            CreateIndex("dbo.Comentarios", "idProjeto");
            CreateIndex("dbo.Comentarios", "idUsuario");
            CreateIndex("dbo.Apoios", "idDoador");
            CreateIndex("dbo.Apoios", "idProjeto");
        }
    }
}
