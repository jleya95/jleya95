using Microsoft.AspNetCore.Mvc;
using RecordCollection.Models;
using RecordCollection.Services;

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
        public ActionResult<string> SearchDiscogsForRecord(string title, string artist, string label, string serial, string releaseYear, string issueYear)
        {
            DiscogsSearchRequest request = recordService.GenerateDiscogsSearchObject(title, artist, label, serial, releaseYear, issueYear);
            DiscogsSearchResult searchResults = recordService.SearchDiscogsForRecord(request);
            if (searchResults != null && searchResults.Results[0] != null)
            {
                CoverArt coverArt = recordService.GetCoverArtFromDiscogs(searchResults.Results[0].Id);
                return Ok(coverArt.Images[0].Uri);
            } else
            {
                return BadRequest();
            }
        }

    }
}
