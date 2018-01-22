namespace TaLimpoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoginModels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserName = c.String(),
                        UserPassword = c.String(),
                        Gerente = c.Boolean(nullable: false),
                        Cliente = c.Boolean(nullable: false),
                        Vendedor = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LoginModels");
        }
    }
}
