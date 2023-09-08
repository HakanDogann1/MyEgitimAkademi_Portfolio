using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEgitimAkademi_Portfolio.Controllers
{
    public class CvController : Controller
    {
        // GET: Cv
    
        public FileResult GetCv()
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath("~/Templates/CV/"  + "cv600893208.pdf"));
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Pdf);

        }
    }
}