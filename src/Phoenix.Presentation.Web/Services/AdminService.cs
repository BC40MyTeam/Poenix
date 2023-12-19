using Phoenix.Business.Interfaces;

namespace Phoenix.Presentation.Web.Services
{
    public class AdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
    }
}
