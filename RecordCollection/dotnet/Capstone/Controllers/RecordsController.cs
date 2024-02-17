using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class RecordsController : ControllerBase
    {
        private readonly IRecordDao recordDao;
        public RecordsController(IRecordDao recordDao)
        {
            this.recordDao = recordDao;
        }

        [HttpGet]
        public ActionResult<List<Record>> GetListOfRecords()
        {
            List<Record> records = recordDao.GetAllRecords();

            return records;
        }

        [HttpGet("{id}")]
        public ActionResult<Record> GetRecordById(int id)
        {
            Record record = new Record();

            return record;
        }

        [HttpGet("random")]
        public ActionResult<Record> GetRandomRecord()
        {
            List<Record> records = recordDao.GetAllRecords();
            Random random = new Random();
            int randomIndex = random.Next(0, records.Count);
            Record randomRecord = records[randomIndex];
            
            return randomRecord;
        }
    }
}
