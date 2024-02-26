using Capstone.DAO;
using Capstone.Models;
using Capstone.Services;
using Microsoft.AspNetCore.Mvc;
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


    }
}
