using Phoenix.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Business.Interfaces
{
    public interface IAuthRepository
    {
        public Administrator GetAdminAccount(string username);
        public Guest GetGuestAccount(string username);
    }
}
