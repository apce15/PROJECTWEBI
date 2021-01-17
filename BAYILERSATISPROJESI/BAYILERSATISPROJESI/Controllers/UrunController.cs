﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAYILERSATISPROJESI.Models;


namespace BAYILERSATISPROJESI.Controllers
{
    public class UrunController : Controller
    {
        public static List<urunSet> sepet = new List<urunSet>();

        // GET: Urun

        PROJEEntities db = new PROJEEntities();
        public ActionResult UrunListe()
        {
            var degerler = db.urunSets.ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(urunSet p1)
        {
            db.urunSets.Add(p1);

            db.SaveChanges();
            return View();

        }
        [HttpGet]
        public ActionResult BayiUrunler()
        { var degerler = db.urunSets.ToList();

            return View(degerler);


        }

        public ActionResult SepeteEkle(urunSet urun)
        {
            sepet.Add(urun);

            Session["Sepet"] = sepet;

            var degerler = db.urunSets.ToList();

            return View("BayiUrunler", degerler);
        }

       


    }
}