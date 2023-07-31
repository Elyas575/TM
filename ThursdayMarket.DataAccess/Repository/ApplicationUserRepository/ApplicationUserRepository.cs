using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThursdayMarket.DataAccess.Data;
using ThursdayMarket.DataAccess.IRepository;
using ThursdayMarket.Models;

namespace ThursdayMarket.DataAccess.Repository.ApplicationUserRepository
{
    public class ApplicationUserRepository :IApplicationUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ApplicationUserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ApplicationUser> GetApplicationUserByIdAsync(string applicationUserId)
        {
            return await _dbContext.ApplicationUsers.FindAsync(applicationUserId);
        }
    }
}
