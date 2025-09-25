using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using zEVRental.Repositories.CuongCLA.Models;

namespace zEVRental.RazorWebApp.CuongCLA.Pages.BookingCuongClas
{
    public class CreateModel : PageModel
    {
        private readonly zEVRental.Repositories.CuongCLA.Models.FA25_PRN222_SE1834_G3_EVRentalContext _context;

        public CreateModel(zEVRental.Repositories.CuongCLA.Models.FA25_PRN222_SE1834_G3_EVRentalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CreatedBy"] = new SelectList(_context.SystemUserAccounts, "UserAccountId", "Email");
        ViewData["CustomerId"] = new SelectList(_context.CustomerManagementConglts, "CustomerManagementCongltId", "ActionType");
        ViewData["StationId"] = new SelectList(_context.StationHuyNds, "StationHuyNdid", "Address");
        ViewData["VehicleId"] = new SelectList(_context.VehicleHaLths, "VehicleHaLthid", "LicensePlate");
            return Page();
        }

        [BindProperty]
        public BookingCuongCla BookingCuongCla { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BookingCuongClas.Add(BookingCuongCla);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
