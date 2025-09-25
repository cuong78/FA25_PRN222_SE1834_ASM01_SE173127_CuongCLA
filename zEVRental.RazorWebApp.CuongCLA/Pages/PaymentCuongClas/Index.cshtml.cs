using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zEVRental.Repositories.CuongCLA.Models;
using zEVRental.Services.CuongCLA;

namespace zEVRental.RazorWebApp.CuongCLA.Pages.PaymentCuongClas
{
    [Authorize(Roles = "1,2")]
    public class IndexModel : PageModel
    {
        private readonly IPaymentCuongClaService _service;
        
        public IndexModel(IPaymentCuongClaService service)
        {
            _service = service;
        }

        public IList<PaymentCuongCla> PaymentCuongCla { get; set; } = new List<PaymentCuongCla>();

        // Search and Filter Properties
        [BindProperty(SupportsGet = true)]
        public string paymentMethod { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public string amount { get; set; }

        [BindProperty(SupportsGet = true)]
        public string status { get; set; } = string.Empty;

        public async Task OnGetAsync()
        {
            // Perform search with the provided parameters

            decimal? costValue = null;
            if (decimal.TryParse(amount, out decimal parsedCost))
            {
                costValue = parsedCost;
            }
            PaymentCuongCla = await _service.SearchAsync(
                string.IsNullOrWhiteSpace(paymentMethod) ? null : paymentMethod.Trim(),
                costValue ,
                string.IsNullOrWhiteSpace(status) ? null : status.Trim());

          
        }
    }
}
