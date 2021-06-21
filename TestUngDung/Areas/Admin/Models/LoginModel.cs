using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestUngDung.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập tài khoản")]
        [Display(Name = "Tài khoản")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mời nhập mật khẩu")]
        [Display(Name = "Mật khẩu")]
        public string PassWord { get; set; }
        public string RememberMe { get; set; }

    }
}