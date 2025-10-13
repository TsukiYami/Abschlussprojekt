using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;

namespace Aufräumtaktion
{
    public class WriteVersionsInDB
    {
        private static HashSet<string> sVersionPath = new HashSet<string>();
        private static string sConnectionString;
        private const string sQuery = "insert into Version (VersionPath, FakturaPath) VALUES (@VersionPath, @FakturaPath)";

        static WriteVersionsInDB()
        {
            string sJSON = File.ReadAllText("config.json");
            JObject oConfig = JObject.Parse(sJSON);
            sConnectionString = oConfig["Connection"]["Conn"].ToString();
            sVersionPath = FindOutVersions.GetAllVersions();
        }

        public static void WriteVersion()
        {
            using (SqlConnection oConnection = new (sConnectionString))
            {
                oConnection.Open();
                foreach (string sVersion in sVersionPath)
                {
                    using (SqlCommand oCMD = new SqlCommand(sQuery, oConnection))
                    {
                        oCMD.Parameters.AddWithValue("@VersionPath", sVersion);

                        int nRowsAffected = oCMD.ExecuteNonQuery();
                        Console.WriteLine($"{nRowsAffected} Zeilen(n) eingefügt");
                    }
                }
            }
        }
    }
}