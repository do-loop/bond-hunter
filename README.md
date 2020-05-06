# bond-hunter
Simple library for fetching geolocation data by IP address

### See More

* https://ip-api.com/docs (JSON only supported)
* [NuGet Package](https://www.nuget.org/packages/BondHunter/)

### Usage

```csharp

var client = HunterClientFactory.Create();

var data = await client.GetData("46.174.55.174")
    .Language(HunterLanguage.Russian) // optional, default: english
    .Fields(HunterField.CountryCode)  // optional, default: returns all
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

```
