using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEF.Model;
using PagedList;
namespace ModelEF.Dao
{
    public class ProductDao
    {
        NguyenVanThangDBContext db = null;
        public ProductDao()
        {
            db = new NguyenVanThangDBContext();
        }
        public long Insert(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return product.IDProduct;
        }
        public List<Product> ListAll()
        {
            return db.Products.ToList();
        }
        public Product ViewDetail(int? id)
        {
            var result = (from pro in db.Products
                          join cate in db.Categories on pro.IDCategory equals cate.IDCategory
                          where pro.IDCategory == id
                          select new
                          {

                          }).FirstOrDefault();
            return db.Products.Find(id);
        }
        public bool Delete(int id)
        {
            try
            {
                var pro = db.Products.Find(id);
                db.Products.Remove(pro);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<Product> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.NameProduct.Contains(searchString));
            }

            return model.OrderBy(x => x.IDProduct).ToPagedList(page, pageSize);
        }
    }
}
