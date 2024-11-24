using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRBusiness.Abstract;
using SignalRDto.CategoryDto;
using SignalRDto.ContactDto;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _service;
        private readonly IMapper _mapper;
        public ContactController(IContactService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetContactList()
        {
            var result = _mapper.Map<List<ResultContactDto>>(_service.TGetListAll());
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {

            _service.TAdd(new Contact
            {
                FooterDescription = createContactDto.FooterDescription,
                Location = createContactDto.Location,
                Mail = createContactDto.Mail,
                Phone = createContactDto.Phone
            });
            return Ok("Başarıyla iletişim eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var result = _service.TGetById(id);
            _service.TDelete(result);
            return Ok("İletişim başarıyla silindi");
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            _service.TUpdate(new Contact
            {
                ContactId = updateContactDto.ContactId,
                Phone = updateContactDto.Phone,
                Mail = updateContactDto.Mail,
                Location = updateContactDto.Location,
                FooterDescription = updateContactDto.FooterDescription
            });
            return Ok("Başarıyla güncellendi...");
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var result = _service.TGetById(id);
            return Ok(result);
        }
    }
}
