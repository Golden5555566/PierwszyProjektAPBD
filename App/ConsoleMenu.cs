using Projekt.Domain;
using Projekt.Services;

namespace Projekt.App;

public class ConsoleMenu
{
    private readonly List<Equipment> _equipment;
    private readonly List<User> _users;
    private readonly RentalService _rentalService;
    private readonly ReportService _reportService;
    private readonly FilteredReportService _filteredReportService;

    public ConsoleMenu(
        List<Equipment> equipment,
        List<User> users,
        RentalService rentalService,
        ReportService reportService,
        FilteredReportService filteredReportService)
    {
        _equipment = equipment;
        _users = users;
        _rentalService = rentalService;
        _reportService = reportService;
        _filteredReportService = filteredReportService;
    }

    public void Run()
    {
        while (true)
        {
            PrintHeader("MENU");
            Console.WriteLine("1. Wyswietl caly sprzet");
            Console.WriteLine("2. Wyswietl sprzet dostepny");
            Console.WriteLine("3. Wypozycz sprzet");
            Console.WriteLine("4. Zwroc sprzet");
            Console.WriteLine("5. Wyswietl aktywne wypozyczenia uzytkownika");
            Console.WriteLine("6. Wyswietl raport koncowy");
            Console.WriteLine("7. Wyswietl raport sprzetu uszkodzonego");
            Console.WriteLine("8. Wyswietl raport przeterminowanych wypozyczen");
            Console.WriteLine("0. Zakoncz");
            Console.Write("Wybierz opcje: ");

            var choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine(_reportService.BuildEquipmentReport(_equipment));
                    break;
                case "2":
                    Console.WriteLine(_filteredReportService.BuildAvailableEquipmentReport(_equipment));
                    break;
                case "3":
                    RentEquipment();
                    break;
                case "4":
                    ReturnEquipment();
                    break;
                case "5":
                    ShowUserRentals();
                    break;
                case "6":
                    ShowFinalReport();
                    break;
                case "7":
                    Console.WriteLine(_filteredReportService.BuildBrokenEquipmentReport(_equipment));
                    break;
                case "8":
                    Console.WriteLine(_filteredReportService.BuildOverdueRentalsReport(_rentalService.Rentals, DateTime.Today));
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Nieznana opcja.");
                    break;
            }
        }
    }

    private void RentEquipment()
    {
        Console.WriteLine(_reportService.BuildEquipmentReport(_equipment));
        Console.WriteLine(_reportService.BuildUsersReport(_users));

        Console.Write("Podaj id sprzetu: ");
        var equipmentId = ReadInt();
        Console.Write("Podaj id uzytkownika: ");
        var userId = ReadInt();

        var equipment = _equipment.FirstOrDefault(item => item.Id == equipmentId);
        var user = _users.FirstOrDefault(item => item.Id == userId);

        if (equipment is null || user is null)
        {
            Console.WriteLine("[BLAD] Nie znaleziono sprzetu lub uzytkownika.");
            Console.WriteLine();
            return;
        }

        PrintResult(_rentalService.RentEquipment(equipment, user, DateTime.Today));
    }

    private void ReturnEquipment()
    {
        var activeRentals = _rentalService.Rentals.Where(item => item.IsActive).ToList();
        Console.WriteLine(_reportService.BuildActiveRentalsReport(activeRentals));

        Console.Write("Podaj id sprzetu do zwrotu: ");
        var equipmentId = ReadInt();

        var equipment = _equipment.FirstOrDefault(item => item.Id == equipmentId);
        if (equipment is null)
        {
            Console.WriteLine("[BLAD] Nie znaleziono sprzetu.");
            Console.WriteLine();
            return;
        }

        PrintResult(_rentalService.ReturnEquipment(equipment, DateTime.Today));
    }

    private void ShowUserRentals()
    {
        Console.WriteLine(_reportService.BuildUsersReport(_users));
        Console.Write("Podaj id uzytkownika: ");
        var userId = ReadInt();

        var rentals = _rentalService.Rentals
            .Where(item => item.IsActive && item.User.Id == userId)
            .ToList();

        Console.WriteLine(_reportService.BuildActiveRentalsReport(rentals));
    }

    private void ShowFinalReport()
    {
        Console.WriteLine(_reportService.BuildEquipmentReport(_equipment));
        Console.WriteLine(_reportService.BuildUsersReport(_users));
        Console.WriteLine(_reportService.BuildActiveRentalsReport(_rentalService.Rentals));
    }

    private static int ReadInt()
    {
        while (true)
        {
            var input = Console.ReadLine();
            if (int.TryParse(input, out var value))
            {
                return value;
            }

            Console.Write("Podaj poprawna liczbe: ");
        }
    }

    private static void PrintHeader(string title)
    {
        Console.WriteLine(title);
        Console.WriteLine(new string('-', title.Length));
    }

    private static void PrintResult(OperationResult result)
    {
        var prefix = result.Success ? "[OK]" : "[BLAD]";
        Console.WriteLine($"{prefix} {result.Message}");
        Console.WriteLine();
    }
}
