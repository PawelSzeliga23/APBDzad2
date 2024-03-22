namespace ConsoleApp1;

public class GasContainer : Container, IHazardNotifier
{
    private double _psi;

    public GasContainer(double height, double ownWeight, double depth, double maxLoad, double psi) : base(height,
        ownWeight, depth, maxLoad, "G")
    {
        _psi = psi;
    }

    public void Notify()
    {
        var parts = _serialNumber.Split("-");
        Console.WriteLine("Attention! Hazard at gas container number:" + parts[2]);
    }

    public override void Unload()
    {
        _mass *= 0.05;
    }
}