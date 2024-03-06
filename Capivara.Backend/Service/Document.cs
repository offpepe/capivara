using System.Text;
using Capivara.Backend.Storage.Buffer;
using Capivara.Backend.Storage.File;
using Capivara.Backend.Types;

namespace Capivara.Backend.Service;

public class Document
{
    public Models.Document CreateNewDocument(object[] properties, string[] names, string schema, string docName)
    {
        var docProps = new Property[properties.Length];
        var position = 0;
        var documentSize = 0;
        var metadataSize = 0;
        for (var i = 0; i < properties.Length; i++)
        {
            docProps[i] = properties[i] switch
            {
                bool        boolVal        =>    ConvertIntoProperty(typeof(bool),   sizeof(bool), BitConverter.GetBytes(boolVal), ref names[i], ref position, ref documentSize, ref metadataSize),
                int         intVal         =>    ConvertIntoProperty(typeof(int),    sizeof(int), BitConverter.GetBytes(intVal), ref names[i], ref position, ref documentSize, ref metadataSize),
                long        longVal        =>    ConvertIntoProperty(typeof(long),   sizeof(long), BitConverter.GetBytes(longVal), ref names[i], ref position, ref documentSize, ref metadataSize),
                short       shortVal       =>    ConvertIntoProperty(typeof(short),  sizeof(short), BitConverter.GetBytes(shortVal), ref names[i], ref position, ref documentSize, ref metadataSize),
                float       floatVal       =>    ConvertIntoProperty(typeof(float),  sizeof(float), BitConverter.GetBytes(floatVal), ref names[i], ref position, ref documentSize, ref metadataSize),
                string      stringVal      =>    ConvertIntoProperty(typeof(string), stringVal.Length, Encoding.UTF8.GetBytes(stringVal), ref names[i], ref position, ref documentSize, ref metadataSize),
                double      doubleVal      =>    ConvertIntoProperty(typeof(double), sizeof(double),BitConverter.GetBytes(doubleVal), ref names[i], ref position, ref documentSize, ref metadataSize),
                decimal     decimalVal     =>    ConvertIntoProperty(typeof(decimal),sizeof(decimal),decimalVal.ToByteArray(), ref names[i], ref position, ref documentSize, ref metadataSize),
                DateTime    dateVal        =>    ConvertIntoProperty(typeof(long),   sizeof(long), BitConverter.GetBytes(dateVal.Ticks), ref names[i], ref position, ref documentSize, ref metadataSize),
                DateOnly    dateOnlyVal    =>    ConvertIntoProperty(typeof(long),   sizeof(long), BitConverter.GetBytes(dateOnlyVal.ToDateTime(TimeOnly.MaxValue).Ticks), ref names[i], ref position, ref documentSize, ref metadataSize),
                TimeSpan    timeSpanVal    =>    ConvertIntoProperty(typeof(long),   sizeof(long), BitConverter.GetBytes(timeSpanVal.Ticks), ref names[i], ref position, ref documentSize, ref metadataSize),
                _ => throw new InvalidOperationException($"Invalid type on {i} property")
            };
        }

        // TODO change serial initialization to consumition from folder.
        var serial = new Serial();
        var document = new Models.Document(serial, docProps, documentSize, metadataSize);
        return document;
    }

    private static Property ConvertIntoProperty(Type type, int size, byte[] buffer, ref string name, ref int position, ref int documentSize, ref int metadataSize)
    {
        var property = new Property(
            buffer,
            size,
            position,
            new KeyValuePair<string, Type>(name, type)
        );
        position += size;
        documentSize += size;
        metadataSize += name.Length + 1;
        return property;
    }


}

