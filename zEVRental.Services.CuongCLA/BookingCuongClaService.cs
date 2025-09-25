using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zEVRental.Repositories.CuongCLA;
using zEVRental.Repositories.CuongCLA.Models;

namespace zEVRental.Services.CuongCLA
{
    public class BookingCuongClaService
    {
        private readonly BookingCuongClaRepository _repository;

        public BookingCuongClaService() => _repository = new BookingCuongClaRepository();

        public async Task<List<BookingCuongCla>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
            }
            return new List<BookingCuongCla>();
        }


        public async Task<BookingCuongCla> GetByIdAsync(int id)
        {
            try
            {
                var item = await _repository.GetByIdAsync(id);
                return item;
            }
            catch (Exception ex)
            {
                // throw new Exception(ex.Message);
            }
            return null;
        }
    }
}
