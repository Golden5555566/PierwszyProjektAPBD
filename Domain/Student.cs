namespace Projekt.Domain;

public class Student : User
{
    public Student(string fullName, string albumNumber) : base(fullName)
    {
        AlbumNumber = albumNumber;
    }

    public string AlbumNumber { get; }
    public override UserType UserType => UserType.Student;

    public override string ToString()
    {
        return base.ToString() + $" - nr albumu: {AlbumNumber}";
    }
}
