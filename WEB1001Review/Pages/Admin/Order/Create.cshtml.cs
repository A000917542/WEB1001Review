using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEB1001Review.Data;
using WEB1001Review.Models;

namespace WEB1001Review.Pages.Admin.Orders
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly WEB1001Review.Data.StoreDbContext _context;

        public CreateModel(WEB1001Review.Data.StoreDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            this.Order = new Models.Order();
            this.Order.User = User.Identity.Name;
            return Page();
        }

        [BindProperty]
        public Models.Order Order { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
