namespace BondHunter.Core.Extensions
{
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Serialization;

    internal static class EnumExtensions
    {
        public static string GetEnumMemberValue<T>(this T value) where T : struct
        {
            var type = value.GetType();
            if (type.IsEnum == false)
                return default;

            return type.GetTypeInfo().DeclaredMembers
                .SingleOrDefault(x => x.Name == value.ToString())?
                .GetCustomAttribute<EnumMemberAttribute>(false)?
                .Value;
        }
    }
}