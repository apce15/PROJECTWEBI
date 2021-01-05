using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BAYILERSATISPROJESI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Urunler()
        {
            return View();
        }
        public ActionResult YoneticiGirisi()
        {
            return View();
        }
        public ActionResult BayiGirisi()
        {
            return View();
        }
        public ActionResult YOneticiSinirlar()
        {
            return View();
        }
    }
}