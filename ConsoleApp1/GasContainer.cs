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
        Console.WriteLine("Attention! Hazard at gas container number:" + _number);
    }

    public override void Unload()
    {
        _mass *= 0.05;
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Psi: {_psi}";
    }
}