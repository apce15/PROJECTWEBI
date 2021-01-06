using BayiSatisProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BayiSatisProjesi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Anasayfa()
        {
            return View();
        }
        public ActionResult Urunler()
        {




            UrunKategoriModel model = new UrunKategoriModel();


            model.UrunSayisi = Veritabani.Liste.Where(i => i.Satistami == true).Count();
            model.Urunler = Veritabani.Liste.Where(i => i.Satistami == true).ToList();



            return View(model);
        }

        public ActionResult Details(int id)
        {
            var urun = Veritabani.Liste.Where(i => i.UrunId == id).FirstOrDefault();



            return View(urun);
        }

        private object Where(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        public ActionResult BayiGirisi()
        {
            return View();
        }
        public ActionResult YoneticiGirisi()
        {
            return View();
        }
        

}
}