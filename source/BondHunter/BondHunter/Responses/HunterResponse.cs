namespace BondHunter.Responses
{
    using Newtonsoft.Json;
    using Objects.Enums;

    public sealed class HunterResponse
    {
        [JsonProperty("status")]
        public HunterStatus Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("continent")]
        public string Continent { get; set; }

        [JsonProperty("continentCode")]
        public string ContinentCode { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("regionName")]
        public string RegionName { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("district")]
        public string District { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("lat")]
        public float? Latitude { get; set; }

        [JsonProperty("lon")]
        public float? Longitude { get; set; }

        [JsonProperty("timezone")]
        public string TimeZone { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }
    }
}