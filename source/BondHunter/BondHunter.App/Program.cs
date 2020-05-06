namespace BondHunter.App
{
    using System;
    using System.Text;
    using System.Threading.Tasks;
    using Objects.Enums;

    public sealed class Program
    {
        public static async Task Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            await SingleQuery();

            var client = HunterClientFactory.Create();

            var data = await client.GetData("46.174.55.174", "151.80.113.111")
                .Fields(HunterField.CountryCode)
                .ExecuteAsync();

            Console.WriteLine(data.Response[0].CountryCode);
            Console.WriteLine(data.Response[1].CountryCode);

            Console.WriteLine(data.RemainingRequests);
            Console.WriteLine(data.LimitExpirationInSeconds);

            Console.ReadKey();
        }

        private static async Task SingleQuery()
        {
            var client = HunterClientFactory.Create();

            var data = await client.GetData("46.174.55.174")
                .Language(HunterLanguage.Russian)
                .ExecuteAsync();

            Console.WriteLine(data.Response[0].Status);
            Console.WriteLine(data.Response[0].Message);
            Console.WriteLine(data.Response[0].City);
            Console.WriteLine(data.Response[0].Continent);
            Console.WriteLine(data.Response[0].ContinentCode);
            Console.WriteLine(data.Response[0].Country);
            Console.WriteLine(data.Response[0].CountryCode);
            Console.WriteLine(data.Response[0].Currency);
            Console.WriteLine(data.Response[0].District);
            Console.WriteLine(data.Response[0].Latitude);
            Console.WriteLine(data.Response[0].Longitude);
            Console.WriteLine(data.Response[0].Region);
            Console.WriteLine(data.Response[0].RegionName);
            Console.WriteLine(data.Response[0].TimeZone);
            Console.WriteLine(data.Response[0].Zip);

            Console.WriteLine(data.RemainingRequests);
            Console.WriteLine(data.LimitExpirationInSeconds);
        }
    }
}