using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app_talimpo.Models
{
  public class Produto
  {
    public Guid Id { get; set; }
    public int Quantidade { get; set; }
    public double Preco { get; set; }
    public string Situacao { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    //public List<MateriaPrima> materia { get; set; }
    public Produto()
    {
      this.Id = Guid.NewGuid();
    }
  }
}
