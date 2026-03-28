using System.Text;
using Projekt.Domain;

namespace Projekt.Services;

public class FilteredReportService
{
    public string BuildAvailableEquipmentReport(IEnumerable<Equipment> equipment)
    {
        var items = equipment.Where(item => item.Status == EquipmentStatus.Available);
        return BuildEquipmentReport("DOSTEPNY SPRZET", items);
    }

    public string BuildBrokenEquipmentReport(IEnumerable<Equipment> equipment)
    {
        var items = equipment.Where(item => item.Status == EquipmentStatus.Broken);
        return BuildEquipmentReport("USZKODZONY SPRZET", items);
    }

    public string BuildOverdueRentalsReport(IEnumerable<Rental> rentals, DateTime asOf)
    {
        var overdueRentals = rentals
            .Where(item => item.IsActive && item.DueDate.Date < asOf.Date)
            .ToList();

        var builder = new StringBuilder();
        builder.AppendLine("PRZETERMINOWANE WYPOZYCZENIA");

        foreach (var rental in overdueRentals)
        {
            builder.AppendLine(rental.ToString());
        }

        if (overdueRentals.Count == 0)
        {
            builder.AppendLine("Brak przeterminowanych wypozyczen.");
        }

        return builder.ToString();
    }

    private static string BuildEquipmentReport(string title, IEnumerable<Equipment> equipment)
    {
        var items = equipment.ToList();
        var builder = new StringBuilder();
        builder.AppendLine(title);

        foreach (var item in items)
        {
            builder.AppendLine(item.ToString());
        }

        if (items.Count == 0)
        {
            builder.AppendLine("Brak danych.");
        }

        return builder.ToString();
    }
}
