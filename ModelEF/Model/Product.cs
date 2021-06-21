namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [Key]
        public int IDProduct { get; set; }

        [StringLength(50)]
        public string NameProduct { get; set; }

        public decimal? UnitCost { get; set; }

        public int? Quantity { get; set; }

        [StringLength(50)]
        public string Image { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public bool Status { get; set; }

        public int IDCategory { get; set; }

        public virtual Category Category { get; set; }
    }
}
