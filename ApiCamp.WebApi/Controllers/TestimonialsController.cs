using ApiCamp.WebApi.Context;
using ApiCamp.WebApi.Dtos.TestimonialDtos;
using ApiCamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {


        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public TestimonialsController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }




        [HttpGet]
        public IActionResult TestimonialsList()
        {

            var values = _context.Testimonials.ToList();

            return Ok(_mapper.Map<List<ResultTestimonialDto>>(values));
        }




        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {

            var value = _mapper.Map<Testimonial>(createTestimonialDto);

            _context.Testimonials.Add(value);

            _context.SaveChanges();

            return Ok(value);
        }


    }
}
