using Projekt.Domain;
using Projekt.Services;

namespace Projekt.App;

public class DemoRunner
{
    public void Run()
    {
        var sampleData = SampleDataSeeder.Create();
        var equipment = sampleData.Equipment;
        var users = sampleData.Users;

        var rentalService = new RentalService();
        var reportService = new ReportService();
        var today = new DateTime(2026, 3, 28);

        Console.WriteLine("=== RAPORT POCZATKOWY ===");
        Console.WriteLine(reportService.BuildEquipmentReport(equipment));
        Console.WriteLine(reportService.BuildUsersReport(users));

        Console.WriteLine("=== WYPOZYCZENIA ===");
        PrintResult(rentalService.RentEquipment(sampleData.Laptop, sampleData.Student, today));
        PrintResult(rentalService.RentEquipment(sampleData.Projector, sampleData.Employee, today));
        PrintResult(rentalService.RentEquipment(sampleData.Laptop, sampleData.Employee, today));

        Console.WriteLine();
        Console.WriteLine(reportService.BuildActiveRentalsReport(rentalService.Rentals));

        Console.WriteLine("=== ZWROT ===");
        PrintResult(rentalService.ReturnEquipment(sampleData.Laptop, today.AddDays(3)));

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
