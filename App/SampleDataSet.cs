using Projekt.Domain;

namespace Projekt.App;

public class SampleDataSet
{
    public required List<Equipment> Equipment { get; init; }

    public required List<User> Users { get; init; }

    public required Student Student { get; init; }

    public required Student StudentTwo { get; init; }

    public required Employee Employee { get; init; }

    public required Laptop Laptop { get; init; }

    public required Laptop LaptopTwo { get; init; }

    public required Projector Projector { get; init; }

    public required Projector ProjectorTwo { get; init; }

    public required Camera Camera { get; init; }
}
