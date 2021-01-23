using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLURUNLER.ToList();
            return View(degerler);
        }

        [HttpPost]
        public ActionResult YeniUrun(TBLURUNLER p1)
        {
            //var ktg = db.TBLKATEGORİLER.Where(x => x.KATEGORİD == p1.TBLKATEGORİLER.KATEGORİD).FirstOrDefault();
            //p1.TBLKATEGORİLER = ktg;
            db.TBLURUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degisken = (from i in db.TBLKATEGORİLER.ToList()
                                            select new SelectListItem
                                            { Text = i.KATEGORİAD,
                                                Value = i.KATEGORİD.ToString() 
                                            }).ToList();
            ViewBag.dgr = degisken;
            return View();
        }

        public ActionResult Sil(int id)
        {
            var urn = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urn);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var urn = db.TBLURUNLER.Find(id);

            List<SelectListItem> degisken = (from i in db.TBLKATEGORİLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORİAD,
                                                 Value = i.KATEGORİD.ToString()
                                             }).ToList();
            ViewBag.dgr = degisken;

            return View("Guncelle", urn);
        }
        [HttpPost]
        public ActionResult Guncelle(TBLURUNLER p1)
        {
            var urn = db.TBLURUNLER.Find(p1.URUNİD);
            urn.URUNAD = p1.URUNAD; 
            urn.MARKA = p1.MARKA;
            var ktg = db.TBLKATEGORİLER.Where(m => m.KATEGORİD == p1.TBLKATEGORİLER.KATEGORİD).FirstOrDefault();
            urn.URUNKATEGORİ = ktg.KATEGORİD;
            urn.FİYAT = p1.FİYAT;
            urn.STOK = p1.STOK;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}