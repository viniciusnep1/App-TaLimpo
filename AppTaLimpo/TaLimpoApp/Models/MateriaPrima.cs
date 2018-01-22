using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaLimpoApp.Models
{
  public class MateriaPrima
  {
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; }
    public string Tipo { get; set; }
    public string Descricao { get; set; }
  }
}
