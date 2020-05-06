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

    public sealed class GetDataListQuery : Query<HunterData>
    {
        private readonly HttpClient _client;

        public GetDataListQuery(HttpClient client, string[] queries) : base(queries)
        {
            _client = client ?? throw new ArgumentException(nameof(client));
        }

        protected override async Task<HunterData> ExecuteInternalAsync()
        {
            var items = Queries.Select(x => new { query = x });

            var request = JsonConvert.SerializeObject(items);
            var url = new RequestBuilder(HunterSettings.BaseUrl)
                .SetParameters(Parameters)
                .SetType("batch")
                .Build();

            var message = await _client.PostAsync(url, new StringContent(request));

            if (message.IsSuccessStatusCode == false)
                throw new HunterException($"Status Code: {message.StatusCode}.");

            var json = await message.Content.ReadAsStringAsync();

            return new HunterData
            {
                Response = JsonConvert.DeserializeObject<HunterResponse[]>(json),
                RemainingRequests = message.Headers.GetHeaderValue<int>("X-Rl"),
                LimitExpirationInSeconds = message.Headers.GetHeaderValue<int>("X-Ttl")
            };
        }

        public GetDataListQuery Language(HunterLanguage value)
        {
            AppendParameter(LanguageKey, value);
            return this;
        }

        public GetDataListQuery Fields(IEnumerable<HunterField> values)
        {
            AppendParameter(FieldsKey, values.ToArray());
            return this;
        }

        public GetDataListQuery Fields(params HunterField[] values)
        {
            AppendParameter(FieldsKey, values);
            return this;
        }
    }
}