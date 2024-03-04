using Rinha2024.VirtualDb.Interfaces.Types;
using Rinha2024.VirtualDb.Types;

namespace Rinha2024.VirtualDb.Models;

public class Document(Serial id, KeyValuePair<string, Property>[] properties)
{
    public ISerial Id { get; init; } = id;
    public KeyValuePair<string, Property>[] PropertiesBuffer { get; set; } = properties; 
    public Guid[] Relations { get; init; } = [];
}