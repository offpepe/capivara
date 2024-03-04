using Rinha2024.VirtualDb.Interfaces.Types;
using Rinha2024.VirtualDb.Types;

namespace Rinha2024.VirtualDb.Models;

public class Document(Serial id, Property[] properties)
{
    public ISerial Id { get; init; } = id;
    public Property[] Properties { get; set; } = properties;
    public uint DocumentSize { get; set; }
    public uint MetadataSize { get; set; }
}
