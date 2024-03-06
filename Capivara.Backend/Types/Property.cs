namespace Capivara.Backend.Types;

public class Property(byte[] buffer, int size, int start, KeyValuePair<string, Type> metadata)
{
    public byte[] Buffer { get; init; } = buffer;
    public int Size { get; set; } = size;
    public int Start { get; set; } = start;
    public KeyValuePair<string, Type> Metadata { get; set; }  = metadata;
};