using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRBusiness.Abstract;
using SignalRDto.BookingDto;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _service;

        public BookingController(IBookingService service)
        {
            _service = service;
        }


        [HttpGet]
        public IActionResult GetBookingList()
        {
            var result = _service.TGetListAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            Booking booking = new Booking()
            {
                Mail = createBookingDto.Mail,
                Date = createBookingDto.Date,
                Name = createBookingDto.Name,
                PersonCount = createBookingDto.PersonCount,
                Phone = createBookingDto.Phone
            };
            _service.TAdd(booking);
            return Ok("Başarıyla eklendi...");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var result = _service.TGetById(id);
            _service.TDelete(result);
            return Ok("Başarıyla silindi...");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking()
            {
                Mail = updateBookingDto.Mail,
                Date = updateBookingDto.Date,
                Name = updateBookingDto.Name,
                PersonCount = updateBookingDto.PersonCount,
                Phone = updateBookingDto.Phone,
                BookingId = updateBookingDto.BookingId
            };
            _service.TUpdate(booking);
            return Ok("Başarıyla güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var result = _service.TGetById(id);
            return Ok(result);
        }

    }
}
