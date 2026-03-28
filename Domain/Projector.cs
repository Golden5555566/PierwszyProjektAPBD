namespace Projekt.Domain;

public class Projector : Equipment
{
    public Projector(string name, int brightnessAnsi) : base(name)
    {
        BrightnessAnsi = brightnessAnsi;
    }

    public int BrightnessAnsi { get; }

    public override string ToString()
    {
        return base.ToString() + $" - jasnosc: {BrightnessAnsi} ANSI";
    }
}
