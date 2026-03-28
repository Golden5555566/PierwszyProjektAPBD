using Projekt.Domain;

namespace Projekt.Services;

public class RentalService
{
    private readonly List<Rental> _rentals = [];

    public IReadOnlyList<Rental> Rentals => _rentals;

    public OperationResult RentEquipment(Equipment equipment, User user, DateTime rentalDate)
    {
        if (equipment.Status == EquipmentStatus.Broken)
        {
            return OperationResult.Fail("Sprzet jest uszkodzony i nie moze zostac wypozyczony.");
        }

        if (equipment.Status == EquipmentStatus.Rented)
        {
            return OperationResult.Fail("Sprzet jest juz wypozyczony.");
        }

        var activeRentalsForUser = _rentals.Count(r => r.IsActive && r.User.Id == user.Id);
        var maxActiveRentals = RentalPolicy.GetMaxActiveRentals(user);

        if (activeRentalsForUser >= maxActiveRentals)
        {
            return OperationResult.Fail("Uzytkownik osiagnal limit aktywnych wypozyczen.");
        }

        var dueDate = rentalDate.AddDays(RentalPolicy.GetRentalDays(user));
        var rental = new Rental(equipment, user, rentalDate, dueDate);

        equipment.MarkAsRented();
        _rentals.Add(rental);

        return OperationResult.Ok($"Wypozyczono: {equipment.Name} dla {user.FullName} do {dueDate:yyyy-MM-dd}.");
    }

    public OperationResult ReturnEquipment(Equipment equipment, DateTime returnDate)
    {
        var rental = _rentals.LastOrDefault(r => r.IsActive && r.Equipment.Id == equipment.Id);
        if (rental is null)
        {
            return OperationResult.Fail("Nie znaleziono aktywnego wypozyczenia dla tego sprzetu.");
        }

        rental.Return(returnDate);
        equipment.MarkAsAvailable();

        return OperationResult.Ok($"Przyjeto zwrot sprzetu: {equipment.Name}.");
    }

    public List<Rental> GetActiveRentals()
    {
        return _rentals.Where(r => r.IsActive).ToList();
    }
}
