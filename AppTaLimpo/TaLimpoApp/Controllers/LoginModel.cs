using System;

namespace MvcApplication6.Controllers
{
  public class LoginModel
  {
    public Guid Id{ get; set; }
    public string UserName { get; set; }
    public string UserPassword { get; set; }
    public bool Gerente { get; set; } = false;
    public bool Cliente { get; set; } = false;
    public bool Vendedor { get; set; } = false;

    public LoginModel()
    {
      this.Id = Guid.NewGuid();
    }
  }
}
