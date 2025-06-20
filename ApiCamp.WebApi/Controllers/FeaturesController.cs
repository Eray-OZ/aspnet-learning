using ApiCamp.WebApi.Context;
using ApiCamp.WebApi.Dtos.FeatureDtos;
using ApiCamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly ApiContext _context;


        public FeaturesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        [HttpGet]
        public IActionResult FeatureList()
        {

            var values = _context.Features.ToList();

            return Ok(_mapper.Map<List<ResultFeatureDto>>(values));
        }



        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {

            var value = _mapper.Map<Feature>(createFeatureDto);

            _context.Features.Add(value);

            _context.SaveChanges();

            return Ok("Created Successfully");
        }


        [HttpDelete]
        public IActionResult DeleteFeature(int id) {

            var value = _context.Features.Find(id);

            _context.Features.Remove(value);

            _context.SaveChanges();

            return Ok(value.FeatureId + " Deleted Successfully");
        }



        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id) {

            var value = _context.Features.Find(id);

            return Ok(_mapper.Map<GetByIdFeatureDto>(value));
        }




        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto) {

            var value = _mapper.Map<Feature>(updateFeatureDto);

            _context.Features.Update(value);

            return Ok("ID: " + value.FeatureId + " Updated Successfully");
        }


    }
}
