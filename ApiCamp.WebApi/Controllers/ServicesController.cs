using ApiCamp.WebApi.Context;
using ApiCamp.WebApi.Dtos.ServiceDtos;
using ApiCamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        

        private readonly ApiContext _context;
        private readonly IMapper _mapper;



        
        public ServicesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResultServiceDto>>> ServiceList()
        {

            var values = await _context.Services.ToListAsync();

            return Ok(_mapper.Map<List<ResultServiceDto>>(values));
        }



        [HttpPost]
        public IActionResult CreateService(CreateServiceDto createServiceDto)
        {

            var value = _mapper.Map<Service>(createServiceDto);

            _context.Services.Add(value);

            _context.SaveChanges();

            return Ok(value);
        }


    }
}
