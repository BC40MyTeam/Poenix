using Microsoft.AspNetCore.Mvc;

namespace Phoenix.Presentation.Web.Controllers;

[Route("RoomService")]
public class RoomServiceController : Controller
{
    [HttpGet()]
    public IActionResult Index()
    {
        return View();
    }
}

