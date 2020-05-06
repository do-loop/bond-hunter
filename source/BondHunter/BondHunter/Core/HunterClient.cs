namespace BondHunter.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using Extensions;
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

        public GetDataListQuery GetData(IEnumerable<string> queries) => GetData(queries.ToArray());

        public GetDataListQuery GetData(params string[] queries)
        {
            if (queries.IsEmpty() || queries.Length > 100)
                throw new ArgumentException(nameof(queries));

            return new GetDataListQuery(_client, queries);
        }
    }
}