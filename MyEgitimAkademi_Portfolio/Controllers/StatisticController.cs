using MyEgitimAkademi_Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEgitimAkademi_Portfolio.Controllers
{
    public class StatisticController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        // GET: Statistic
        public ActionResult Index()
        {
            ViewBag.totalProjectCount = db.Project.Count();
            ViewBag.totalTestimonialCount = db.Testimonial.Count();
            ViewBag.sumCompletedDay = db.Project.Sum(x => x.ComplateDay);
            ViewBag.avgWorkDay = db.Project.Average(x => x.ComplateDay);
            ViewBag.avgPrice = (double)db.Project.Average(x=>x.Price);
            var value = db.Project.Max(x => x.Price);
            ViewBag.maxPrice = db.Project.Where(x => x.Price == value);
            ViewBag.maxPriceProject = db.Project.Where(x => x.Price == value).Select(y => y.ProjectTitle).FirstOrDefault();
            var value2 = db.Category.Where(x => x.CategoryName == "Asp.Net Core Web Geliştirme").Select(y => y.CategoryId).FirstOrDefault();
            ViewBag.categoryCountByName = db.Project.Where(x => x.ProjectCategory == value2).Count();
            return View();
        }
    }
}