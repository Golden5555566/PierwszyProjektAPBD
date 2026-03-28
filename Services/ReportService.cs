using System.Text;
using Projekt.Domain;

namespace Projekt.Services;

public class ReportService
{
    public string BuildEquipmentReport(IEnumerable<Equipment> equipmentList)
    {
        var builder = new StringBuilder();
        builder.AppendLine("SPRZET");

        foreach (var equipment in equipmentList)
        {
            builder.AppendLine(equipment.ToString());
        }

        return builder.ToString();
    }

    public string BuildUsersReport(IEnumerable<User> users)
    {
        var builder = new StringBuilder();
        builder.AppendLine("UZYTKOWNICY");

        foreach (var user in users)
        {
            builder.AppendLine(user.ToString());
        }

        return builder.ToString();
    }

    public string BuildActiveRentalsReport(IEnumerable<Rental> rentals)
    {
        var builder = new StringBuilder();
        builder.AppendLine("AKTYWNE WYPOZYCZENIA");

        foreach (var rental in rentals.Where(r => r.IsActive))
        {
            builder.AppendLine(rental.ToString());
        }

        return builder.ToString();
    }
}
