using Rinha2024.VirtualDb.Models;
using Rinha2024.VirtualDb.Storage.Buffer;
using Rinha2024.VirtualDb.Storage.Utils;
using Fs = System.IO.File;

namespace Rinha2024.VirtualDb.Storage.File;

public class DocumentFs
{
    public void CreateMetadataFile(Document document, string schema, string docName)
    {
        var columns = document.PropertiesBuffer;
        var metadata = new byte[document.MetadataSize];
        var position = 0;
        foreach (var column in columns)
        {
            var (name, info) = column;
            metadata[position] = info.Type.GetTypeCode();
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
        foreach (var pair in document.PropertiesBuffer)
        {
            var (_, prop) = pair;
            buffer.Write(prop.Buffer, ref position);
        }
        var path = Path.Join(Constants.StorageFolder, schema, docName);
        VerifyDocumentDirectory(path);
        path = Path.Join(path, "content.capv");
        using var stream = Fs.Create(path);
        stream.Write(buffer);
    }
    

    private static void VerifyDocumentDirectory(string path)
    {
        if (Directory.Exists(path)) return;
        Directory.CreateDirectory(path);
    }
}