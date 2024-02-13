using Capstone.Models;
namespace Capstone.DAO
{
    public class RecordSqlDao : IRecordDao
    {
        private readonly string connectionString;
        public RecordSqlDao(string dbConnectionString) {
            connectionString = dbConnectionString;
        }

        public Record AddRecordToDB(Record record)
        {
            Record recordToAdd = new Record();

            return recordToAdd;
        }
    }
}