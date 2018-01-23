namespace TaLimpoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pessoas", "Nascimento");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pessoas", "Nascimento", c => c.DateTime(nullable: false));
        }
    }
}
