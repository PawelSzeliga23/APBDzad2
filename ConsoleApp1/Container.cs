namespace ConsoleApp1;

public class Container
{
    private static int _count = 0;
    protected double _mass;
    private double _height;
    protected double _ownWeight;
    private double _depth;
    protected double _maxLoad;
    protected string _serialNumber;

    public Container(double height, double ownWeight, double depth, double maxLoad, string serialNumber)
    {
        this._height = height;
        this._ownWeight = ownWeight;
        this._depth = depth;
        this._mass = 0;
        this._maxLoad = maxLoad;
        this._serialNumber = "KON-" + serialNumber + "-" + ++_count;
    }

    public void Load(double loadMass)
    {
        if (loadMass > _maxLoad)
        {
            throw new OverfillException("LoadMass is grater than container can carry.");
        }
        else
        {
            _mass += loadMass;
            Console.WriteLine("Container has been loaded.");
        }
    }

    public virtual void Unload()
    {
        _mass = 0;
        Console.WriteLine("Container has been unloaded.");
    }
}