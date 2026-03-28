using Projekt.Domain;
using Projekt.Services;

namespace Projekt.App;

public class DemoRunner
{
    public void Run()
    {
        var equipment = new List<Equipment>
        {
            new Laptop("Dell Latitude", "Intel i5"),
            new Projector("Epson X1", 3200),
            new Camera("Sony Handycam", true)
        };

        var users = new List<User>
        {
            new Student("Anna Kowalska", "s12345"),
            new Employee("Jan Nowak", "IT")
        };

        var rentalService = new RentalService();
        var reportService = new ReportService();
        var today = new DateTime(2026, 3, 28);

        Console.WriteLine("=== RAPORT POCZATKOWY ===");
        Console.WriteLine(reportService.BuildEquipmentReport(equipment));
        Console.WriteLine(reportService.BuildUsersReport(users));

        Console.WriteLine("=== WYPOZYCZENIA ===");
        PrintResult(rentalService.RentEquipment(equipment[0], users[0], today));
        PrintResult(rentalService.RentEquipment(equipment[1], users[1], today));
        PrintResult(rentalService.RentEquipment(equipment[0], users[1], today));

        Console.WriteLine();
        Console.WriteLine(reportService.BuildActiveRentalsReport(rentalService.Rentals));

        Console.WriteLine("=== ZWROT ===");
        PrintResult(rentalService.ReturnEquipment(equipment[0], today.AddDays(3)));

        Console.WriteLine();
        Console.WriteLine(reportService.BuildEquipmentReport(equipment));
        Console.WriteLine(reportService.BuildActiveRentalsReport(rentalService.Rentals));
    }

    private static void PrintResult(OperationResult result)
    {
        var prefix = result.Success ? "[OK]" : "[BLAD]";
        Console.WriteLine($"{prefix} {result.Message}");
    }
}
