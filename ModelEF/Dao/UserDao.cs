using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelEF.Model;
using PagedList;
namespace ModelEF.Dao
{
    public class UserDao
    {
        NguyenVanThangDBContext db = null;
        public UserDao()
        {
            db = new NguyenVanThangDBContext();
        }
        public long Insert(UserAccount entity)
        {
            db.UserAccounts.Add(entity);
            db.SaveChanges();
            return entity.IDUser;
        }
        public bool Update(UserAccount entity)
        {
            try
            {
                var user = db.UserAccounts.Find(entity.IDUser);
                user.UserName = entity.UserName;
                if (!string.IsNullOrEmpty(entity.PassWord))
                {
                    user.PassWord = entity.PassWord;
                }
                user.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }

        public IEnumerable<UserAccount> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<UserAccount> model = db.UserAccounts;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString));
            }

            return model.OrderBy(x => x.IDUser).ToPagedList(page,pageSize);
        }

        public UserAccount GetById(string userName)
        {
            return db.UserAccounts.SingleOrDefault(x => x.UserName == userName);
        }

        public UserAccount ViewDetail(int id)
        {
            return db.UserAccounts.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var user = db.UserAccounts.Find(id);
                db.UserAccounts.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public int Login(string userName,string password)
        {
            var result = db.UserAccounts.SingleOrDefault(x => x.UserName == userName);
            if(result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.PassWord == password)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }
    }
}
