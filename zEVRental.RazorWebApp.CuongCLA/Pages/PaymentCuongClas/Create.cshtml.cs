using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using zEVRental.Repositories.CuongCLA.Models;
using zEVRental.Services.CuongCLA;

namespace zEVRental.RazorWebApp.CuongCLA.Pages.PaymentCuongClas
{
    [Authorize(Roles = "1,2")]
    public class CreateModel : PageModel
    {
        private readonly IPaymentCuongClaService _paymentCuongClaService;
        private readonly BookingCuongClaService _bookingCuongClaService;
        private readonly SystemUserAccountService _systemUserAccountService;

        public CreateModel(IPaymentCuongClaService paymentCuongClaService
            , BookingCuongClaService bookingCuongClaService
            , SystemUserAccountService systemUserAccountService)
        {
            _paymentCuongClaService = paymentCuongClaService;
            _bookingCuongClaService = bookingCuongClaService;
            _systemUserAccountService = systemUserAccountService;
        }


        public async Task<IActionResult> OnGet()
        {
            //thi pe
            //var BookingCuongClas = _bookingCuongClaService.GetAllAsync();
            //ViewData["BookingId"] = new SelectList(BookingCuongClas, "BookingCuongClaid", "Status");

            PaymentCuongCla = new PaymentCuongCla();
            PaymentCuongCla.PaymentDate = DateTime.Now;

            var systemUserAccounts = await _systemUserAccountService.GetAllAsync();

            var BookingCuongClaQueryable = (await _bookingCuongClaService.GetAllAsync()).AsQueryable();
             var BookingCuongClas = BookingCuongClaQueryable.Select(b => new
             {
                    b.BookingCuongClaid,
                    DisplayText = string.Format("{0} - {1} - {2}", b.BookingCuongClaid, b.Customer.FullName, b.Status)
             }).ToList();

            ViewData["BookingId"] = new SelectList(BookingCuongClas, "BookingCuongClaid", "DisplayText");
            ViewData["ProcessedBy"] = new SelectList(systemUserAccounts, "UserAccountId", "Email");
            
            return Page();
        }

        [BindProperty]
        public PaymentCuongCla PaymentCuongCla { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _paymentCuongClaService.CreateAsync(PaymentCuongCla);

            return RedirectToPage("./Index");
        }
    }
}
