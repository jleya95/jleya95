using Capstone.Models;
using Capstone.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FileReadController : ControllerBase
    {
        private readonly IFileService fileService;
        public FileReadController(IFileService fileService)
        {
            this.fileService = fileService;
        }

        [HttpGet]
        public ActionResult<List<Record>> GenerateListOfRecords()
        {
            List<Record> fileRead = fileService.ReadFile();
            if (fileRead.Count != 0)
            {
                return Ok(fileRead);
            }
            return BadRequest();
        }
    }
}
