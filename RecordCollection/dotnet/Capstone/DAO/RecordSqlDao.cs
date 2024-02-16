using Capstone.Models;
using System;
using System.Data.SqlClient;
namespace Capstone.DAO
{
    public class RecordSqlDao : IRecordDao
    {
        private readonly string connectionString;
        public RecordSqlDao(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public bool CheckRecordExistence(Record record)
        {
            string sql = "SELECT record_id FROM records " +
                "WHERE title = @title";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@title", record.Title);
                    cmd.Parameters.AddWithValue("@artist", record.Artist);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
            return false;
        }

        // TODO fix when line has no Serial number
        public bool GetRecordBySerialNumber(Record record)
        {
            if (record.SerialNumber == "" || record.SerialNumber == null)
            {
                string sql = "SELECT record_id, file_as, artist, title, release_year, record_label, issue_year, serial_number, pressing, disc_number, color, notes, needle_info " +
                "FROM records " +
                "WHERE title = @title AND artist = @artist";

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@title", record.Title);
                        cmd.Parameters.AddWithValue("@artist", record.Artist);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            return true;
                        }
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                string sql = "SELECT record_id, file_as, artist, title, release_year, record_label, issue_year, serial_number, pressing, disc_number, color, notes, needle_info " +
    "FROM records " +
    "WHERE serial_number = @serial_number";

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@serial_number", record.SerialNumber);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            return true;
                        }
                    }
                }
                catch (System.Exception)
                {

                    throw;
                }

            }


            return false;
        }

        public bool AddRecordToDb(Record record)
        {
            int recordId = 0;

            string sql = "INSERT INTO records (file_as, artist, title, release_year, record_label, issue_year, serial_number, pressing, disc_number, color, notes, needle_info)" +
                "OUTPUT INSERTED.record_id " +
                "VALUES (@file_as, @artist, @title, @release_year, @record_label, @issue_year, @serial_number, @pressing, @disc_number, @color, @notes, @needle_info);";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@file_as", record.File);
                    cmd.Parameters.AddWithValue("@artist", record.Artist);
                    cmd.Parameters.AddWithValue("@title", record.Title);
                    cmd.Parameters.AddWithValue("@release_year", record.ReleaseYear);
                    cmd.Parameters.AddWithValue("@record_label", record.Label);
                    cmd.Parameters.AddWithValue("@issue_year", record.IssueYear);
                    cmd.Parameters.AddWithValue("@serial_number", record.SerialNumber);
                    cmd.Parameters.AddWithValue("@pressing", record.Pressing);
                    cmd.Parameters.AddWithValue("@disc_number", record.DiscNumber);
                    cmd.Parameters.AddWithValue("@color", record.Color);
                    cmd.Parameters.AddWithValue("@notes", record.Notes);
                    cmd.Parameters.AddWithValue("@needle_info", record.NeedleInfo);

                    recordId = Convert.ToInt32(cmd.ExecuteScalar());
                    return true;
                }

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}