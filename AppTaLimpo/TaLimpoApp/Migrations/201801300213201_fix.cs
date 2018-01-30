namespace TaLimpoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MateriaPrimas", "Produto_Id", c => c.Guid());
            CreateIndex("dbo.MateriaPrimas", "Produto_Id");
            AddForeignKey("dbo.MateriaPrimas", "Produto_Id", "dbo.Produtoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MateriaPrimas", "Produto_Id", "dbo.Produtoes");
            DropIndex("dbo.MateriaPrimas", new[] { "Produto_Id" });
            DropColumn("dbo.MateriaPrimas", "Produto_Id");
        }
    }
}
