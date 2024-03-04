namespace Rinha2024.VirtualDb.Types;

public readonly struct Sequency
{
    public Guid Id { get; init; }
    public uint Min { get; init; }
    public uint Max { get; init; }
    public uint Actual { get; init; }
    public uint Step { get; init; }
    public Sequency Next => this with {Actual = Actual + Step};
    public Sequency Last => this with {Actual = Actual - Step};
}

public readonly struct ShortSequency
{
    public Guid Id { get; init; }
    public ushort Min { get; init; }
    public ushort Max { get; init; }
    public ushort Actual { get; init; }
    public ushort Step { get; init; }
    public ShortSequency Next => this with {Actual = (ushort) (Actual + Step)};
    public ShortSequency Last => this with {Actual = (ushort) (Actual - Step)};
}

public readonly struct LongSequency
{
    public Guid Id { get; init; }
    public ulong Min { get; init; }
    public ulong Max { get; init; }
    public ulong Actual { get; init; }
    public ulong Step { get; init; }
    public LongSequency Next => this with {Actual = Actual + Step};
    public LongSequency Last => this with {Actual = Actual - Step};
}