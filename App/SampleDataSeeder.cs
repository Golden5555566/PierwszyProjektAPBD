using Projekt.Domain;

namespace Projekt.App;

public static class SampleDataSeeder
{
    public static SampleDataSet Create()
    {
        var student = new Student("Anna Kowalska", "s12345");
        var studentTwo = new Student("Maria Lis", "s54321");
        var employee = new Employee("Jan Nowak", "IT");

        var laptop = new Laptop("Dell Latitude", "Intel i5");
        var laptopTwo = new Laptop("Lenovo ThinkPad", "Intel i7");
        var projector = new Projector("Epson X1", 3200);
        var projectorTwo = new Projector("BenQ MX560", 4000);
        var camera = new Camera("Sony Handycam", true);

        var users = new List<User> { student, studentTwo, employee };
        var equipment = new List<Equipment> { laptop, laptopTwo, projector, projectorTwo, camera };

        return new SampleDataSet
        {
            Equipment = equipment,
            Users = users,
            Student = student,
            StudentTwo = studentTwo,
            Employee = employee,
            Laptop = laptop,
            LaptopTwo = laptopTwo,
            Projector = projector,
            ProjectorTwo = projectorTwo,
            Camera = camera
        };
    }
}
