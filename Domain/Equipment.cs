namespace Projekt.Domain;

public abstract class Equipment
{
    protected Equipment(string name)
    {
        Id = EntityIdGenerator.NextEquipmentId();
        Name = name;
        Status = EquipmentStatus.Available;
    }

    public int Id { get; }
    public string Name { get; }
    public EquipmentStatus Status { get; private set; }

    public void MarkAsAvailable()
    {
        Status = EquipmentStatus.Available;
    }

    public void MarkAsRented()
    {
        Status = EquipmentStatus.Rented;
    }

    public void MarkAsBroken()
    {
        Status = EquipmentStatus.Broken;
    }

    public override string ToString()
    {
        return $"{Id}. {Name} [{Status}]";
    }
}
