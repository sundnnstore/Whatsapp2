using System.Web.Mvc;
using System.Web.Security;
using Whatsapp2.Models;
using Whatsapp2.Repositories;
using Whatsapp2.Models;

namespace Whatsapp2.Controllers
{
    public class AccountController : Controller
    {
        DbAccountRepository repository = new DbAccountRepository();

        public AccountController()
        {
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Accounts accounts = repository.GetAccounts(model.Email, model.Password);
                if (accounts != null)
                {
                    FormsAuthentication.SetAuthCookie(accounts.Email, false);

                    // remember complete Accounts
                    Session["loggedin_Accounts"] = accounts;

                    // redirect to default entry of Chats controller
                    return RedirectToAction("Index", "Chats");
                }
                else
                {
                    ModelState.AddModelError("login-error", "The user name of password provided is incorrect.");
                }
            }
            // there was an error, go back to Login page
            return View(model);
        }

        public ActionResult LogOff()
        {
            if (Session["loggedin_Accounts"] == null)
                return View("Login");
            else
                return View("Logoff");
        }

        [HttpPost]
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            Session["loggedin_Accounts"] = null;

            // redirect to Login of Accounts controller
            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel reg)
        {
            if (ModelState.IsValid)
            {
                repository.AddAccounts(reg);
                return RedirectToAction("Index", "Home");
            }
            return View(reg);
        }
    }
}