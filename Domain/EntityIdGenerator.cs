namespace Projekt.Domain;

public static class EntityIdGenerator
{
    private static int _equipmentId = 1;
    private static int _userId = 1;
    private static int _rentalId = 1;

    public static int NextEquipmentId() => _equipmentId++;

    public static int NextUserId() => _userId++;

    public static int NextRentalId() => _rentalId++;
}
