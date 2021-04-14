using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WEB1001Review.Data;

namespace WEB1001Review.Pages
{
    public class TodoCompleteModel : PageModel
    {
        private readonly StoreDbContext _context;

        public TodoCompleteModel(StoreDbContext context)
        {
            _context = context;
        }

        public void OnPost(int? ProductID)
        {
            Models.Product product = _context.Products.FirstOrDefault(prod => prod.ProductID == ProductID);
            product.Price = 2.00M;
            _context.Update(product);
            _context.SaveChanges();
            Redirect("/index");
        }
    }
}
