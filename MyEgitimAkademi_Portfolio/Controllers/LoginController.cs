using MyEgitimAkademi_Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyEgitimAkademi_Portfolio.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var value = db.Admin.FirstOrDefault(x=>x.UserName == admin.UserName && x.Password==admin.Password);
            if (value == null)
            {
                ModelState.AddModelError("","Kullanıcı Adı veya Şifre Hatalı");
                return View();
            }
            FormsAuthentication.SetAuthCookie(admin.UserName,false);
            Session["username"] = value.UserName.ToString();
            return RedirectToAction("Index","Service");
        }
    }
}