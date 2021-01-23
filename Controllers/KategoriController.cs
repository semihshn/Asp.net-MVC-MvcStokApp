using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORİLER.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORİLER p1)
        {
            if (ModelState.IsValid==false)
            {
                return View("YeniKategori");
            }
            db.TBLKATEGORİLER.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var ktgr = db.TBLKATEGORİLER.Find(id);
            db.TBLKATEGORİLER.Remove(ktgr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var ktgr = db.TBLKATEGORİLER.Find(id);
            return View("Guncelle",ktgr);
        }
        [HttpPost]
        public ActionResult Guncelle(TBLKATEGORİLER p1)
        {
            if (ModelState.IsValid==false)
            {
                return View("Guncelle");
            }
            var ktgr = db.TBLKATEGORİLER.Find(p1.KATEGORİD);
            ktgr.KATEGORİAD = p1.KATEGORİAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}