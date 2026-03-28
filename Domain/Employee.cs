namespace Projekt.Domain;

public class Employee : User
{
    public Employee(string fullName, string department) : base(fullName)
    {
        Department = department;
    }

    public string Department { get; }
    public override UserType UserType => UserType.Employee;

    public override string ToString()
    {
        return base.ToString() + $" - dzial: {Department}";
    }
}
