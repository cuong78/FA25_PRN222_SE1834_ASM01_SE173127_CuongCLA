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
    public class PaymentCuongClaRepository : GenericRepository<PaymentCuongCla>
    {
        public PaymentCuongClaRepository()
        {
        }
        public PaymentCuongClaRepository(FA25_PRN222_SE1834_G3_EVRentalContext context) => _context = context;
        public async Task<List<PaymentCuongCla>> GetAllAsync()
        {
            var items = await _context.PaymentCuongClas
                .Include(p => p.Booking)
                    .ThenInclude(b => b.Customer)
                .Include(p => p.ProcessedByNavigation)
                .ToListAsync();

            return items ?? new List<PaymentCuongCla>();
        }

        public async Task<PaymentCuongCla> GetByIdAsync(int id)
        {
            var payment = await _context.PaymentCuongClas
                  .Include(p => p.Booking)
                      .ThenInclude(b => b.Customer)
                  .Include(p => p.ProcessedByNavigation)
                  .FirstOrDefaultAsync(p => p.PaymentCuongClaid == id);
            return payment ?? new PaymentCuongCla();
        }

        public async Task<List<PaymentCuongCla>> SearchAsync(string paymentMethod, decimal? amount, string status)
        {
            var cashDepositSlips = await _context.PaymentCuongClas
                .Include(b => b.Booking)
                    .ThenInclude(b => b.Customer)
                .Include(p => p.ProcessedByNavigation)
                .Where(c =>
                (c.PaymentMethod.Contains(paymentMethod) || string.IsNullOrEmpty(paymentMethod))
                && (c.Amount == amount || amount == 0 || amount == null)
                && (c.Booking.Status.Contains(status) || string.IsNullOrEmpty(status))  //Ref table: foreign key                
            ).OrderByDescending(c => c.PaymentDate).ToListAsync();

            return cashDepositSlips ?? new List<PaymentCuongCla>();
        }
    }
}
