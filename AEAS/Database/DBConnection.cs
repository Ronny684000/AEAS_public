using MySql.Data.MySqlClient;

namespace AEAS.Database
{
    internal class DBConnection
    {
        private static DBConnection dBConnection;
        private MySqlConnection mysqlConnection;
        private string CONN_STRING = DBConfigReader.GetConfString();

        private DBConnection()
        {
            mysqlConnection = new MySqlConnection(CONN_STRING);
            OpenMysqlConnection();
        }

        public static DBConnection GetInstance()
        {
            if (dBConnection == null)
            {
                dBConnection = new DBConnection();
            }
            return dBConnection;
        }

        public void OpenMysqlConnection()
        {
            mysqlConnection.Open();
        }

        public MySqlConnection GetMySqlConnection()
        {
            return mysqlConnection;
        }

        public void CloseMysqlConnection()
        {
            mysqlConnection.Close();
        }
    }
}
