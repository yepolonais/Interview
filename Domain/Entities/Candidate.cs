namespace Interview.Domain.Entities;

public sealed class Candidate(Guid id, string name)
{
    public Guid Id { get; init; } = id;
    public string Name { get; init; } = name ?? throw new System.ArgumentNullException(nameof(name));
}
