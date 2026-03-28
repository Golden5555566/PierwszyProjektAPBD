using Projekt.App;
using Projekt.Services;

Console.WriteLine("1. Uruchom scenariusz demonstracyjny");
Console.WriteLine("2. Otworz menu tekstowe");
Console.Write("Wybierz opcje: ");

var choice = Console.ReadLine();

if (choice == "2")
{
    var sampleData = SampleDataSeeder.Create();
    var rentalService = new RentalService();
    var reportService = new ReportService();
    var filteredReportService = new FilteredReportService();

    var menu = new ConsoleMenu(
        sampleData.Equipment,
        sampleData.Users,
        rentalService,
        reportService,
        filteredReportService);

    menu.Run();
}
else
{
    var demoRunner = new DemoRunner();
    demoRunner.Run();
}
