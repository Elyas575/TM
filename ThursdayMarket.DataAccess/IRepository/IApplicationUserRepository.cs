using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThursdayMarket.Models;

namespace ThursdayMarket.DataAccess.IRepository
{
    public interface IApplicationUserRepository 
    {
        Task<ApplicationUser> GetApplicationUserByIdAsync(string applicationUserId);

    }
}
