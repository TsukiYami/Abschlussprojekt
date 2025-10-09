namespace Aufräumtaktion
{
    public class FindOutVersions
    {
        private static HashSet<string> sVersionNames = new HashSet<string>();
        private const string sPath = "C:\\ALPHAPLAN\\Alphaplan Versionen\\";

        public static HashSet<string> GetAllVersions()
        {
            foreach (string Version in Directory.EnumerateDirectories(sPath))
            {
                sVersionNames.Add(Version);
            }

            return sVersionNames;
        }
    }
}