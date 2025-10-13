namespace Aufräumtaktion
{
    public class FindOutVersions
    {
        private static HashSet<string> sVersionNames = new HashSet<string>();
        private const string sPath = "C:\\ALPHAPLAN\\Alphaplan Versionen\\";

        public static HashSet<string> GetAllVersions()
        {
            foreach (string sVersion in Directory.EnumerateDirectories(sPath))
            {
                sVersionNames.Add(sVersion);
            }

            return sVersionNames;
        }
    }
}