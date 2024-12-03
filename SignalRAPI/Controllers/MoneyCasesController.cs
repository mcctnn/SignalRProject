using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusiness.Abstract;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyCasesController : ControllerBase
    {
        private readonly IMoneyCaseService _moneyCaseService;

        public MoneyCasesController(IMoneyCaseService moneyCaseService)
        {
            _moneyCaseService = moneyCaseService;
        }

        [HttpGet("TotalMoneyCaseAmount")]
        public IActionResult TotalMoneyCaseAmount() => Ok(_moneyCaseService.TTotalMoneyCaseAmount());
    }
}
