using BAYILERSATISPROJESI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BAYILERSATISPROJESI.Controllers
{
    public class SepetController : Controller
    {
        // GET: Sepet
        public ActionResult Sepet()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Add(urunSet model)
        {
            Console.WriteLine("Fonksiyon Çağırıldı");
            if (Session["cart"] == null)
            {
                List<urunSet> liste = new List<urunSet>();

                liste.Add(model);
                Session["cart"] = liste;
                ViewBag.cart = liste.Count();


                Session["count"] = 1;

                Console.WriteLine("Liste boşta eklenenler" + liste.Count);

            }
            else
            {
                List<urunSet> liste = (List<urunSet>)Session["cart"];
                liste.Add(model);
                Session["cart"] = liste;
                ViewBag.cart = liste.Count();
                Session["count"] = Convert.ToInt32(Session["count"]) + 1;
                Console.WriteLine("Sonradan eklenenler" + liste.Count);

            }

            return RedirectToAction("Index", "BayiUrunler");


        }

        public ActionResult Myorder()
        {

            return View((List<urunSet>)Session["cart"]);

        }

        public ActionResult Remove(urunSet mob)
        {
            List<urunSet> liste = (List<urunSet>)Session["cart"];
            liste.RemoveAll(x => x.Id == mob.Id);
            Session["cart"] = liste;
            Session["count"] = Convert.ToInt32(Session["count"]) - 1;
            return RedirectToAction("Myorder", "AddToCart");
            //return View();
        }
    }
}