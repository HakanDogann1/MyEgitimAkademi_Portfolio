using MyEgitimAkademi_Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEgitimAkademi_Portfolio.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            var values = db.About.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            db.About.Add(about);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAbout(int id)
        {
            var value = db.About.Find(id);
            db.About.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = db.About.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var value = db.About.Find(about.AboutId);
            value.AboutTitle2 = about.AboutTitle2;
            value.AboutTitle3 = about.AboutTitle3;
            value.AboutIntroduction = about.AboutIntroduction;
            value.AboutDescription = about.AboutDescription;
            value.AboutImage = about.AboutImage;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}