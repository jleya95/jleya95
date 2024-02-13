namespace Capstone.DAO
{
    public class RecordSqlDao : IRecordDao
    {
        private readonly string connectionString;
        public RecordSqlDao(string dbConnectionString) {
            connectionString = dbConnectionString;
        }
    }
}