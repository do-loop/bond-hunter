namespace BondHunter.Core
{
    using System;
    using System.Net.Http;
    using Queries;

    internal sealed class HunterClient : IHunterClient
    {
        private readonly HttpClient _client;

        public HunterClient(HttpClient client)
        {
            _client = client;
        }

        public GetDataQuery GetData(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException(nameof(query));

            return new GetDataQuery(_client, query);
        }
    }
}