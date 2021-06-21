using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.Model;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        NguyenVanThangDBContext _db = new NguyenVanThangDBContext();
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View(_db.Categories.ToList());
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int id)
        {
            return View(_db.Categories.Where(s => s.IDCategory == id).FirstOrDefault());
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost]
        public ActionResult Create(Category cate)
        {
            try
            {
                // TODO: Add insert logic here
                _db.Categories.Add(cate);
                _db.SaveChanges();
                return RedirectToAction("Index");
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Category/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(_db.Categories.Where(s => s.IDCategory == id).FirstOrDefault());
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category cate)
        {
            try
            {
                // TODO: Add update logic here
                _db.Entry(cate).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_db.Categories.Where(s => s.IDCategory == id).FirstOrDefault());
        }

        // POST: Admin/Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Category cate)
        {
            try
            {
                // TODO: Add delete logic here
                cate = _db.Categories.Where(s => s.IDCategory == id).FirstOrDefault();
                _db.Categories.Remove(cate);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
