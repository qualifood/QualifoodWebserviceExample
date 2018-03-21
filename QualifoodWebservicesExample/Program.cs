using System;
using QualifoodWebservicesExample.Qualifood.Webservices;

namespace QualifoodWebservicesExample
{
    class Program
    {
        private const string QualifoodBenutzername = "";
        private const string QualifoodPassword = "";
        private static readonly DateTime AbgefragtesSchlachtdatum = DateTime.Today.AddDays(-1);

        static void Main(string[] args)
        {
            try
            {
                var client = CreateClient();

                var result = ExecuteRequest(client);

                PrintResult(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.Read();
            }
        }

        private static DatenDownloadClient CreateClient()
        {
            DatenDownloadClient client = new DatenDownloadClient("BasicHttpBinding_IDatenDownload");

            client.ClientCredentials.UserName.UserName = QualifoodBenutzername;
            client.ClientCredentials.UserName.Password = QualifoodPassword;
            return client;
        }

        private static SchlachtdatenGV ExecuteRequest(DatenDownloadClient client)
        {
            var result = client.GetDatenDownloadGV(AbgefragtesSchlachtdatum);
            return result;
        }

        private static void PrintResult(SchlachtdatenGV result)
        {
            Console.WriteLine($"Abgefragtes Schlachtdatum: {AbgefragtesSchlachtdatum:d}");
            Console.WriteLine($"Anzahl Schlachtkörper: {result.Schlachtkoerper.Length}");
            Console.WriteLine($"Anzahl Stammdaten: {result.Stammdaten.Length}");
        }
    }
}
