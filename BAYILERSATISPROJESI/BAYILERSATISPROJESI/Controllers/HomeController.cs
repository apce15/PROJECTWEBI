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
       
        

      

        public ActionResult YoneticiGirisi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YoneticiSinirlar(BAYILERSATISPROJESI.Models.User user)
        {
            using (DBModels db = new DBModels())
            {
                try
                {
                    var userDetail = db.Users.Where(x => x.KullaniciAdi == user.KullaniciAdi && x.Sifre == user.Sifre).FirstOrDefault();
                    if (userDetail == null)
                    {
                        Console.WriteLine("First");
                        user.entryErrorMessage = "Kullanıcı adı veya şifre yanlış";
                        return View("YoneticiGirisi", user);
                    }
                    else
                    {
                        Console.WriteLine("Second");
                        Session["userID"] = user.UserID;
                        Session["kullanıcıadı"] = user.KullaniciAdi;
                        return View("YoneticiSinirlar", user);
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }

        }
        public ActionResult BayiGirisi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BayiSinirlar(BAYILERSATISPROJESI.Models.Table table)
        {
            using (BayiDataBaseEntities1 db = new BayiDataBaseEntities1())
            {
                var tableDetail = db.Tables.Where(x => x.ulke == table.ulke && x.sehir == table.sehir && x.bayiid == table.bayiid && x.sifre == table.sifre).FirstOrDefault();
                if (tableDetail == null)
                {
                    table.entryErrorMessage = " Yanlış Bilgileri Girdiniz.Tekrar Deneyin";
                    return View("BayiGirisi", table);
                }
                else
                {
                    Session["ulke"] = table.ulke;
                    Session["sehir"] = table.sehir;
                    Session["bayiid"] = table.bayiid;
                    Session["sifre"] = table.sifre;

                    return View("BayiSinirlar", table);
                }
            }

        }

    }
}
