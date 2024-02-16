using Capstone.Models;

namespace Capstone.DAO
{
    public interface IRecordDao
    {
        bool GetRecordBySerialNumber(Record record);
        bool AddRecordToDb(Record record);
    }
}
