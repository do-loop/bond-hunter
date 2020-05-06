namespace BondHunter.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Core;
    using Core.Builders;
    using Core.Extensions;
    using Exceptions;
    using Newtonsoft.Json;
    using Objects;
    using Objects.Enums;
    using Responses;

    public sealed class GetDataQuery : Query<HunterData>
    {
        private readonly string _query;
        private readonly HttpClient _client;

        public GetDataQuery(HttpClient client, string query)
        {
            _client = client ?? throw new ArgumentException(nameof(client));

            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException(nameof(query));

            _query = query;
        }

        protected override async Task<HunterData> ExecuteInternalAsync()
        {
            var request = new RequestBuilder(HunterSettings.BaseUrl)
                .SetParameters(Parameters)
                .SetQuery(_query)
                .Build();

            var message = await _client.GetAsync(request);

            if (message.IsSuccessStatusCode == false)
                throw new HunterException($"Status Code: {message.StatusCode}.");

            var json = await message.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<HunterResponse>(json);

            return new HunterData
            {
                Response = response,
                RemainingRequests = message.Headers.GetHeaderValue<int>("X-Rl"),
                LimitExpirationInSeconds = message.Headers.GetHeaderValue<int>("X-Ttl")
            };
        }

        public GetDataQuery Language(HunterLanguage value)
        {
            AppendParameter("lang", value);
            return this;
        }

        public GetDataQuery Fields(IEnumerable<HunterField> values)
        {
            AppendParameter("fields", values.ToArray());
            return this;
        }

        public GetDataQuery Fields(params HunterField[] values)
        {
            AppendParameter("fields", values);
            return this;
        }
    }
}