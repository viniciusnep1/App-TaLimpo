namespace app_talimpo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixpedidos2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MateriaPrimas", "Produto_Id", "dbo.Produtoes");
            DropIndex("dbo.MateriaPrimas", new[] { "Produto_Id" });
            DropColumn("dbo.MateriaPrimas", "Produto_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MateriaPrimas", "Produto_Id", c => c.Guid());
            CreateIndex("dbo.MateriaPrimas", "Produto_Id");
            AddForeignKey("dbo.MateriaPrimas", "Produto_Id", "dbo.Produtoes", "Id");
        }
    }
}
