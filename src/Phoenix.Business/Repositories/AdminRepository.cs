using Phoenix.Business.Interfaces;
using Phoenix.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Business.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly PhoenixContext _dbContext;

        public AdminRepository(PhoenixContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
