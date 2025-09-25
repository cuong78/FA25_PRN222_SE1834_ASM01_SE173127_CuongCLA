using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zEVRental.Repositories.CuongCLA.Models;

namespace zEVRental.Services.CuongCLA
{
    public interface IPaymentCuongClaService
    {
        Task<List<PaymentCuongCla>> GetAllAsync();

        Task<PaymentCuongCla> GetByIdAsync(int id);

        Task<List<PaymentCuongCla>> SearchAsync(string paymentMethod, decimal ? amount, string status);

        Task<int> CreateAsync(PaymentCuongCla paymentCuong);

        Task<int> UpdateAsync(PaymentCuongCla paymentCuong);

        Task<bool> DeleteAsync(int id);
    }
}
