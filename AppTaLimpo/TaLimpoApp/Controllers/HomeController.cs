using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace MvcApplication6.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      LoginModel obj = new LoginModel();
      return View(obj);
    }
    [HttpPost]
    public ActionResult Index(LoginModel objuserlogin)
    {
      var display = Userloginvalues().Where(m => m.UserName == objuserlogin.UserName && m.UserPassword == objuserlogin.UserPassword).FirstOrDefault();
      if (display != null)
      {
        ViewBag.Status = "CORRECT UserNAme and Password";
      }
      else
      {
        ViewBag.Status = "INCORRECT UserName or Password";
      }
      return View(objuserlogin);
    }
    public List<LoginModel> Userloginvalues()
    {
      List<LoginModel> objModel = new List<LoginModel>();
      objModel.Add(new LoginModel { UserName = "user1", UserPassword = "password1", Cliente = true });
      objModel.Add(new LoginModel { UserName = "user2", UserPassword = "password2", Gerente = true });
      objModel.Add(new LoginModel { UserName = "user3", UserPassword = "password3", Vendedor = true });
      return objModel;
    }
  }
}
