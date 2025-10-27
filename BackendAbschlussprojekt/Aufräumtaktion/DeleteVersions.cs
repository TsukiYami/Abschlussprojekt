using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufräumtaktion
{
    public class DeleteVersions
    {
        private static string sConnectionString;
        private const string sQuery = "Select VersionPath from Version where DeleteVersion = 1"; 

        private DeleteVersions()
        {
            string sJSON = File.ReadAllText("config.json");
            JObject oConfig = JObject.Parse(sJSON);
            sConnectionString = oConfig["Connection"]["Conn"].ToString();
        }

        public static void GetVersions()
        {
            using (SqlConnection oConnection = new(sConnectionString))
            {
                oConnection.Open();

                using (SqlCommand oCMD = new SqlCommand(sQuery, oConnection))
                {
                    using SqlDataReader oDataReader = oCMD.ExecuteReader();
                    if (oDataReader.HasRows)
                    {
                        foreach (string s in oDataReader)
                        {
                            Console.WriteLine(s);
                        }
                    }
                }
            }
        }
    }
}
