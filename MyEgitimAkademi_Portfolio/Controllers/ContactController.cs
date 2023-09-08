using MyEgitimAkademi_Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEgitimAkademi_Portfolio.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.description = db.Address.Select(x => x.AddressDescription).FirstOrDefault();
            ViewBag.phone = db.Address.Select(x => x.AddressPhone).FirstOrDefault();
            ViewBag.addressDetail = db.Address.Select(x => x.AddressLocation).FirstOrDefault();
            ViewBag.mail = db.Address.Select(x => x.AddressMail).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            db.Contact.Add(contact);
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }

        public ActionResult MessageList()
        {
            var values = db.Contact.ToList();
            return View(values);
        }

        public ActionResult DeleteMessage(int id)
        {
            var value = db.Contact.Find(id);
            db.Contact.Remove(value);
            db.SaveChanges();
            return RedirectToAction("MessageList");
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
    }
}