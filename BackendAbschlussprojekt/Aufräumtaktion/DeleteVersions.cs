using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;

namespace Aufräumtaktion
{
    public class DeleteVersions
    {
        private static List<string> vsVersions = new List<string>();
        private static readonly string sConnectionString;
        private const string sQuery = "Select VersionPath from Version where DeleteVersion = 1"; 

        static DeleteVersions()
        {
            string sJSON = File.ReadAllText("config.json");
            JObject oConfig = JObject.Parse(sJSON);
            sConnectionString = oConfig["Connection"]["Conn"].ToString();
        }

        public static async Task GetVersions()
        {
            await using (SqlConnection oConnection = new(sConnectionString))
            {
                await oConnection.OpenAsync();

                await using (SqlCommand oCMD = new SqlCommand(sQuery, oConnection))
                {
                    await using SqlDataReader oDataReader = await oCMD.ExecuteReaderAsync();
                    if (oDataReader.HasRows)
                    {
                        while (await oDataReader.ReadAsync())
                        {
                            vsVersions.Add(oDataReader.GetString(0));
                        }
                    }
                }
            }
            foreach (string s in vsVersions)
            {
                Console.WriteLine(s);
            }
        }

        public async Task DeleteSQLUserAndDatabase()
        {
            private const string sQuery = "";
        }

        public async Task DeleteVersions()
        {
            
        }
    }
}