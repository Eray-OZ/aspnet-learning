using ApiCamp.WebApi.Context;
using ApiCamp.WebApi.Dtos.ContactDtos;
using ApiCamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApiContext _context;

        public ContactsController(ApiContext context)
        {
            _context = context;
        }



        [HttpGet]
        public IActionResult ContactList() { 

            var values = _context.Contacts.ToList();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto) {

            Contact contact = new()
            {
                Email = createContactDto.Email,
                Address = createContactDto.Address,
                Phone = createContactDto.Phone,
                MapLocation = createContactDto.MapLocation,
                OpenHours = createContactDto.OpenHours
            };

            _context.Contacts.Add(contact);

            _context.SaveChanges();

            return Ok("Created Successfully");
        }


        [HttpDelete]
        public IActionResult DeleteContact(int id) {

            var value = _context.Contacts.Find(id);

            _context.Contacts.Remove(value);

            _context.SaveChanges();

            return Ok(value.ContactId + " Deleted Successfully");
        }

        [HttpGet("GetContact")]
        public IActionResult GetContact(int id) {

            var value = _context.Contacts.Find(id);

            return Ok(value);
        }



        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto) {

            Contact contact = new()
            {
                ContactId = updateContactDto.ContactId,
                Email = updateContactDto.Email,
                Address = updateContactDto.Address,
                Phone = updateContactDto.Phone,
                MapLocation = updateContactDto.MapLocation,
                OpenHours = updateContactDto.OpenHours
            };

            _context.Contacts.Update(contact);

            _context.SaveChanges();

            return Ok(contact.ContactId + " Updated Successfully");
        }

    }
}
