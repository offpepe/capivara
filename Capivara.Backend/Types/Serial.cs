using Rinha2024.VirtualDb.Interfaces.Types;

namespace Rinha2024.VirtualDb.Types;

public readonly record struct Serial(uint Value, Sequence Sequence, Guid Hash) : ISerial;
public readonly record struct ShortSerial(ushort Value, ShortSequence Sequence, Guid Hash) : ISerial;
public readonly record struct LongSerial(ulong Value, LongSequence Sequence, Guid Hash) : ISerial;
