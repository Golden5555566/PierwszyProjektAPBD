using Projekt.Domain;

namespace Projekt.App;

public class SampleDataSet
{
    public SampleDataSet(
        List<Equipment> equipment,
        List<User> users,
        Student student,
        Student studentTwo,
        Employee employee,
        Laptop laptop,
        Laptop laptopTwo,
        Projector projector,
        Projector projectorTwo,
        Camera camera)
    {
        Equipment = equipment;
        Users = users;
        Student = student;
        StudentTwo = studentTwo;
        Employee = employee;
        Laptop = laptop;
        LaptopTwo = laptopTwo;
        Projector = projector;
        ProjectorTwo = projectorTwo;
        Camera = camera;
    }

    public List<Equipment> Equipment { get; }

    public List<User> Users { get; }

    public Student Student { get; }

    public Student StudentTwo { get; }

    public Employee Employee { get; }

    public Laptop Laptop { get; }

    public Laptop LaptopTwo { get; }

    public Projector Projector { get; }

    public Projector ProjectorTwo { get; }

    public Camera Camera { get; }
}
