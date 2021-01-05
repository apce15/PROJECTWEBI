using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAYILERSATISPROJESI.Models
{
    public static class Veritabani
    {
        private static List<Urun> _liste;
        static Veritabani()
        {
            _liste = new List<Urun>()
            {
                new Urun(){ UrunId=1,UrunAdi="Lift1", Aciklama="iyi bir ürün", Fiyat=1000, Satistami=true,Resim="/banzhow/img/logo.jpg"},
                new Urun(){ UrunId=2,UrunAdi="Lift2", Aciklama="iyi bir ürün", Fiyat=2000, Satistami=true},
                new Urun(){ UrunId=3,UrunAdi="OzelLift3", Aciklama="iyi bir ürün", Fiyat=3000, Satistami=false},
                new Urun(){ UrunId=4,UrunAdi="Lift4", Aciklama="iyi bir ürün", Fiyat=4000, Satistami=true},
                new Urun(){ UrunId=5,UrunAdi="Lift5", Aciklama="iyi bir ürün", Fiyat=8000, Satistami=true}
            };
        }

        public static List<Urun> Liste
        {
            get { return _liste; }
        }
        public static void ElemanEkle(Urun entity)
        {
            _liste.Add(entity);
        }
        public static Urun UrunDetay(int urunid)
        {
            Urun entity = null;
            foreach (var urun in _liste)
            {
                if (urun.UrunId == urunid)
                {
                    entity = urun;
                }
            }
            return entity;
        }
    }
}