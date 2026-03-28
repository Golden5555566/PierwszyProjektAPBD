namespace Projekt.Domain;

public abstract class User
{
    protected User(string fullName)
    {
        Id = EntityIdGenerator.NextUserId();
        FullName = fullName;
    }

    public int Id { get; }
    public string FullName { get; }
    public abstract UserType UserType { get; }

    public override string ToString()
    {
        return $"{Id}. {FullName} ({UserType})";
    }
}
