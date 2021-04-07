using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WEB1001Review.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }

        [StringLength(255)]
        [Display(Name = "Name")]
        public string ProductName { get; set; }

        [Display(Name = "Description")]
        public string ProductDescription { get; set; }

        [Range(0.01, 9999.99)]
        public Decimal Price { get; set; }

        public int OrderID { get; set; }

        [ForeignKey("OrderID")]
        public Order Order { get; set; }
    }
}
