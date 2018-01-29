namespace app_talimpo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(),
                        CPF = c.Int(nullable: false),
                        Nascimento = c.DateTime(nullable: false),
                        Gerente_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gerentes", t => t.Gerente_Id)
                .Index(t => t.Gerente_Id);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        Situacao = c.String(),
                        Cliente_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id)
                .Index(t => t.Cliente_Id);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        Situacao = c.String(),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Pedido_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pedidoes", t => t.Pedido_Id)
                .Index(t => t.Pedido_Id);
            
            CreateTable(
                "dbo.MateriaPrimas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(),
                        Tipo = c.String(),
                        Descricao = c.String(),
                        Produto_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Produtoes", t => t.Produto_Id)
                .Index(t => t.Produto_Id);
            
            CreateTable(
                "dbo.Gerentes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(),
                        CPF = c.Int(nullable: false),
                        Nascimento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(),
                        Tipo = c.String(),
                        CPF = c.Int(nullable: false),
                        Gerente_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gerentes", t => t.Gerente_Id)
                .Index(t => t.Gerente_Id);
            
            CreateTable(
                "dbo.Vendedors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(),
                        CPF = c.Int(nullable: false),
                        Nascimento = c.DateTime(nullable: false),
                        Gerente_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gerentes", t => t.Gerente_Id)
                .Index(t => t.Gerente_Id);
            
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
            DropForeignKey("dbo.Vendedors", "Gerente_Id", "dbo.Gerentes");
            DropForeignKey("dbo.Pessoas", "Gerente_Id", "dbo.Gerentes");
            DropForeignKey("dbo.Clientes", "Gerente_Id", "dbo.Gerentes");
            DropForeignKey("dbo.Pedidoes", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.Produtoes", "Pedido_Id", "dbo.Pedidoes");
            DropForeignKey("dbo.MateriaPrimas", "Produto_Id", "dbo.Produtoes");
            DropIndex("dbo.Vendedors", new[] { "Gerente_Id" });
            DropIndex("dbo.Pessoas", new[] { "Gerente_Id" });
            DropIndex("dbo.MateriaPrimas", new[] { "Produto_Id" });
            DropIndex("dbo.Produtoes", new[] { "Pedido_Id" });
            DropIndex("dbo.Pedidoes", new[] { "Cliente_Id" });
            DropIndex("dbo.Clientes", new[] { "Gerente_Id" });
            DropTable("dbo.LoginModels");
            DropTable("dbo.Vendedors");
            DropTable("dbo.Pessoas");
            DropTable("dbo.Gerentes");
            DropTable("dbo.MateriaPrimas");
            DropTable("dbo.Produtoes");
            DropTable("dbo.Pedidoes");
            DropTable("dbo.Clientes");
        }
    }
}
