using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace AzureFunctionExample.Domain.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class EnvironmentKeyVault
    {
        public static T GetValue<T>(string key)
        {
            var valor = Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.Process);
            return (T)ChangeType(typeof(T), valor);
        }

        public static string GetValueString(string key)
        {
            return Environment.GetEnvironmentVariable(key, EnvironmentVariableTarget.Process);
        }

        private static object ChangeType(Type t, object value)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(t);
            return tc.ConvertFrom(value);
        }
    }
}
