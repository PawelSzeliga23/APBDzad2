namespace ConsoleApp1;

public class ContainerShip
{
    private List<Container> _containers;
    private double _loadMass;
    private double _speed;
    private int _containerCountMax;
    private double _containersMaxWeight;

    public ContainerShip(double speed, int containerCountMax, double containerMaxWeight)
    {
        this._containers = new List<Container>();
        _loadMass = 0;
        _speed = speed;
        _containerCountMax = containerCountMax;
        this._containersMaxWeight = containerMaxWeight * 1000;
    }

    public void loadContainers(List<Container> listOfContainers)
    {
        double mass = 0;
        foreach (var container in listOfContainers)
        {
            mass += container.Mass;
        }

        if (_loadMass + mass < _containersMaxWeight)
        {
            _loadMass += mass;
            _containers.AddRange(listOfContainers);
        }
        else
        {
            Console.WriteLine("Cannot load containers. Mass is too big.");
        }
    }

    public void removeContainer(Container container)
    {

        if (_containers.Remove(container))
        {
            _loadMass -= container.Mass;
        }
    }

    public void replaceContainer(int number, Container container)
    {
        for (int i = 0; i < _containers.Count; i++)
        {
            if (_containers[i].Number == number)
            {
                _loadMass += _containers[i].Mass - container.Mass;
                _containers[i] = container;
            }
        }
    }

    public void loadContainer(Container container)
    {
        if (_loadMass + container.Mass < _containersMaxWeight)
        {
            _containers.Add(container);
        }
    }

    public override string ToString()
    {
        string res = $"ContainerShip: Containers: ";
        foreach (var VARIABLE in _containers)
        {
            res += VARIABLE.ToString() + "\n";
        }
        res += $", LoadMass: {_loadMass} kg, Speed: {_speed} knots, ContainerCountMax: {_containerCountMax}, ContainersMaxWeight: {_containersMaxWeight/1000} t";
        return res;
    }

    public Container? getContainer(int number)
    {
        foreach (var container in _containers)
        {
            if (container.Number == number)
            {
                return container;
            }
        }

        return null;
    }
}