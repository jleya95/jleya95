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

/*        [HttpGet("{id}")]
        public ActionResult<Record> GetRecordById(int id)
        {
            Record record = new Record();

            return record;
        }
*/
        [HttpGet("random")]
        public ActionResult<Record> GetRandomRecord()
        {
            List<Record> records = recordDao.GetAllRecords();
            Random random = new Random();
            int randomIndex = random.Next(0, records.Count);
            Record randomRecord = records[randomIndex];
            
            return randomRecord;
        }

        [HttpPost("add")]
        public ActionResult<Record> AddRecord(string fileAs, string artist, string title, int releaseYear, string recordLabel, int issueYear, string serialNumber, string pressing, int discNumber, string color, string notes, string needleInfo)
        {
            Record recordToAdd = new Record();
            recordToAdd.File = fileAs;
            recordToAdd.Artist = artist;
            recordToAdd.Title = title;
            recordToAdd.ReleaseYear = releaseYear;
            recordToAdd.Label = recordLabel;
            recordToAdd.IssueYear = issueYear;
            recordToAdd.SerialNumber = serialNumber;
            recordToAdd.Pressing = pressing;
            recordToAdd.DiscNumber = discNumber;
            recordToAdd.Color = color;
            recordToAdd.Notes = notes;
            recordToAdd.NeedleInfo = needleInfo;

            bool recordExists = recordDao.CheckRecordExistence(recordToAdd);
            bool recordAdded;

            if(!recordExists)
            {
                recordAdded = recordDao.AddRecordToDb(recordToAdd);
                if(recordAdded)
                {
                    return Ok(recordToAdd);
                } else
                {
                    return BadRequest("There was a problem adding record");
                }
            }

            return BadRequest("Record already exists in database");
        }
    }
}
