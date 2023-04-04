using LIQEX.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LIQEX.Controllers
{
    public class LoggedUserController : Controller
    {
        // GET: LoggedUser
        public PartialViewResult UserInfo()
        {
            PViewUtil pvu = new PViewUtil();

            int id = Convert.ToInt32(User.Identity.Name);

            return PartialView(pvu.GetLoggedUserInfoById(id));
        }
    }
}