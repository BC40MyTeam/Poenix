using Microsoft.AspNetCore.Mvc;
using Phoenix.Presentation.Web.Services;

namespace Phoenix.Presentation.Web.Controllers.API
{
    [Route("api/v1/Admin")]
    [ApiController]
    public class ApiAdminController : Controller
    {
        private readonly AdminService _service;

        public ApiAdminController(AdminService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return Ok();
        }
    }
}
