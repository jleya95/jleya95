using Capstone.Models;

namespace Capstone.DAO
{
    public interface IRecordDao
    {
        bool CheckRecordExistence(Record record);

        bool GetRecordBySerialNumber(Record record);
        bool AddRecordToDb(Record record);
    }
}
