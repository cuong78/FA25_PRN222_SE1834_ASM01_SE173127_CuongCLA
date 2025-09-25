using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zEVRental.Repositories.CuongCLA;
using zEVRental.Repositories.CuongCLA.Models;

namespace zEVRental.Services.CuongCLA
{
    public class SystemUserAccountService
    {
        private readonly SystemUserAccountRepository _repository;
        public SystemUserAccountService() => _repository = new SystemUserAccountRepository();
        public async Task<SystemUserAccount> GetUserAccount(string username, string password)
        {
            try
            {
                return await _repository.GetUserAccount(username, password);
            }
            catch (Exception ex) { }
            return null;

        }

        public async Task<List<SystemUserAccount>> GetAllAsync()
        {
            try
            {
                return await _repository.GetAllAsync();
            }
            catch (Exception ex)
            {
            }
            return new List<SystemUserAccount>();
        }

    }
}
