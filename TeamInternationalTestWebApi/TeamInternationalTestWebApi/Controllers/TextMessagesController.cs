using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TeamInternationalTestEf.Models;
using TeamInternationalTestEf.Repos;
using TeamInternationalTestWebApi.DTOs.TextMessageDTOs;
using TeamInternationalTestWebApi.Helpers;

namespace TeamInternationalTestWebApi.Controllers
{
    [Authorize]
    [Route("api/text-messages")]
    [ApiController]
    public class TextMessagesController : ControllerBase
    {
        private readonly IRepo<TextMessage> _repo;

        private readonly IMapper _mapper;


        public TextMessagesController(IMapper mapper, IRepo<TextMessage> repo)
        {
            _repo = repo;
            _mapper = mapper;
        }


        //GET: /api/text-messages/
        [HttpGet]
        public ActionResult<IEnumerable<ReadTextMessageDto>> GetAllTextMessages()
        {
            var userId = (HttpContext.Items["User"] as User).Id;
            var textMessages = (_repo as TextMessageRepo).GetAllByUserId(userId).ToList();
            var readDto = _mapper.Map<IEnumerable<ReadTextMessageDto>>(textMessages);
            return Ok(readDto);
        }

        //GET: /api/text-messages/1
        [HttpGet("{id}", Name = "GetTextMessageById")]
        public ActionResult<ReadTextMessageDto> GetTextMessageById(int id)
        {
            var textMessage = _repo.GetOneById(id);
            if (textMessage == null)
            {
                return NotFound();
            }

            var readDto = _mapper.Map<ReadTextMessageDto>(textMessage);
            return Ok(readDto);
        }

        //POST: /api/text-messages/
        [HttpPost]
        public IActionResult AddTextMessage(CreateUpdateClientMessageDto content)
        {
            if (content == null)
            {
                return BadRequest("Value can't be null!");
            }
            var userId = (HttpContext.Items["User"] as User).Id;
            var updateDeleteTextMessageDto = new CreateUpdateServerMessageDto()
            {
                Content = content.Content,
                UserId = userId

            };
            var textMessage = _mapper.Map<TextMessage>(updateDeleteTextMessageDto);
            _repo.Add(textMessage);

            var readMessageDto = _mapper.Map<ReadTextMessageDto>(textMessage);

            return CreatedAtRoute(nameof(GetTextMessageById), new { Id = readMessageDto.Id }, readMessageDto);
        }

        //PUT /api/text-messages/1
        [HttpPut("{id}")]
        public IActionResult UpdateTextMessage(int id, CreateUpdateClientMessageDto updateDeleteTextMessageDto)
        {
            var textMessage = _repo.GetOneById(id);
            if (textMessage == null)
            {
                return NotFound();
            }

            try
            {
                textMessage.Content = updateDeleteTextMessageDto.Content;
                _repo.Update(textMessage);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        //DELETE: /api/text-messages/1
        [HttpDelete("{id}")]
        public IActionResult DeleteTextMessage(int id)
        {
            var textMessage = _repo.GetOneById(id);
            if (textMessage == null)
            {
                return NotFound();
            }

            try
            {
                _repo.Remove(textMessage);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
