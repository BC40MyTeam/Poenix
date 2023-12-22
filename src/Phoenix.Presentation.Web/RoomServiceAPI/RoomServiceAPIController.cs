using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Phoenix.Presentation.Web.RoomServiceAPI;
[Route("api/roomservice")]
[ApiController]
public class RoomServiceAPIController : ControllerBase
{
    private readonly RoomServiceAPIService _roomServiceAPIService;

    public RoomServiceAPIController(RoomServiceAPIService roomServiceAPIService)
    {
        _roomServiceAPIService = roomServiceAPIService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var vm = _roomServiceAPIService.GetAllEmployee();
        return Ok(vm);
    }


    [HttpPost("InsertEmployee")]
    public IActionResult Insert(RoomServiceDto dto)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest();
        }

        var insert = _roomServiceAPIService.InsertEmployee(dto);
        return Created("",insert);
    }
}

