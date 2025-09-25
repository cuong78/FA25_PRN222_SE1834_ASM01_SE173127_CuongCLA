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
    public class IndexModel : PageModel
    {
        private readonly zEVRental.Repositories.CuongCLA.Models.FA25_PRN222_SE1834_G3_EVRentalContext _context;

        public IndexModel(zEVRental.Repositories.CuongCLA.Models.FA25_PRN222_SE1834_G3_EVRentalContext context)
        {
            _context = context;
        }

        public IList<BookingCuongCla> BookingCuongCla { get;set; } = default!;

        public async Task OnGetAsync()
        {
            BookingCuongCla = await _context.BookingCuongClas
                .Include(b => b.CreatedByNavigation)
                .Include(b => b.Customer)
                .Include(b => b.Station)
                .Include(b => b.Vehicle).ToListAsync();
        }
    }
}
