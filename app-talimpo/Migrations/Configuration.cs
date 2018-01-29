namespace app_talimpo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<app_talimpo.Models.app_talimpoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(app_talimpo.Models.app_talimpoContext context)
        {
      //  This method will be called after migrating to the latest version.

      //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
      //  to avoid creating duplicate seed data.
      context.Login.AddOrUpdate(new Models.LoginModel { UserName = "GerenteAdmin", UserPassword = "1234", Gerente = true });
      context.Login.AddOrUpdate(new Models.LoginModel { UserName = "ClienteAdmin", UserPassword = "1234", Gerente = true });
      context.Login.AddOrUpdate(new Models.LoginModel { UserName = "VendedorAdmin", UserPassword = "1234", Gerente = true });
    }
  }
}
