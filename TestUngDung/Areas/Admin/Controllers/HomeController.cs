using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.Dao;
using ModelEF.Model;
namespace TestUngDung.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        NguyenVanThangDBContext db = new NguyenVanThangDBContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
        public ActionResult Details(int id)
        {
            return View(db.Products.Where(s => s.IDProduct == id).FirstOrDefault());
        }

    }
}