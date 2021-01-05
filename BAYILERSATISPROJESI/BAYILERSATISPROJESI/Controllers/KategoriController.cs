using BAYILERSATISPROJESI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BAYILERSATISPROJESI.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult KategoriMenu()
        {
            List<Kategori> kategoriler = new List<Kategori>()
            {
                new Kategori() { Id = 1, KategoriAdi = "Kamyonet Liftleri"},
                new Kategori() { Id = 2, KategoriAdi = "Kamyon Liftleri"},
                new Kategori() { Id = 3, KategoriAdi = "Tır Liftleri"}
            };
            return PartialView("KategoriMenu", kategoriler);
        }
    }
}