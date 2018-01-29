using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app_talimpo.Models
{
  public class Vendedor
  {
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; }
    public int CPF { get; set; }
    public DateTime Nascimento { get; set; } = DateTime.Now;
  }
}
