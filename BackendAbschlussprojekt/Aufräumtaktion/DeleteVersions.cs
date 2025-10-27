using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;

namespace Aufräumtaktion
{
    public class DeleteVersions
    {
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
                            string s = oDataReader.GetString(0);
                            Console.WriteLine(s);
                        }
                    }
                }
            }
        }
    }
}
