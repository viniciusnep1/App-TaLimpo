using System;
using System.Collections.Generic;

namespace TaLimpoApp.Models
{
  public class Produto
  {
    public Guid Id { get; set; }
    public int Quantidade { get; set; }
    public string Situacao { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }

    public Produto()
    {
      this.Id = Guid.NewGuid();
    }

  }
}
