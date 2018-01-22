using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaLimpoApp.Models
{
  public class Gerente
  {
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public int CPF { get; set; }
    public DateTime Nascimento { get; set; }
    public List<Pessoa> Pessoas { get; set; }
    public List<Cliente> Clientes { get; set; }
    public List<Vendedor> Vendedores{ get; set; }

  }
}
