using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app_talimpo.Models
{
  public class Pedido
  {
    public Guid Id { get; set; } = Guid.NewGuid();
    public int Quantidade { get; set; }
    public string Situacao { get; set; }
    public double Preco { get; set; }
    public List<Produto> Produtos { get; set; }

  }
}
