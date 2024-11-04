using MvcProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class KategoriController : Controller
    {
        dbMvcProjectEntities db= new dbMvcProjectEntities();
        public ActionResult Index()
        {
            var values= db.Tbl_Kategoriler.ToList();
            return View(values);
        }

        [HttpGet]
		public ActionResult Ekle()
		{		
			return View();
		}

		[HttpPost]
        public ActionResult Ekle(Tbl_Kategoriler category1)
        {  
            if(!ModelState.IsValid)
            {
                return View("Ekle");
            }
            db.Tbl_Kategoriler.Add(category1);
            db.SaveChanges();
            return RedirectToAction("Index");           
        }

        public ActionResult Sil(int id)
        {
            var kategori= db.Tbl_Kategoriler.Find(id);
            db.Tbl_Kategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir( int id)
        {
            var kategori = db.Tbl_Kategoriler.Find(id);
            return View("KategoriGetir", kategori);
        }

        public ActionResult Guncelle(Tbl_Kategoriler kategori)
        {
            var ktg= db.Tbl_Kategoriler.Find(kategori.KategoriId);
            ktg.KategoriAd = kategori.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}