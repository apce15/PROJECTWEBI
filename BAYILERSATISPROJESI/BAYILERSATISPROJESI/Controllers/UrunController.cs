using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAYILERSATISPROJESI.Models;

namespace BAYILERSATISPROJESI.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun

        URUNLEREntities db = new URUNLEREntities();
        public ActionResult UrunListe()
        {
            var degerler = db.URUNEKLEs.ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(URUNEKLE p1)
        {
            db.URUNEKLEs.Add(p1);

            db.SaveChanges();
            return View();

        }
        [HttpGet]
        public ActionResult BayiUrunler()
        {     var degerler = db.URUNEKLEs.ToList();

            return View(degerler);
        
           
        }


    }
}