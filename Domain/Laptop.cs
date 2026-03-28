namespace Projekt.Domain;

public class Laptop : Equipment
{
    public Laptop(string name, string processor) : base(name)
    {
        Processor = processor;
    }

    public string Processor { get; }

    public override string ToString()
    {
        return base.ToString() + $" - procesor: {Processor}";
    }
}
