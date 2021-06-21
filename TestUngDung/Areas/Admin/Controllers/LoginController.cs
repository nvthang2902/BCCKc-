using ModelEF;
using ModelEF.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.Model;
using TestUngDung.Areas.Admin.Models;
using TestUngDung.Common;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, model.PassWord);
                if (result ==1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    if (user.UserName != "admin")// client dang nhap
                    {
                        userSession.UserName = user.UserName;
                        userSession.UserID = user.IDUser;
                        Session.Add(CommonConstants.USER_SESSION, userSession);
                        return RedirectToAction("Index", "Home");
                    }
                    else { return RedirectToAction("Index", "HomeAdmin"); }//neu la admin login

                }
                else if(result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại!");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa!");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Nhập mật khẩu sai!");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập sai hoặc mật khẩu không đúng!");
                }
            }
            
            return View("Index");
        }

    }
}