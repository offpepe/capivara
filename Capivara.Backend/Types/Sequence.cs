using Rinha2024.VirtualDb.Interfaces.Types;

namespace Rinha2024.VirtualDb.Types;

public readonly struct Sequence : ISequence
{
    public Guid Id { get; init; }
    public uint Min { get; init; }
    public uint Max { get; init; }
    public uint Actual { get; init; }
    public uint Step { get; init; }
    public Sequence Next => this with {Actual = Actual + Step};
    public Sequence Last => this with {Actual = Actual - Step};
}

public readonly struct ShortSequence : ISequence
{
    public Guid Id { get; init; }
    public ushort Min { get; init; }
    public ushort Max { get; init; }
    public ushort Actual { get; init; }
    public ushort Step { get; init; }
    public ShortSequence Next => this with {Actual = (ushort) (Actual + Step)};
    public ShortSequence Last => this with {Actual = (ushort) (Actual - Step)};
}

public readonly struct LongSequence : ISequence
{
    public Guid Id { get; init; }
    public ulong Min { get; init; }
    public ulong Max { get; init; }
    public ulong Actual { get; init; }
    public ulong Step { get; init; }
    public LongSequence Next => this with {Actual = Actual + Step};
    public LongSequence Last => this with {Actual = Actual - Step};
}