namespace TaLimpoApp.Migrations
{
  using System;
  using System.Data.Entity;
  using System.Data.Entity.Migrations;
  using System.Linq;

  internal sealed class Configuration : DbMigrationsConfiguration<TaLimpoApp.Models.TaLimpoAppContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(TaLimpoApp.Models.TaLimpoAppContext context)
    {
      //  This method will be called after migrating to the latest version.

      //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
      //  to avoid creating duplicate seed data. E.g.
      //
      //    context.People.AddOrUpdate(
      //      p => p.FullName,
      //      new Person { FullName = "Andrew Peters" },
      //      new Person { FullName = "Brice Lambson" },
      //      new Person { FullName = "Rowan Miller" }
      //    );
      //
      context.LoginModels.Add(new MvcApplication6.Controllers.LoginModel { UserName = "GerenteAdmin", UserPassword = "1234", Gerente = true });
      context.LoginModels.Add(new MvcApplication6.Controllers.LoginModel { UserName = "ClienteAdmin", UserPassword = "1234", Cliente = true });
      context.LoginModels.Add(new MvcApplication6.Controllers.LoginModel { UserName = "VendedorAdmin", UserPassword = "1234", Vendedor = true });
    }
  }
}
