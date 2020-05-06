namespace BondHunter.Core.Builders
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Extensions;

    internal sealed class UrlBuilder
    {
        private readonly string _baseUrl;
        private readonly List<string> _sections = new List<string>();
        private readonly Dictionary<string, object> _parameters = new Dictionary<string, object>();

        public UrlBuilder(string baseUrl)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new ArgumentException(nameof(baseUrl));

            if (!Uri.TryCreate(baseUrl, UriKind.Absolute, out _))
                throw new ArgumentException(nameof(baseUrl));

            _baseUrl = baseUrl;
        }

        public UrlBuilder AppendSection(string section)
        {
            if (string.IsNullOrWhiteSpace(section))
                throw new ArgumentException(nameof(section));

            _sections.Add(section);

            return this;
        }

        public UrlBuilder AppendParameters(IReadOnlyDictionary<string, string> parameters)
        {
            if (parameters.IsEmpty())
                return this;

            foreach (var (key, value) in parameters)
                _parameters[key] = value;

            return this;
        }

        public Uri Build()
        {
            var builder = new StringBuilder(_baseUrl);

            if (_sections.IsNotEmpty())
            {
                var sections = string.Join("/", _sections);

                if (!_baseUrl.EndsWith("/"))
                    builder.Append("/");

                builder.Append(sections);
            }

            if (_parameters.IsNotEmpty())
            {
                var parameters = _parameters.Select(CreateParameter);

                builder
                    .Append("?")
                    .Append(string.Join("&", parameters));
            }

            if (Uri.TryCreate(builder.ToString(), UriKind.Absolute, out var uri))
                return uri;

            throw new InvalidOperationException("Не удалось создать Url.");
        }

        private static string CreateParameter(KeyValuePair<string, object> pair)
        {
            if (pair.Value is string @string)
                return CreateParameter(pair.Key, @string);

            var items = ((IEnumerable) pair.Value).Cast<object>();
            var parts = items.Select(item => CreateParameter(pair.Key, item.ToString()));

            return string.Join("&", parts);
        }

        private static string CreateParameter(string key, string value)
        {
            return new StringBuilder()
                .Append(key)
                .Append("=")
                .Append(value)
                .ToString();
        }
    }
}