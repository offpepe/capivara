namespace Rinha2024.VirtualDb.Types;

public readonly record struct Serial(uint Value, Sequency Sequency);
public readonly record struct ShortSerial(ushort Value, ShortSequency Sequency);
public readonly record struct LongSerial(ulong Value, LongSequency Sequency);
