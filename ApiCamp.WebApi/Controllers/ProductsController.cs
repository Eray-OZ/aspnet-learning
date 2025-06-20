using ApiCamp.WebApi.Context;
using ApiCamp.WebApi.Dtos.ProductDtos;
using ApiCamp.WebApi.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IValidator<Product> _validator;
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public ProductsController(IValidator<Product> validator, ApiContext context, IMapper mapper)
        {
            _validator = validator;
            _context = context;
            _mapper = mapper;
        }




        [HttpGet]
        public IActionResult ProductList() {

            var values = _context.Products.ToList();

            return Ok(values);
        }



        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {


            var validationResult = _validator.Validate(product);
            

            if (!validationResult.IsValid) {
                    return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
                }

            else
                {
                    _context.Products.Add(product);
                    _context.SaveChanges();
                    return Ok("Created Successfully");

                }
        }




        [HttpDelete]
        public IActionResult DeleteProduct(int id) {

            var value = _context.Products.Find(id);

            _context.Products.Remove(value);

            _context.SaveChanges(); 

            return Ok("ID: " + value.ProductId + " Deleted Successfully");

        }




        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id) {

            var value = _context.Products.Find(id);

            return Ok(value);
        }




        [HttpPut]
        public IActionResult PutProduct(Product product) {


            var validationResult = _validator.Validate(product);


            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }


            else
            {

                _context.Products.Update(product);

                _context.SaveChanges();

                return Ok("ID: " + product.ProductId + " Updated Successfully");
            }
        }




        [HttpPost("CreateProductWithCategory")]
        public IActionResult CreateProductWithCategory(CreateProductDto createProductDto) 
        {

            var product = _mapper.Map<Product>(createProductDto);


            var validationResult = _validator.Validate(product);


            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }


            else
            {

                _context.Products.Add(product);

                _context.SaveChanges();

                return Ok("Created Successfully");
            }

        }





        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {

            var values = _context.Products.Include(x => x.Category).ToList();


            return Ok(_mapper.Map<List<ResultProductWithCategoryDto>>(values));
        }




    } 

}
