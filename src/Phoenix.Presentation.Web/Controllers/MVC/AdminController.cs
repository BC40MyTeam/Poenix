using Microsoft.AspNetCore.Mvc;
using Phoenix.Presentation.Web.Services;

namespace Phoenix.Presentation.Web.Controllers.MVC
{
    [Route("Admin")]
    public class AdminController : Controller
    {
        private readonly AdminService _service;

        public AdminController(AdminService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
