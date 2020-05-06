namespace BondHunter.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Core.Extensions;
    using Core.Helpers;

    public abstract class Query<TResponse>
    {
        protected Dictionary<string, string> Parameters = new Dictionary<string, string>();

        public TResponse Execute() => ExecuteAsync().WaitTask();

        public Task<TResponse> ExecuteAsync() => ExceptionHelper.WrapException(ExecuteInternalAsync);

        protected abstract Task<TResponse> ExecuteInternalAsync();

        protected void AppendParameter(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException(nameof(key));

            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException(nameof(value));

            Parameters[key] = value;
        }

        protected void AppendParameter(string key, IEnumerable<string> values)
        {
            _ = values ?? throw new ArgumentException(nameof(values));

            AppendParameter(key, Join(values));
        }

        protected void AppendParameter<T>(string key, T[] values) where T : struct
        {
            _ = values ?? throw new ArgumentException(nameof(values));

            var type = values.GetType()
                .GetElementType();

            if (type?.IsEnum == true)
            {
                AppendParameter(key, values.Select(GetEnumValue));
                return;
            }

            AppendParameter(key, Join(values));
        }

        protected void AppendParameter<T>(string key, T value) where T : struct
        {
            if (value.GetType().IsEnum)
            {
                var @string = GetEnumValue(value);
                if (string.IsNullOrWhiteSpace(@string))
                    throw new InvalidOperationException("Не удалось получить значение перечисления.");

                AppendParameter(key, @string);
                return;
            }

            AppendParameter(key, value.ToString());
        }

        protected static string GetEnumValue<T>(T value) where T : struct
        {
            var type = value.GetType();
            if (type.IsEnum == false)
                return default;

            var @string = value.GetEnumMemberValue();

            return string.IsNullOrWhiteSpace(@string)
                ? Convert.ToInt32(value).ToString()
                : @string;
        }

        protected string Join<T>(IEnumerable<T> values, string separator = ",") => string.Join(separator, values);
    }
}