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
    [Authorize(Roles = "1")]
    public class DeleteModel : PageModel
    {
        private readonly IPaymentCuongClaService _paymentCuongClaService;

        public DeleteModel(
             IPaymentCuongClaService paymentCuongClaService
           )
        {
            _paymentCuongClaService = paymentCuongClaService;

        }

        [BindProperty]
        public PaymentCuongCla PaymentCuongCla { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentcuongcla = await _paymentCuongClaService.GetByIdAsync(id.Value);

            if (paymentcuongcla == null)
            {
                return NotFound();
            }
            else
            {
                PaymentCuongCla = paymentcuongcla;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _paymentCuongClaService.DeleteAsync(id.Value);
           
            
            return RedirectToPage("./Index");
        }
    }
}
