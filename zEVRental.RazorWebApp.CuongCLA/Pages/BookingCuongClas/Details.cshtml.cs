using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using zEVRental.Repositories.CuongCLA.Models;
using zEVRental.Services.CuongCLA;

namespace zEVRental.RazorWebApp.CuongCLA.Pages.BookingCuongClas
{
    public class DetailsModel : PageModel
    {
        private readonly BookingCuongClaService _bookingCuongClaService;

        public DetailsModel(BookingCuongClaService bookingCuongClaService)
        {
            _bookingCuongClaService = bookingCuongClaService;
        }

        public BookingCuongCla BookingCuongCla { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingcuongcla = await _bookingCuongClaService.GetByIdAsync(id.Value);

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
    }
}
