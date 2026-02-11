namespace Interview.Domain.Entities;

public sealed class Candidate
{
    public System.Guid Id { get; init; }
    public string Name { get; init; }

    public Candidate(System.Guid id, string name)
    {
        Id = id;
        Name = name ?? throw new System.ArgumentNullException(nameof(name));
    }
}
