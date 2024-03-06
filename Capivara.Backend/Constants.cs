namespace Capivara.Backend;

public class Constants
{
    public static readonly string StorageFolder = Environment.GetEnvironmentVariable("storage_folder") ?? "./data";
    public static readonly int DefaultFolderCapacity = int.TryParse(Environment.GetEnvironmentVariable("default_folder_capacity"), out var definedCapacity)
            ? definedCapacity
            : 100;
}