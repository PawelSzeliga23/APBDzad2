namespace ConsoleApp1;

public class LiquidContainer : Container, IHazardNotifier
{
    public LiquidContainer(double height, double ownWeight, double depth, double maxLoad) : base(height, ownWeight,
        depth, maxLoad, "L")
    {
    }

    public void Load(double loadMass, bool isDangerous)
    {
        switch (isDangerous)
        {
            case true when loadMass < (_maxLoad / 2):
            case false when loadMass < (_maxLoad * 0.9):
                base.Load(loadMass);
                break;
            default:
                Notify();
                break;
        }
    }

    public void Notify()
    {
        var parts = _serialNumber.Split("-");
        Console.WriteLine("Attention! Hazard at liquid container number:" + parts[2]);
    }
}