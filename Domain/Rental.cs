namespace Projekt.Domain;

public class Rental
{
    public Rental(Equipment equipment, User user, DateTime rentalDate, DateTime dueDate)
    {
        Id = EntityIdGenerator.NextRentalId();
        Equipment = equipment;
        User = user;
        RentalDate = rentalDate;
        DueDate = dueDate;
    }

    public int Id { get; }
    public Equipment Equipment { get; }
    public User User { get; }
    public DateTime RentalDate { get; }
    public DateTime DueDate { get; }
    public DateTime? ReturnDate { get; private set; }

    public bool IsActive => ReturnDate is null;

    public void Return(DateTime returnDate)
    {
        ReturnDate = returnDate;
    }

    public override string ToString()
    {
        var status = IsActive ? "aktywne" : $"zwrocone {ReturnDate:yyyy-MM-dd}";
        return $"{Id}. {Equipment.Name} -> {User.FullName}, od {RentalDate:yyyy-MM-dd} do {DueDate:yyyy-MM-dd}, {status}";
    }
}
