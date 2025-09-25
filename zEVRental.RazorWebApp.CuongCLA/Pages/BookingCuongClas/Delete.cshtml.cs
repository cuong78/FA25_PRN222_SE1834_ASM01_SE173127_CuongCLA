using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using zEVRental.Repositories.CuongCLA.Models;

namespace zEVRental.RazorWebApp.CuongCLA.Pages.BookingCuongClas
{
    public class DeleteModel : PageModel
    {
        private readonly zEVRental.Repositories.CuongCLA.Models.FA25_PRN222_SE1834_G3_EVRentalContext _context;

        public DeleteModel(zEVRental.Repositories.CuongCLA.Models.FA25_PRN222_SE1834_G3_EVRentalContext context)
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

            var bookingcuongcla = await _context.BookingCuongClas.FirstOrDefaultAsync(m => m.BookingCuongClaid == id);

            if (bookingcuongcla == null)
            {
                return NotFound();
            }
            else
            {
                BookingCuongCla = bookingcuongcla;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingcuongcla = await _context.BookingCuongClas.FindAsync(id);
            if (bookingcuongcla != null)
            {
                BookingCuongCla = bookingcuongcla;
                _context.BookingCuongClas.Remove(BookingCuongCla);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
