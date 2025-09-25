using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zEVRental.Repositories.CuongCLA.Basic;
using zEVRental.Repositories.CuongCLA.Models;

namespace zEVRental.Repositories.CuongCLA
{
    public class BookingCuongClaRepository : GenericRepository<BookingCuongCla> 
    {
        public BookingCuongClaRepository()
        {
        }

        public BookingCuongClaRepository(FA25_PRN222_SE1834_G3_EVRentalContext context) => _context = context;

        public async Task<List<BookingCuongCla>> GetAllAsync()
        {
            var items = await _context.BookingCuongClas
                .Include(b => b.Customer)           // Include Customer để truy cập b.Customer.FullName
                .Include(b => b.Vehicle)            // Include Vehicle nếu cần
                .Include(b => b.Station)            // Include Station nếu cần
                .Include(b => b.CreatedByNavigation) // Include user tạo nếu cần
                .ToListAsync();

            return items ?? new List<BookingCuongCla>();
        }

          public async Task<BookingCuongCla> GetByIdAsync(int id)
        {
            var bookingcuongcla = await _context.BookingCuongClas
               .Include(b => b.Customer)
               .Include(b => b.CreatedByNavigation)
               .Include(b => b.Station)
               .Include(b => b.Vehicle)
               .Include(b => b.PaymentCuongClas) // Include related payments
               .FirstOrDefaultAsync(m => m.BookingCuongClaid == id);
            return bookingcuongcla ?? new BookingCuongCla();
        }

        
    }
}
