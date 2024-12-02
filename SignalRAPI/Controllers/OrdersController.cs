using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusiness.Abstract;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet("GetAll")]
        public IActionResult Get() => Ok(_orderService.TGetListAll());
        [HttpGet("{id}")]
        public IActionResult GetOrder(int id) => Ok(_orderService.TGetById(id));
        [HttpGet("OrderCount")]
        public IActionResult OrderCount() => Ok(_orderService.TOrderCount());
        [HttpGet("ActiveOrderCount")]
        public IActionResult ActiveOrderCount() => Ok(_orderService.TActiveOrderCount());
        [HttpGet("LastOrderPrice")]
        public IActionResult LastOrderPrice() => Ok(_orderService.TLastOrderPrice());
    }
}
