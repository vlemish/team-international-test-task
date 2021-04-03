using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

using TeamInternationalTestEf.Models;
using TeamInternationalTestEf.Models.Exceptions;
using TeamInternationalTestEf.Repos;
using TeamInternationalTestWebApi.DTOs.FileMessageDTOs;
using TeamInternationalTestWebApi.DTOs.ImgMessageDtos;
using TeamInternationalTestWebApi.Helpers;

namespace TeamInternationalTestWebApi.Controllers
{
    [Authorize]
    [Route("api/img-messages")]
    [ApiController]
    public class ImageMessageController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IRepo<ImageMessage> _repo;


        public ImageMessageController(IMapper mapper, IRepo<ImageMessage> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }


        //GET: api/img-messages/
        [HttpGet]
        public ActionResult<List<ReadImgMessageDto>> GetAllImgs()
        {
            try
            {
                var userId = (HttpContext.Items["User"] as User).Id;

                var files = (_repo as ImageMessageRepo).GetAllByUserId(userId);

                var list = _mapper.Map<IEnumerable<ReadImgMessageDto>>(files);

                return Ok(list);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        //GET: api/img-messages/1

        [HttpGet("{id}", Name = "GetImgById")]
        public ActionResult<ReadImgMessageDto> GetImgById(int id)
        {
            try
            {
                var userId = (HttpContext.Items["User"] as User).Id;

                var file = _repo.GetOneById(id);
                if (file == null)
                {
                    return NotFound();
                }

                var readFileMessageDto = _mapper.Map<ReadImgMessageDto>(file);
                return Ok(readFileMessageDto);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        //POST: api/img-messages/
        //[Authorize]
        [HttpPost]
        public IActionResult CreateImg()
        {
            try
            {
                var file = HttpContext.Request.Form.Files.First();
                if (file == null)
                {
                    return BadRequest();
                }

                var userId = (HttpContext.Items["User"] as User).Id;
                var createImgMessageDto = new CreateImgMessageDto(file, userId);

                var model = _mapper.Map<ImageMessage>(createImgMessageDto);
                _repo.Add(model);


                var fileMessageReadDto = _mapper.Map<ReadImgMessageDto>(model);
                return CreatedAtRoute(nameof(GetImgById), new { Id = fileMessageReadDto.Id }, fileMessageReadDto);
            }
            catch (InvalidContentTypeException e)
            {
                return BadRequest("Only images are allowed!");
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        //DELETE: api/img-messages/1

        [HttpDelete("{id}")]
        public IActionResult DeleteImg(int id)
        {
            try
            {
                var file = _repo.GetOneById(id);
                if (file == null)
                {
                    return NotFound();
                }

                _repo.Remove(file);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
