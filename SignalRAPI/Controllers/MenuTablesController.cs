using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusiness.Abstract;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTableService _service;

        public MenuTablesController(IMenuTableService service)
        {
            _service = service;
        }
        [HttpGet("MenuTableCount")]
        public ActionResult MenuTableCount() => Ok(_service.TMenuTableCount());
    }
}
