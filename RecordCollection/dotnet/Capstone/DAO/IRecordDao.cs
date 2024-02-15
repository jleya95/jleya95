using Capstone.Models;

namespace Capstone.DAO
{
    public interface IRecordDao
    {
        bool GetRecordById(Record record);
        bool AddRecordToDb(Record record);
    }
}
