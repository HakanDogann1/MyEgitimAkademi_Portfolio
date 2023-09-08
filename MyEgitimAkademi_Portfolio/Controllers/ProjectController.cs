using MyEgitimAkademi_Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEgitimAkademi_Portfolio.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            var values = db.Project.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddProject()
        {
            List<SelectListItem> list = (from k in db.Category
                                         select new SelectListItem
                                         {
                                             Text = k.CategoryName,
                                             Value = k.CategoryId.ToString(),
                                         }).ToList();
            ViewBag.Category=list;
            return View();
        }
        [HttpPost]
        public ActionResult AddProject(Project project)
        {
            db.Project.Add(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProject(int id)
        {
            var value = db.Project.Find(id);
            db.Project.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var value = db.Project.Find(id);
            List<SelectListItem> list = (from k in db.Category
                                         select new SelectListItem
                                         {
                                             Text = k.CategoryName,
                                             Value = k.CategoryId.ToString(),
                                         }).ToList();
            ViewBag.Category = list;
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateProject(Project project)
        {
            var value = db.Project.Find(project.ProjectId);
            value.ProjectTitle = project.ProjectTitle;
            value.ProjectDescription = project.ProjectDescription;
            value.ProjectCategory = project.ProjectCategory;
            value.ComplateDay = project.ComplateDay;
            value.Price = project.Price;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}