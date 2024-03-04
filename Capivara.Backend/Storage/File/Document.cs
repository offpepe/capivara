using System.Threading.Tasks.Dataflow;
using Rinha2024.VirtualDb.Models;
using Rinha2024.VirtualDb.Storage.Buffer;
using Rinha2024.VirtualDb.Storage.Utils;
using Rinha2024.VirtualDb.Types;
using Fs = System.IO.File;

namespace Rinha2024.VirtualDb.Storage.File;

public class DocumentFs
{
    public void CreateMetadataFile(Document document, string schema, string docName)
    {
        var properties = document.Properties;
        var metadata = new byte[document.MetadataSize];
        var position = 0;
        foreach (var prop in properties)
        {
            var (name, type) = prop.Metadata;
            metadata[position] = type.GetTypeCode();
            position++;
            metadata.WriteNumeric(name.Length, ref position);
            metadata.WriteText(name, ref position);
        }
        var path = Path.Join(Constants.StorageFolder, schema, docName);
        VerifyDocumentDirectory(path);
        path = Path.Join(path, "meta.capv");
        using var stream = Fs.Create(path);
        stream.Write(metadata);
    }

    public void CreateDocumentFile(Document document, string schema, string docName)
    {
        var buffer = new byte[document.DocumentSize];
        var position = 0;
        foreach (var prop in document.Properties)
        {
            prop.Start = position;
            buffer.Write(prop.Buffer, ref position);
        }
        var path = Path.Join(Constants.StorageFolder, schema, docName);
        VerifyDocumentDirectory(path);
        path = Path.Join(path, "content.capv");
        using var stream = Fs.Create(path);
        stream.Write(buffer);
    }

    public void UpdateMetadata(Property property, string schema, string docName)
    {
        var (name, type) = property.Metadata;
        var buffer = new byte[name.Length + 1];
        buffer[0] = type.GetTypeCode();
        var pos = 1;
        buffer.WriteText(name, ref pos);
        var path = Path.Join(Constants.StorageFolder, schema, docName, "meta.capv");
        using var stream = Fs.Open(path, FileMode.Append);
        stream.Write(buffer);
    }

    public void UpdateDocumentProperty(Property property, string schema, string docName)
    {
        var path = Path.Join(Constants.StorageFolder, schema, docName, "content.capv");
        using var stream = Fs.OpenWrite(path);
        stream.Write(property.Buffer, property.Start, property.Size);
    }

    public void DeleteDocument(string schema, string docName)
    {
        var basePath = Path.Join(Constants.StorageFolder, schema, docName);
        Fs.Delete(Path.Join(basePath, "content.capv"));
        Fs.Delete(Path.Join(basePath, "meta.capv"));
    }
    

    private static void VerifyDocumentDirectory(string path)
    {
        if (Directory.Exists(path)) return;
        Directory.CreateDirectory(path);
    }
}