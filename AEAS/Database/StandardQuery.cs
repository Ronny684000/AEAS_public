using MySql.Data.MySqlClient;

namespace AEAS.Database
{
    internal class StandardQuery
    {
        public static T GetSingle<T>(string query) where T : new()
        {
            DBCommandExecutor getFirstEntry = new DBCommandExecutor();
            MySqlDataReader reader = getFirstEntry.getReader(query);
            T singleStatement = new T();
            while (reader.Read())
            {
               singleStatement = reader.GetFieldValue<T>(0);
            }
            reader.Close();
            return singleStatement;
        }
    }
}
