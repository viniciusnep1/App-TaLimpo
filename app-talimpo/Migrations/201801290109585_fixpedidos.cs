namespace app_talimpo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixpedidos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedidoes", "Preco", c => c.Double(nullable: false));
            AddColumn("dbo.Produtoes", "Preco", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Produtoes", "Preco");
            DropColumn("dbo.Pedidoes", "Preco");
        }
    }
}
