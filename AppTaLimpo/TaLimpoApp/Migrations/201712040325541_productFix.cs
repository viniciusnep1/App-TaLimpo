namespace TaLimpoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MateriaPrimas", "Produto_Id", "dbo.Produtoes");
            DropIndex("dbo.MateriaPrimas", new[] { "Produto_Id" });
            AddColumn("dbo.Produtoes", "Descricao", c => c.String());
            DropColumn("dbo.MateriaPrimas", "Produto_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MateriaPrimas", "Produto_Id", c => c.Guid());
            DropColumn("dbo.Produtoes", "Descricao");
            CreateIndex("dbo.MateriaPrimas", "Produto_Id");
            AddForeignKey("dbo.MateriaPrimas", "Produto_Id", "dbo.Produtoes", "Id");
        }
    }
}
