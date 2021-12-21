using Newtonsoft.Json;
using System.IO;

namespace AEAS.Database
{
    internal class DBConfigReader
    {
        const string CONF_FILE_PATH = "../../Database/dbconfig.json";
        private static DBConfig GetDBConfig()
        {
            string json = File.ReadAllText(CONF_FILE_PATH);
            return JsonConvert.DeserializeObject<DBConfig>(json);
        }

        public static string GetConfString()
        {
            return "server=" + GetDBConfig().Server + "; user=" + GetDBConfig().User + "; database="
                + GetDBConfig().Database + "; password=" + GetDBConfig().Password;
        }
    }
}
