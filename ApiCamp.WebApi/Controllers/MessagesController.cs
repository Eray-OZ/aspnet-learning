﻿using ApiCamp.WebApi.Context;
using ApiCamp.WebApi.Dtos.MessageDtos;
using ApiCamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {


        private readonly IMapper _mapper;

        private readonly ApiContext _context;

        public MessagesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }



        [HttpGet]
        public IActionResult MessageList() 
        {
            var value = _context.Messages.ToList();

            return Ok(_mapper.Map<List<ResultMessageDto>>(value));
        }


        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {

            var value = _mapper.Map<Message>(createMessageDto);

            _context.Messages.Add(value);

            _context.SaveChanges();

            return Ok("Created Successfully");
        }



        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);

            _context.Messages.Remove(value);

            _context.SaveChanges();

            return Ok("Deleted Successfully");
        }


        [HttpGet("GetMessae")]
        public IActionResult GetMessage(int id)
        {

            var value = _context.Messages.Find(id);

            return Ok(_mapper.Map<GetByIdMessageDto>(value));
        }



        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {

            var value = _mapper.Map<Message>(updateMessageDto);

            _context.Messages.Update(value);

            _context.SaveChanges();

            return Ok("ID: " + value.MessageId + " Updated Successfully");
        }

    }
}
