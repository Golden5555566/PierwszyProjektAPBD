namespace Projekt.Domain;

public class Camera : Equipment
{
    public Camera(string name, bool has4K) : base(name)
    {
        Has4K = has4K;
    }

    public bool Has4K { get; }

    public override string ToString()
    {
        var quality = Has4K ? "4K" : "Full HD";
        return base.ToString() + $" - nagrywanie: {quality}";
    }
}
