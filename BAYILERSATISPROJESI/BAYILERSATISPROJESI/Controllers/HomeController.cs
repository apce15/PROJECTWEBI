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
        public ActionResult BayiListe()
        {
             PROJEEntities db = new PROJEEntities();
            var degerler = db.BayilerSets.ToList();

            return View(degerler);

           
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
        public ActionResult YoneticiSinirlar(BAYILERSATISPROJESI.Models.UsersSet user)
        {
            using (PROJEEntities db = new PROJEEntities())
            {
                try
                {
                    var userDetail = db.UsersSets.Where(x => x.KullaniciAdi == user.KullaniciAdi && x.Sifre == user.Sifre).FirstOrDefault();
                    if (userDetail == null)
                    {
                        Console.WriteLine("First");
                        string errorMessage = "Kullanıcı Bulunamadı.";
                        return View("YoneticiGirisi", errorMessage);
                    }
                    else
                    {
                        Console.WriteLine("Second");
                        Session["userID"] = user.Id;
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
        public ActionResult Bayiler()
        {
            PROJEEntities db = new PROJEEntities();
            var degerler = db.BayilerSets.ToList();
            

            return View(degerler);

        }
        public ActionResult BayiGirisi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BayiSinirlar(BAYILERSATISPROJESI.Models.BayilerSet bayi)
        {
            using (PROJEEntities db = new PROJEEntities())
            {
                try
                {
                    var tableDetail = db.BayilerSets.Where(x => x.Ulke == bayi.Ulke && x.Sehir == bayi.Sehir && x.BayiId == bayi.BayiId && x.Sifre == bayi.Sifre).FirstOrDefault();
                    if (tableDetail == null)
                    {
                        string errorMessage = "Bayi Bulunamadı.";
                        return View("BayiGirisi", errorMessage);
                    }
                    else
                    {
                        Session["ulke"] = bayi.Ulke;
                        Session["sehir"] = bayi.Sehir;
                        Session["bayiid"] = bayi.BayiId;
                        Session["sifre"] = bayi.Sifre;

                        return View("BayiSinirlar", bayi);
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
            }

        }

        public ActionResult SatinAl()
        {

            var sepet = (List<urunSet>)Session["Sepet"];

            PROJEEntities db = new PROJEEntities();
            foreach (var item in sepet)
            {
                Siparisler siparis = new Siparisler();

                siparis.BayiId = (int)Session["bayiid"];
                siparis.Tarih = DateTime.Now;
                siparis.Tutar = item.Fiyat * item.Miktar;
                siparis.UrunId = item.Id;

                db.Siparislers.Add(siparis);
            }

            //stok azaltma
            foreach (var item in sepet)
            {
                var target = db.urunSets.Where(x => x.Id == item.Id).FirstOrDefault();

                target.StokAdeti -= item.Miktar;
            }

            int count = db.SaveChanges();
            
            var degerler = db.Siparislers.ToList();

            return View(degerler);
           
        }
        public ActionResult Siparislerim()
        {
            PROJEEntities db = new PROJEEntities();
            var degerler = db.Siparislers.ToList();

            return View(degerler);
        }
        public ActionResult AlinanSiparis()
        {
            PROJEEntities db = new PROJEEntities();
            var degerler = db.Siparislers.ToList();

            return View(degerler);
        }
        public ActionResult KarHesap(int sayi1=0, int sayi2=0)
        {
            int sonuc = sayi2 - sayi1;
            ViewBag.snc = sonuc;
            return View();
        }

    }
}
