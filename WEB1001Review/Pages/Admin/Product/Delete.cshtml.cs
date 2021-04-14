using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB1001Review.Data;
using WEB1001Review.Models;

namespace WEB1001Review.Pages.Admin
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly WEB1001Review.Data.StoreDbContext _context;

        public DeleteModel(WEB1001Review.Data.StoreDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Product Product { get; set; }

        List<Models.Product> Done = new List<Models.Product>();
        List<Models.Product> Next = new List<Models.Product>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Done = _context.Products.Where(prod => prod.Price > 5.00M).ToList();

            Next = _context.Products.Where(prod => prod.OrderID > 9).ToList();

            Product = await _context.Products
                .Include(p => p.Order).FirstOrDefaultAsync(m => m.ProductID == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products.FindAsync(id);

            if (Product != null)
            {
                _context.Products.Remove(Product);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
