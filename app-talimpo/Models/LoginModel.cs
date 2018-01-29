using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace app_talimpo.Models
{
  public class LoginModel
  {
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string UserPassword { get; set; }
    public bool Gerente { get; set; }
    public bool Cliente { get; set; }
    public bool Vendedor { get; set; }

    public LoginModel()
    {
      this.Id = Guid.NewGuid();
    }
  }
}
