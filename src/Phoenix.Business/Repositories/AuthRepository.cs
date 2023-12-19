using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoenix.Business.Interfaces;
using Phoenix.DataAccess.Models;

namespace Phoenix.Business.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly PhoenixContext _context;
        public AuthRepository(PhoenixContext context)
        {
            _context = context;
        }
        public Administrator GetAdminAccount(string username)
        {
            return _context.Administrators.FirstOrDefault(a => a.Username == username)
                        ?? throw new KeyNotFoundException("Admin not found");
        }
        public Guest GetGuestAccount(string username)
        {
            return _context.Guests.FirstOrDefault(a => a.Username == username) 
                        ?? throw new KeyNotFoundException("Guest not found");
        }
    }
}
