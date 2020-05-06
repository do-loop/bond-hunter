namespace BondHunter.Extensions
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using BondHunter;
    using Core;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        private static readonly string ClientName = $"{nameof(ServiceCollectionExtensions)}__{nameof(HunterClient)}";

        public static IServiceCollection AddHunter(this IServiceCollection services, Action<HttpClient> action)
        {
            void Configure(HttpClient client)
            {
                action(client);

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }

            if (action == null)
                throw new ArgumentNullException(nameof(action));

            services.AddHttpClient(ClientName, Configure);
            services.AddScoped(x =>
            {
                var clientFactory = x.GetService<IHttpClientFactory>();
                var client = clientFactory.CreateClient(ClientName);

                return HunterClientFactory.Create(client);
            });

            return services;
        }

        public static IServiceCollection AddHunter(this IServiceCollection services)
        {
            static void Configure(HttpClient client)
            {
                client.Timeout = TimeSpan.FromMinutes(1);
                client.DefaultRequestHeaders.ConnectionClose = true;
            }

            return services.AddHunter(Configure);
        }
    }
}