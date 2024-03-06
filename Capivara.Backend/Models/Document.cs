using Capivara.Backend.Interfaces.Types;
using Capivara.Backend.Types;

namespace Capivara.Backend.Models;

public class Document(Serial id, Property[] properties, int documentsize, int metadataSize)
{
    public ISerial Id { get; init; } = id;
    public Property[] Properties { get; set; } = properties;
    public int DocumentSize { get; set; } = documentsize;
    public int MetadataSize { get; set; } = metadataSize;
}
