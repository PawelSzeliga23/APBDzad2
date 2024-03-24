namespace ConsoleApp1;

public class CooledContainer : Container
{
    private string _productName;
    private double _temperature;

    public CooledContainer(double height, double ownWeight, double depth, double maxLoad) : base(height, ownWeight,
        depth, maxLoad, "C")
    {
        _temperature = 0;
        _productName = "";
    }

    public void Load(double loadMass, string productName, double productTemperature)
    {
        if (_productName == "")
        {
            _productName = productName;
        }
        if (productName.Equals(_productName))
        {
            if (Math.Abs(_temperature - productTemperature) < 0.00005)
            {
                base.Load(loadMass);
            }
            else
            {
                Console.WriteLine("Temperature is not appropriate for product");
            }
        }
        else
        {
            Console.WriteLine("You can't store different products in one container");
        }
    }

    public double Temperature
    {
        set => _temperature = value;
    }

    public override void Unload()
    {
        _productName = "";
        base.Unload();
    }

    public override string ToString()
    {
        return $"{base.ToString()}, ProductName: {_productName}, Temperature: {_temperature}";
    }
}