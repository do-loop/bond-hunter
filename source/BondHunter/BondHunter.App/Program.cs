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

            var client = HunterClientFactory.Create();

            var data = await client.GetData("46.174.55.174")
                .Language(HunterLanguage.Russian)
                .Fields(HunterField.CountryCode)
                .ExecuteAsync();

            Console.WriteLine(data.Response.Status);
            Console.WriteLine(data.Response.Message);
            Console.WriteLine(data.Response.City);
            Console.WriteLine(data.Response.Continent);
            Console.WriteLine(data.Response.ContinentCode);
            Console.WriteLine(data.Response.Country);
            Console.WriteLine(data.Response.CountryCode);
            Console.WriteLine(data.Response.Currency);
            Console.WriteLine(data.Response.District);
            Console.WriteLine(data.Response.Latitude);
            Console.WriteLine(data.Response.Longitude);
            Console.WriteLine(data.Response.Region);
            Console.WriteLine(data.Response.RegionName);
            Console.WriteLine(data.Response.TimeZone);
            Console.WriteLine(data.Response.Zip);

            Console.WriteLine(data.RemainingRequests);
            Console.WriteLine(data.LimitExpirationInSeconds);

            Console.ReadKey();
        }
    }
}