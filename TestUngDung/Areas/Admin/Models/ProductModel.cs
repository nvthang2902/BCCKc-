using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestUngDung.Areas.Admin.Models
{
    public class ProductModel
    {
        [Display(Name = "ID")]
        public int IDProduct { get; set; }
        [Required(ErrorMessage = "Quên nhập tên sản phẩm")]
        [Display(Name = "Tên sản phẩm")]
        public string NameProduct { get; set; }
        [Required(ErrorMessage = "Quên nhập giá sản phẩm")]
        [Display(Name = "Đơn Giá")]
        public decimal? UnitCost { get; set; }
        [Required(ErrorMessage = "Quên nhập số lượng sản phẩm")]
        [Display(Name = "Số Lượng")]
        public int? Quantity { get; set; }
        [Required(ErrorMessage = "Quên hình ảnh sản phẩm")]
        [Display(Name = "Ảnh sản phẩm")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Quên nhập mô tả sản phẩm")]
        [Display(Name = "Mô tả sản phẩm")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Quên nhập trạng thái sản phẩm")]
        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }
        [Required(ErrorMessage = "Quên chọn loại sản phẩm")]
        [Display(Name = "Loại sản phẩm")]
        public int IDCategory { get; set; }
    }
}