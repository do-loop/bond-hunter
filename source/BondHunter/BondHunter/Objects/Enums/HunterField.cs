namespace BondHunter.Objects.Enums
{
    using System.Runtime.Serialization;

    public enum HunterField
    {
        [EnumMember(Value = "status")]
        Status,

        [EnumMember(Value = "message")]
        Message,

        [EnumMember(Value = "continent")]
        Continent,

        [EnumMember(Value = "continentCode")]
        ContinentCode,

        [EnumMember(Value = "country")]
        Country,

        [EnumMember(Value = "countryCode")]
        CountryCode,

        [EnumMember(Value = "region")]
        Region,

        [EnumMember(Value = "regionName")]
        RegionName,

        [EnumMember(Value = "city")]
        City,

        [EnumMember(Value = "district")]
        District,

        [EnumMember(Value = "zip")]
        Zip,

        [EnumMember(Value = "lat")]
        Latitude,

        [EnumMember(Value = "lon")]
        Longitude,

        [EnumMember(Value = "timezone")]
        TimeZone,

        [EnumMember(Value = "currency")]
        Currency
    }
}