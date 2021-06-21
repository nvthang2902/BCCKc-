using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.Dao;
using ModelEF.Model;
using PagedList;
using TestUngDung.Areas.Admin.Models;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        NguyenVanThangDBContext db = new NguyenVanThangDBContext();
        // GET: Admin/Product
        public ActionResult Index(string searchString, int? page)
        {
           
            
            IEnumerable<ProductModel> result = (from pro in db.Products
                                                join cate in db.Categories on pro.IDCategory equals cate.IDCategory
                                                select new ProductModel
                                                {
                                                    IDProduct = pro.IDProduct,
                                                    NameProduct = pro.NameProduct,
                                                    UnitCost = pro.UnitCost,
                                                    Quantity = pro.Quantity,
                                                    Image = pro.Image,
                                                    IDCategory = pro.IDCategory                                           
                                                    }).OrderBy(x => x.Quantity).ThenByDescending(x => x.UnitCost);
            if (searchString != null)
            {
                result = result.Where(x => x.NameProduct.Contains(searchString));
                return View(result.ToList().ToPagedList(page ?? 1, 5));
            }
            else
            {
                return View(result.ToList().ToPagedList(page ?? 1, 5));
            }

        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int id)
        {
            var dao = new ProductDao();
            var pro = dao.ViewDetail(id);
            return View(pro);
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost]
        public ActionResult Create(Product pro, HttpPostedFileBase uploadhinh)
        {
            
            db.Products.Add(pro);
            db.SaveChanges();
            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                int id = int.Parse(db.Products.ToList().Last().IDProduct.ToString());

                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "pro" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Upload/images"), _FileName);
                uploadhinh.SaveAs(_path);

                Product upro = db.Products.FirstOrDefault(x => x.IDProduct == id);
                upro.Image = _FileName;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int id)
        {
            Product pro = db.Products.FirstOrDefault(x => x.IDProduct == id);
            return View(pro);
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product pro, HttpPostedFileBase uploadhinh)
        {
            Product upro = db.Products.FirstOrDefault(x => x.IDProduct == pro.IDProduct);
            upro.NameProduct = pro.NameProduct;
            upro.UnitCost = pro.UnitCost;
            upro.Quantity = pro.Quantity;

            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                int id = pro.IDProduct;

                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "pro" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Upload/images/"), _FileName);
                uploadhinh.SaveAs(_path);
                upro.Image = _FileName;
            }
            upro.Description = pro.Description;
            upro.Status = pro.Status;
            upro.IDCategory = pro.IDCategory;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        
        

        // POST: Admin/Product/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new ProductDao().Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult ChooseCategory()
        {
            Category cat = new Category();
            cat.CateCollection = db.Categories.ToList<Category>();
            return PartialView(cat);

        }
    }
}
