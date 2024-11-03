﻿using Microsoft.Ajax.Utilities;
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
        public ActionResult Index()
        {
            var values= db.Tbl_Musteriler.ToList();
            return View(values);
        }

		[HttpGet]
		public ActionResult Ekle()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Ekle(Tbl_Musteriler musteri)
		{
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