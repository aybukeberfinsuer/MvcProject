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
    }
}