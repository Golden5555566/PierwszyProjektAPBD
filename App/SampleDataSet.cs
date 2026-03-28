using Projekt.Domain;

namespace Projekt.App;

public class SampleDataSet
{
    public List<Equipment> Equipment { get; set; } = new List<Equipment>();

    public List<User> Users { get; set; } = new List<User>();

    public Student Student { get; set; } = null!;

    public Student StudentTwo { get; set; } = null!;

    public Employee Employee { get; set; } = null!;

    public Laptop Laptop { get; set; } = null!;

    public Laptop LaptopTwo { get; set; } = null!;

    public Projector Projector { get; set; } = null!;

    public Projector ProjectorTwo { get; set; } = null!;

    public Camera Camera { get; set; } = null!;
}
