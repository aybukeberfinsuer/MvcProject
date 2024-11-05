using Microsoft.Ajax.Utilities;
using MvcProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class MusteriController : Controller
    {
       dbMvcProjectEntities db = new dbMvcProjectEntities();
        public ActionResult Index(string p)
        {

			var degerler = from d in db.Tbl_Musteriler select d;
			
			if(!string.IsNullOrEmpty(p))
			{
				degerler = degerler.Where(m => m.MusteriAd.Contains(p));
			}
			return View(degerler.ToList());
		}

		[HttpGet]
		public ActionResult Ekle()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Ekle(Tbl_Musteriler musteri)
		{
			if (!ModelState.IsValid)
			{
				return View("Ekle");
			}
			db.Tbl_Musteriler.Add(musteri);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Sil(int id)
		{
			var silinecek_musteri = db.Tbl_Musteriler.Find(id);
			db.Tbl_Musteriler.Remove(silinecek_musteri);
			db.SaveChanges();
			return RedirectToAction("Index");
		}


		public ActionResult MusteriGetir( int id)
		{
			var musteri= db.Tbl_Musteriler.Find(id);
			return View("MusteriGetir", musteri);
		}

		public ActionResult Guncelle(Tbl_Musteriler p1)
		{
			var guncel_musteri = db.Tbl_Musteriler.Find(p1.MusteriId);
			guncel_musteri.MusteriAd= p1.MusteriAd;
			guncel_musteri.MusteriSoyad= p1.MusteriSoyad;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}