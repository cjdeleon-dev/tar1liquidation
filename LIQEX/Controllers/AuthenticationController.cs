using LIQEX.DataAccess;
using LIQEX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LIQEX.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginModel ulm)
        {
            AuthUtil au = new AuthUtil();
            ProcessModel pm = new ProcessModel();
            pm = au.isLoginSuccess(ulm);
            if (pm.IsProcessSuccess)
            {
                FormsAuthentication.SetAuthCookie(pm.Id.ToString(), false);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ModelState.AddModelError("CredentialError", pm.Message);
                return View("Login");
            }
                
        }

        public ActionResult Logout()
        {
            System.Web.HttpContext.Current.Session.RemoveAll();
            System.Web.HttpContext.Current.Session.Clear();
            System.Web.HttpContext.Current.Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Authentication");
        }
    }
}