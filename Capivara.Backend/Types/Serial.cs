using Capivara.Backend.Interfaces.Types;

namespace Capivara.Backend.Types;

public readonly record struct Serial(uint Value, Sequence Sequence, Guid Hash) : ISerial;
public readonly record struct ShortSerial(ushort Value, ShortSequence Sequence, Guid Hash) : ISerial;
public readonly record struct LongSerial(ulong Value, LongSequence Sequence, Guid Hash) : ISerial;
