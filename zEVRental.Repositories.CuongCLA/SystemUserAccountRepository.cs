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
    public class SystemUserAccountRepository : GenericRepository<SystemUserAccount>
    {
        public SystemUserAccountRepository()
        {

        }
        public SystemUserAccountRepository(FA25_PRN222_SE1834_G3_EVRentalContext context) => _context = context;

        public async Task<SystemUserAccount> GetUserAccount(String userName, String password)
        {
            //   return await _context.SystemUserAccounts.FirstOrDefaultAsync(u => u.Email == userName && u.Password == password && u.IsActive == true);
            //   return await _context.SystemUserAccounts.FirstOrDefaultAsync(u => u.Phone == userName && u.Password == password && u.IsActive == true);
            //   return await _context.SystemUserAccounts.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password && u.IsActive == true);
            return await _context.SystemUserAccounts.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password && u.IsActive == true);
        }

    }
}
