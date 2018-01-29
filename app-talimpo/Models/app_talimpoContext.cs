using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace app_talimpo.Models
{
    public class app_talimpoContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public app_talimpoContext() : base("name=app_talimpoContext")
        {
        }

    public System.Data.Entity.DbSet<app_talimpo.Models.LoginModel> Login { get; set; }
    public System.Data.Entity.DbSet<app_talimpo.Models.Cliente> Clientes { get; set; }
    public System.Data.Entity.DbSet<app_talimpo.Models.Gerente> Gerentes { get; set; }
    public System.Data.Entity.DbSet<app_talimpo.Models.Pedido> Pedidos { get; set; }
    public System.Data.Entity.DbSet<app_talimpo.Models.Pessoa> Pessoas { get; set; }
    public System.Data.Entity.DbSet<app_talimpo.Models.Produto> Produtos { get; set; }
    public System.Data.Entity.DbSet<app_talimpo.Models.Vendedor> Vendedors { get; set; }
    public System.Data.Entity.DbSet<app_talimpo.Models.MateriaPrima> MateriaPrimas { get; set; }
    public object LoginModels { get; internal set; }
  }
}
