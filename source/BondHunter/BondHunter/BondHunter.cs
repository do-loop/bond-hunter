namespace BondHunter
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Core;
    using Queries;

    public interface IHunterClient
    {
        GetDataQuery GetData(string query);
    }

    public static class HunterClientFactory
    {
        public static IHunterClient Create() => new HunterClient(ClientLazy.Value);

        public static IHunterClient Create(HttpClient client) => new HunterClient(client);

        private static readonly Lazy<HttpClient> ClientLazy = new Lazy<HttpClient>(CreateClient);

        private static HttpClient CreateClient()
        {
            var client = new HttpClient
            {
                Timeout = TimeSpan.FromMinutes(1)
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.ConnectionClose = true;

            return client;
        }
    }
}