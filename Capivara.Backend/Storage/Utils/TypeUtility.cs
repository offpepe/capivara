
using System.Reflection;

namespace Rinha2024.VirtualDb.Storage.Utils;
public static class TypeUtility
{
    
    public static byte GetTypeCode(this Type t) => t switch
    {
        not null when t == typeof(bool) => (byte)TypeAlias.Boolean,
        not null when t == typeof(int) => (byte)TypeAlias.Int32,
        not null when t == typeof(long) => (byte)TypeAlias.Int64,
        not null when t == typeof(double) => (byte)TypeAlias.Double,
        not null when t == typeof(float) => (byte)TypeAlias.Float,
        not null when t == typeof(decimal) => (byte)TypeAlias.Decimal,
        not null when t == typeof(string) => (byte)TypeAlias.String,
        not null when t == typeof(DateOnly) => (byte)TypeAlias.DateOnly,
        not null when t == typeof(DateTime) => (byte)TypeAlias.DateTime,
        not null when t == typeof(TimeSpan) => (byte)TypeAlias.Timespan,
        _ => throw new InvalidCastException("Cannot write unsupported type")
    };
}