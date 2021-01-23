using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLMUSTERİLER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERİLER p1)
        {
            if (ModelState.IsValid==false)
            {
                return View("YeniMusteri");
            }
            db.TBLMUSTERİLER.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var mstri = db.TBLMUSTERİLER.Find(id);
            db.TBLMUSTERİLER.Remove(mstri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var mstri = db.TBLMUSTERİLER.Find(id);
            return View("Guncelle", mstri);
        }
        [HttpPost]
        public ActionResult Guncelle(TBLMUSTERİLER p1)
        {
            var mstri = db.TBLMUSTERİLER.Find(p1.MUSTERİD);
            mstri.MUSTERİAD = p1.MUSTERİAD;
            mstri.MUSTERİSOYAD = p1.MUSTERİSOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}