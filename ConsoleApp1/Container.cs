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
    protected int _number;

    public Container(double height, double ownWeight, double depth, double maxLoad, string serialNumber)
    {
        this._height = height;
        this._ownWeight = ownWeight;
        this._depth = depth;
        this._mass = 0;
        this._maxLoad = maxLoad;
        _number = ++_count;
        this._serialNumber = "KON-" + serialNumber + "-" + _number;
    }

    public void Load(double loadMass)
    {
        if (_mass + loadMass > _maxLoad)
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

    public int Number => _number;
    public double Mass => _mass;

    public override string ToString()
    {
        return $"{this.GetType()}: SerialNumber: {_serialNumber}, LoadMass: {_mass}, Height: {_height}, OwnWeight: {_ownWeight}, Depth: {_depth}, MaxLoad: {_maxLoad}";
    }
}