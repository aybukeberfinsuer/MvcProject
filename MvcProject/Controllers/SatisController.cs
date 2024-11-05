using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject.Models.Entity;

namespace MvcProject.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        dbMvcProjectEntities db= new dbMvcProjectEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();

        }

		[HttpPost]
		public ActionResult YeniSatis(Tbl_Satislar p1)
		{
            db.Tbl_Satislar.Add(p1);
            db.SaveChanges();
            return View("Index");
		}
	}
}