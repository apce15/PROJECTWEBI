using BAYILERSATISPROJESI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private object Where(Func<object, bool>
    p)
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
        [HttpPost]
        public ActionResult YoneticiSinirlar(BAYILERSATISPROJESI.Models.User user)
        {
            using (DBModels db = new DBModels())
            {
                var userDetail = db.Users.Where(x => x.KullaniciAdi == user.KullaniciAdi && x.Sifre == user.Sifre).FirstOrDefault();
                if (userDetail == null)
                {
                    user.GirişHataMesajı = "Kullanıcı adı veya şifre yanlış";
                    return View("YoneticiGirisi", user);
                }
                else
                {
                    Session["userID"] = user.UserID;
                    Session["kullanıcıadı"] = user.KullaniciAdi;
                    return View("YoneticiSinirlar", user);
                }
            }

        }

    }
}
