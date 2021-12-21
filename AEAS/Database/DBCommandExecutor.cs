using MySql.Data.MySqlClient;

namespace AEAS.Database
{
    internal class DBCommandExecutor
    {
        private MySqlDataReader DataReader { get; set; }
        private void GetResponse(string query, MySqlConnection conn)
        {
            DataReader = new MySqlCommand(query, conn).ExecuteReader();
        }

        public MySqlDataReader getReader(string query)
        {
            GetResponse(query, DBConnection.GetInstance().GetMySqlConnection());
            return DataReader;
        }
    }
}
