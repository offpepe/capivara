namespace Rinha2024.VirtualDb;

public class Constants
{
    public static string StorageFolder { get; } = Environment.GetEnvironmentVariable("storage_folder") ?? "./data"; 
}