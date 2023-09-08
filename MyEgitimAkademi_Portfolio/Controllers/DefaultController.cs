using MyEgitimAkademi_Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEgitimAkademi_Portfolio.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }

        public PartialViewResult PartialQuickContact()
        {
            return PartialView();
        }
        public PartialViewResult PartialFeature()
        {
            var value = db.About.FirstOrDefault(x => x.AboutId == 1);
            return PartialView(value);
        }

        public PartialViewResult PartialService()
        {
            var values = db.Service.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialSkill()
        {
            var values = db.Skill.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialAward()
        {
            var values = db.Project.Take(3).ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialTestimonial()
        {
            var values = db.Testimonial.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialPartner()
        {
            ViewBag.ProjectCount=db.Project.Count();
            ViewBag.Testimonial=db.Testimonial.Count();
            ViewBag.PartnerCount=db.Partner.Count();
            var values = db.Partner.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialContact()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult SendMessage(Contact contact)
        {
            db.Contact.Add(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}