namespace BondHunter.Core.Extensions
{
    using System.ComponentModel;
    using System.Linq;
    using System.Net.Http.Headers;

    internal static class HttpHeaderExtensions
    {
        public static T GetHeaderValue<T>(this HttpResponseHeaders headers, string name)
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));

            var values = headers.GetValues(name)
                .Select(x => converter.ConvertFromInvariantString(x))
                .Cast<T>();

            return values.FirstOrDefault();
        }
    }
}