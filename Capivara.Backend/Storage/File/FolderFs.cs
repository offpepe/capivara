using System.Xml.Serialization;
using Capivara.Backend.Extensions;
using Capivara.Backend.Models;
using Capivara.Backend.Storage.Buffer;
using Capivara.Backend.Types;

namespace Capivara.Backend.Storage.File;

public class FolderFs
{
    public static void CreateFolderFile(string schema, string name)
    {
        var path = Path.Join(Constants.StorageFolder, schema, name);
        Utils.CreateDirectoryIfNotExists(path);
        var folder = new Folder(
            Guid.NewGuid(),
            schema,
            name);
        var buffer = new byte[12];
        var position = 0;
        buffer.WriteNumeric(folder.Min, ref position);
        buffer.WriteNumeric(folder.Max, ref position);
        buffer.WriteNumeric(folder.TotalDocuments, ref position);
        using var folderStream = Fs.Create(Path.Join(path, folder.Id.ToString()));
        folderStream.Write(buffer);
    }

    public static void UpdateMinValueFromFolder(string schema, string name, Guid guid, int minVal)
    {
        var path = Path.Join(Constants.StorageFolder, schema, name);
        if (!Directory.Exists(path)) throw new InvalidOperationException("Folder does not exists");
        path = Path.Join(path, guid.ToString());
        if (!Fs.Exists(path)) throw new InvalidOperationException("Folder does not exists");
        var folderStream = Fs.OpenWrite(path);
        var buffer = new byte[4];
        buffer.WriteNumeric(minVal);
        folderStream.Write(buffer, 0, 4);
    } 
    
    public static void UpdateMaxValueFromFolder(string schema, string name, Guid guid, int maxVal)
    {
        var path = Path.Join(Constants.StorageFolder, schema, name);
        if (!Directory.Exists(path)) throw new InvalidOperationException("Folder does not exists");
        path = Path.Join(path, guid.ToString());
        if (!Fs.Exists(path)) throw new InvalidOperationException("Folder does not exists");
        using var folderStream = Fs.OpenWrite(path);
        var buffer = new byte[4];
        buffer.WriteNumeric(maxVal);
        folderStream.Write(buffer, 4, 4);
    } 
    
    public static void UpdateTotalDocumentsFromFolder(string schema, string name, Guid guid, int totalDocuments)
    {
        var path = Path.Join(Constants.StorageFolder, schema, name);
        if (!Directory.Exists(path)) throw new InvalidOperationException("Folder does not exists");
        path = Path.Join(path, guid.ToString());
        if (!Fs.Exists(path)) throw new InvalidOperationException("Folder does not exists");
        using var folderStream = Fs.OpenWrite(path);
        var buffer = new byte[4];
        buffer.WriteNumeric(totalDocuments);
        folderStream.Write(buffer, 8, 4);
    }

    public static void WriteSerialOnFolder(string path, int start, int end)
    {
        if (!Fs.Exists(path)) throw new InvalidOperationException("Folder does not exists");
        using var folderStream = Fs.OpenWrite(path);
        var buffer = new byte[8];
        var position = 0;
        buffer.WriteNumeric(start, ref position);
        buffer.WriteNumeric(end, ref position);
        folderStream.Write(buffer);
    }

    public static Folder ReadFolder(string path, string schema, string name)
    {
        if (!Fs.Exists(path)) throw new InvalidOperationException("Folder does not exists");
        var guid = Guid.Parse(path[^41..^5]);
        var folder = new Folder(guid, schema, name);
        var folderSize = 12 + 8 * Constants.DefaultFolderCapacity;
        using var folderStream = Fs.OpenRead(path);
        var buffer = new byte[folderSize];
        _ = folderStream.Read(buffer);
        var position = 0;
        folder.Min = BitConverter.ToInt32(buffer, position);
        position += 4;
        folder.Max = BitConverter.ToInt32(buffer, position);
        position += 4;
        folder.TotalDocuments = BitConverter.ToInt32(buffer, position);
        position += 4;
        var serials = new Serial[folder.TotalDocuments];
        for (var i = 0; i < folder.TotalDocuments; i++)
        {
            var start = BitConverter.ToInt32(buffer, position);
            position += 4;
            var end  = BitConverter.ToInt32(buffer, position);
            position += 4;
            serials[i] = new Serial(0, start, end);
        }
        // TODO implement sort algorithm memory eficient
        folder.Summary = serials.Order().ToArray();
        return folder;
    }
    

    public static Dictionary<Guid, Folder> VirtualizeListOfFolders(string schema, string name)
    {
        var basePath = Path.Join(schema, name);
        var folders = Directory.GetFiles(basePath);
        var result = new Dictionary<Guid, Folder>(folders.Length);
        for (var i = 0; i < folders.Length; i++)
        {
            var folder = ReadFolder(folders[i], schema, name);
            result.Add(folder.Id, folder);
        }
        return result;
    }

  
}