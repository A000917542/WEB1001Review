using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB1001Review.Data;
using WEB1001Review.Models;

namespace WEB1001Review.Pages.Admin.Orders
{
    public class DetailsModel : PageModel
    {
        private readonly WEB1001Review.Data.StoreDbContext _context;

        public DetailsModel(WEB1001Review.Data.StoreDbContext context)
        {
            _context = context;
        }

        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Orders.FirstOrDefaultAsync(m => m.OrderID == id);

            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
