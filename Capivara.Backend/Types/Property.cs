namespace Rinha2024.VirtualDb.Types;

public readonly record struct Property(byte[] Buffer, Type Type, uint Size);