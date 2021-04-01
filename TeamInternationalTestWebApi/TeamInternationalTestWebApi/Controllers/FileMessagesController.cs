using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using TeamInternationalTestEf.Models;
using TeamInternationalTestEf.Repos;
using TeamInternationalTestWebApi.DTOs.FileMessageDTOs;
using TeamInternationalTestWebApi.Helpers;

namespace TeamInternationalTestWebApi.Controllers
{
    [Route("api/file-messages")]
    [ApiController]
    public class FileMessagesController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IRepo<FileMessage> _fileRepo;


        public FileMessagesController(IMapper mapper, IRepo<FileMessage> fileRepo)
        {
            _mapper = mapper;
            _fileRepo = fileRepo;
        }


        //GET: api/file-messages/
        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<ReadFileMessageDto>> GetAll()
        {
            try
            {
                var userId = (HttpContext.Items["User"] as User).Id;

                var files = (_fileRepo as FileMessageRepo).GetAllFilesManifestByUserId(userId);

                var list = _mapper.Map<IEnumerable<ReadFileMessageDto>>(files);

                return Ok(list);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        //GET: api/file-messages/1
        [Authorize]
        [HttpGet("{id}", Name = "GetFileById")]
        public ActionResult<ReadFileMessageDto> GetFileById(int id)
        {
            try
            {
                var userId = (HttpContext.Items["User"] as User).Id;

                var file = _fileRepo.GetOneById(id);
                if (file == null)
                {
                    return NotFound();
                }

                var readFileMessageDto = _mapper.Map<ReadFileMessageDto>(file);
                return Ok(readFileMessageDto);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        //POST: api/file-messages
        [Authorize]
        [HttpPost]
        public IActionResult CreateFile()
        {
            try
            {
                var file = HttpContext.Request.Form.Files.First();
                if (file == null)
                {
                    return BadRequest();
                }

                var userId = (HttpContext.Items["User"] as User).Id;
                var createFileMessageDto = new CreateFileMessageDto(file, userId);

                var model = _mapper.Map<FileMessage>(createFileMessageDto);
                _fileRepo.Add(model);

                var fileMessageReadDto = _mapper.Map<FileMessageManifest>(model);
                return CreatedAtRoute(nameof(GetFileById), new { Id = fileMessageReadDto.Id }, fileMessageReadDto);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("download/{id}")]
        public IActionResult Download(int id)
        {
            try
            {
                var file = _fileRepo.GetOneById(id);
                if (file == null)
                {
                    return NotFound();
                }

                MemoryStream memoryStream = new MemoryStream(file.Data);

                return File(memoryStream, file.ContentType, file.Name);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        //DELETE: api/file-messages/1
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteFile(int id)
        {
            try
            {
                var file = _fileRepo.GetOneById(id);
                if (file == null)
                {
                    return NotFound();
                }

                _fileRepo.Remove(file);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}
