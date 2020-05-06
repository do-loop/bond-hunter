namespace BondHunter.Core.Builders
{
    using System;
    using System.Collections.Generic;

    internal sealed class RequestBuilder
    {
        private readonly UrlBuilder _urlBuilder;

        public RequestBuilder(string baseUrl)
        {
            _urlBuilder = new UrlBuilder(baseUrl);
        }

        public RequestBuilder SetQuery(string value)
        {
            _urlBuilder.AppendSection(value);

            return this;
        }

        public RequestBuilder SetParameters(Dictionary<string, string> parameters)
        {
            _urlBuilder.AppendParameters(parameters);

            return this;
        }

        public Uri Build() => _urlBuilder.Build();
    }
}