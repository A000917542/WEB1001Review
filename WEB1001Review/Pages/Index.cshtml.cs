using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB1001Review.Data;

namespace WEB1001Review.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly StoreDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, StoreDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public ICollection<Models.Product> Products;

        public void OnGet()
        {
            Products = _context.Products.Take(5).ToList();
        }
    }
}
