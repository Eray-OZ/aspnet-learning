using ApiCamp.WebApi.Context;
using ApiCamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly ApiContext _context;

        public ChefsController(ApiContext context) {
            _context = context;
        }


        [HttpGet]
        public IActionResult ChefList() {
        
            var values = _context.Chefs.ToList();

            return Ok(values);
        }


        [HttpPost]
        public IActionResult CreatePost(Chef chef) {

            _context.Chefs.Add(chef);

            _context.SaveChanges();

            return Ok("Created Successfully");
        }



        [HttpDelete]
        public IActionResult DeleteChef(int id) {

            var value = _context.Chefs.Find(id);

            _context.Chefs.Remove(value);

            _context.SaveChanges();

            return Ok("Chef: " + value.NameSurname + " Deleted");
        }


        [HttpGet("GetChef")]
        public IActionResult GetChef(int id) {
            return Ok(_context.Chefs.Find(id)); 
        }


        [HttpPut]
        public IActionResult PutChef(Chef chef) {

            _context.Chefs.Update(chef);

            _context.SaveChanges();

            return Ok("Updated Successfully: " + chef.ChefId);
        }
    }
}
