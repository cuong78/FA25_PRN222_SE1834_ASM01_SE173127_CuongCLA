using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using zEVRental.Repositories.CuongCLA.Models;

namespace zEVRental.RazorWebApp.CuongCLA.Pages.BookingCuongClas
{
    public class EditModel : PageModel
    {
        private readonly zEVRental.Repositories.CuongCLA.Models.FA25_PRN222_SE1834_G3_EVRentalContext _context;

        public EditModel(zEVRental.Repositories.CuongCLA.Models.FA25_PRN222_SE1834_G3_EVRentalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BookingCuongCla BookingCuongCla { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingcuongcla =  await _context.BookingCuongClas.FirstOrDefaultAsync(m => m.BookingCuongClaid == id);
            if (bookingcuongcla == null)
            {
                return NotFound();
            }
            BookingCuongCla = bookingcuongcla;
           ViewData["CreatedBy"] = new SelectList(_context.SystemUserAccounts, "UserAccountId", "Email");
           ViewData["CustomerId"] = new SelectList(_context.CustomerManagementConglts, "CustomerManagementCongltId", "ActionType");
           ViewData["StationId"] = new SelectList(_context.StationHuyNds, "StationHuyNdid", "Address");
           ViewData["VehicleId"] = new SelectList(_context.VehicleHaLths, "VehicleHaLthid", "LicensePlate");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BookingCuongCla).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingCuongClaExists(BookingCuongCla.BookingCuongClaid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookingCuongClaExists(int id)
        {
            return _context.BookingCuongClas.Any(e => e.BookingCuongClaid == id);
        }
    }
}
