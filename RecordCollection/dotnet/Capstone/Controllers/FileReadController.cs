using Capstone.Services;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult ReadFile()
        {
            bool fileRead = fileService.ReadFile();
            if (fileRead)
            {
                return Ok(fileRead);
            }
            return BadRequest();
        }
    }
}
