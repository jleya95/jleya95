using Capstone.DAO;
using Capstone.Models;
using Capstone.Services;
using Microsoft.AspNetCore.Mvc;
using RecordCollection.Models;
using RecordCollection.Services;
using System.Collections.Generic;

namespace RecordCollection.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly IRecordService recordService;

        public APIController(IRecordService recordService)
        {
            this.recordService = recordService;
        }

        [HttpGet("search")]
        public ActionResult<DiscogsSearchResult> SearchDiscogsForRecord(string title, string artist, string label, string serial, string releaseYear, string issueYear)
        {
            DiscogsSearchRequest request = recordService.GenerateDiscogsSearchObject(title, artist, label, serial, releaseYear, issueYear);
            DiscogsSearchResult searchResults = recordService.SearchDiscogsForRecord(request);
            return Ok(searchResults);
        }

    }
}
