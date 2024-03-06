namespace Capivara.Backend;

public class Constants
{
    public static string StorageFolder { get; } = Environment.GetEnvironmentVariable("storage_folder") ?? "./data"; 
}