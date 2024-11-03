using MvcProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class UrunController : Controller
    {
        dbMvcProjectEntities db= new dbMvcProjectEntities();
        public ActionResult Index()
        {
            var values = db.Tbl_Urunler.ToList();
            return View(values);
        }
		[HttpGet]
		public ActionResult Ekle()
		{
			List<SelectListItem> list =(from i in db.Tbl_Kategoriler.ToList()
										select new SelectListItem
										{
											Text=i.KategoriAd,
											Value=i.KategoriId.ToString()
										}).ToList();
			ViewBag.dgr = list;
			return View();
		}

		[HttpPost]
		public ActionResult Ekle(Tbl_Urunler object_urun)
		{
			var ktg = db.Tbl_Kategoriler.Where(i => i.KategoriId.Equals(object_urun.Tbl_Kategoriler.KategoriId)).FirstOrDefault();
			object_urun.Tbl_Kategoriler = ktg;
			db.Tbl_Urunler.Add(object_urun);
			db.SaveChanges();
			return RedirectToAction("Index");

		}

		public ActionResult Sil(int id)
		{
			var silinecek_urun = db.Tbl_Urunler.Find(id);
			db.Tbl_Urunler.Remove(silinecek_urun);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}