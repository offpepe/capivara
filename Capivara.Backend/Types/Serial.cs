using Capivara.Backend.Interfaces.Types;

namespace Capivara.Backend.Types;

public readonly record struct Serial(uint Value, int Start, int End) : ISerial;
public readonly record struct ShortSerial(ushort Value, int Start, int End) : ISerial;
public readonly record struct LongSerial(ulong Value, int Start, int End) : ISerial;
