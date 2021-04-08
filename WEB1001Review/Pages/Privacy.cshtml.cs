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
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly StoreDbContext _context;

        public PrivacyModel(ILogger<PrivacyModel> logger, StoreDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public int idArgument;
        public Models.Order Order;

        public void OnGet(int? id)
        {
            if (id != null)
            {
                Order = _context.Orders.Where( m => m.OrderID == id).FirstOrDefault();
            }
            
        }
    }
}
