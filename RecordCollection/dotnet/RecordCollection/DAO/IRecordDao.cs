using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IRecordDao
    {
        bool CheckRecordExistence(Record record);

        bool GetRecordBySerialNumber(Record record);
        bool AddRecordToDb(Record record);
        List<Record> GetAllRecords();

    }
}
