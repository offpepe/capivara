namespace Rinha2024.VirtualDb.Storage.Buffer;

public static class Date
{
    public static void WriteDate(this byte[] buffer, DateTime date)
    {
        buffer.WriteNumeric(date.Ticks);
    }
    
    public static void WriteDate(this byte[] buffer, DateTime date, ref int position)
    {
        buffer.WriteNumeric(date.Ticks, ref position);
    }
    
    public static void WriteDate(this byte[] buffer, DateOnly date)
    {
        buffer.WriteNumeric(date.ToDateTime(TimeOnly.MinValue).Ticks);
    }
    
    public static void WriteDate(this byte[] buffer, DateOnly date, ref int position)
    {
        buffer.WriteNumeric(date.ToDateTime(TimeOnly.MinValue).Ticks, ref position);
    }

    public static void WriteDate(this byte[] buffer, DateTimeOffset date)
    {
        buffer.WriteNumeric(date.Ticks);
    }
    
    public static void WriteDate(this byte[] buffer, DateTimeOffset date, ref int position)
    {
        buffer.WriteNumeric(date.Ticks, ref position);
    }
}