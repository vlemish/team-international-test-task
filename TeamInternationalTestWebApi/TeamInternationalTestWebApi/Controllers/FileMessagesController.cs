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
        public ActionResult<List<ReadFileMessageDto>> GetAll()
        {
            var userId = (HttpContext.Items["User"] as User).Id;

            var files = (_fileRepo as FileMessageRepo).GetAllFilesManifestByUserId(userId);

            var list = _mapper.Map<IEnumerable<ReadFileMessageDto>>(files);

            return Ok(list);
        }

        //GET: api/file-messages/1
        [Authorize]
        [HttpGet("{id}", Name = "GetFileById")]
        public ActionResult<ReadFileMessageDto> GetFileById(int id)
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

        //POST: api/file-messages
        [Authorize]
        [HttpPost]
        public IActionResult CreateFile()
        {
            var file = HttpContext.Request.Form.Files.First();
            if (file == null)
            {
                return BadRequest();
            }

            var userId = (HttpContext.Items["User"] as User).Id;
            var createFileMessageDto = new CreateFileMessageDto(file, userId);

            try
            {
                var model = _mapper.Map<FileMessage>(createFileMessageDto);
                _fileRepo.Add(model);

                //mapping doesn't work
                //var fileMessageReadDto = _mapper.Map<FileMessageManifest>(model);
                ////return CreatedAtRoute(nameof(GetFileById), new { Id = fileMessageReadDto.Id }, fileMessageReadDto);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("download/{id}")]
        public IActionResult Download(int id)
        {
            var file = _fileRepo.GetOneById(id);
            if (file == null)
            {
                return NotFound();
            }

            MemoryStream memoryStream = new MemoryStream(file.Data);

            return File(memoryStream, file.ContentType, file.Name);
        }

        //DELETE: api/file-messages/1
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteFile(int id)
        {
            var file = _fileRepo.GetOneById(id);
            if (file == null)
            {
                return NotFound();
            }

            try
            {
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
