using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.Controllers
{
    public class DatabaseController : Controller
    {
        public IActionResult Seed()
        {
            ////KitapContext db = new KitapContext();
            ////db.Dispose();
            using (KitapContext db=new KitapContext())
            {
                var kitapEntities = db.Kitaplar.ToList();
                db.RemoveRange(kitapEntities);
                var kategoriEntities = db.Kategoriler.ToList();
                db.RemoveRange(kategoriEntities);

                db.Kategoriler.Add(new Kategori()
                {
                    Adi = "Roman",
                     Aciklamasi= "Bazen kurgu bazen ise gerçekleri anlatan, oldukça uzun kitaplar arasında yer alır.",
                    Kitaplar =new List<Kitap>()
                    {
                        new Kitap()
                        {
                             Adi="Beyaz Geceler",
                             StokMiktari=10,
                              Aciklamasi="Dostoyevski Orta Seviye",
                               YazarAdiSoyadi="Dostoyevski"

                        },
                        new Kitap()
                        {
                             Adi="Bozkırkurdu",
                             StokMiktari=8,
                              Aciklamasi="Hermann Hesse İleri Seviye",
                               YazarAdiSoyadi="Hermann Hesse"


                        },
                        new Kitap()
                        {
                             Adi="İnsancıklar",
                             StokMiktari=15,
                              Aciklamasi="Dostoyevski Giriş Seviye",
                               YazarAdiSoyadi="Dostoyevski"


                        }
                    }

                }) ;
                db.Kategoriler.Add(new Kategori()
                {

                     Adi="Çocuk Kitapları",
                      Aciklamasi= "Çocukların okuması ve gelişimini sağlamaları için onlara özel ele alınmış ve hazırlanmış kitaplardır.",
                      Kitaplar=new List<Kitap>()
                      {
                          new Kitap()
                          {
                              Adi="Ben Bir Gürgen Dalıyım",
                             StokMiktari=15,
                              Aciklamasi="masalsı bir çocuk romanı ",
                               YazarAdiSoyadi="Hasan Ali Toptaş"
                          },
                          new Kitap()
                          {
                              Adi="Dondurmalı Sinema",
                             StokMiktari=15,
                              Aciklamasi="Oktay Akbal ",
                               YazarAdiSoyadi="Oktay Akbal"
                          }


                      }

                     
                });
                db.SaveChanges();
            }
            
            
            return View();
        }
    }
}
