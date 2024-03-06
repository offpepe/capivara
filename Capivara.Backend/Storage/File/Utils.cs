namespace Capivara.Backend.Storage.File;

public static class Utils
{
    public static void CreateDirectoryIfNotExists(string path)
    {
        if (Directory.Exists(path)) return;
        Directory.CreateDirectory(path);
    }
}