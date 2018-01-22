using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TaLimpoApp.Models
{
  public class TaLimpoAppContext : DbContext
  {
    // You can add custom code to this file. Changes will not be overwritten.
    // 
    // If you want Entity Framework to drop and regenerate your database
    // automatically whenever you change your model schema, please use data migrations.
    // For more information refer to the documentation:
    // http://msdn.microsoft.com/en-us/data/jj591621.aspx

    public TaLimpoAppContext() : base("name=TaLimpoAppContext")
    {
    }



    public DbSet<MvcApplication6.Controllers.LoginModel> LoginModels { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Pessoa> Pessoas { get; set; }
    public DbSet<Produto>Produtos { get; set; }
    public DbSet<Vendedor> Vendedores { get; set; }
    public DbSet<Gerente> Gerentes { get; set; }
    public DbSet<MateriaPrima> MateriaPrimas { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }






  }
}
