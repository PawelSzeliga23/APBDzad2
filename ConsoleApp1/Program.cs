namespace ConsoleApp1;

class Program
{
    public static void Main(string[] args)
    {
        var gasContainer = new GasContainer(60, 3500, 60, 20000, 2);
        gasContainer.Load(2000);
        gasContainer.Unload();
        Console.WriteLine(gasContainer);
        var liquidContainer = new LiquidContainer(60, 2355, 100, 50000);
        liquidContainer.Load(25000,true);
        liquidContainer.Unload();
        liquidContainer.Load(30000,true);
        liquidContainer.Unload();
        liquidContainer.Load(50000,false);
        liquidContainer.Unload();
        var cooledContainer = new CooledContainer(60, 5423, 100, 60000);
        cooledContainer.Temperature = 13.3;
        cooledContainer.Load(20000,"Bananas",13.3);
        cooledContainer.Load(20000,"Fish",2);
        cooledContainer.Unload();
        var containerShip = new ContainerShip(20, 180, 450);
        containerShip.loadContainer(cooledContainer);
        containerShip.loadContainer(liquidContainer);
        var containers = new List<Container>();
        for (int i = 0; i < 20; i++)
        {
            var random = new Random();
            containers.Add(new GasContainer(random.Next(0,100),random.Next(5000,7000),random.Next(0,100),random.Next(20000,60000),1));
        }
        containerShip.loadContainers(containers);
        containerShip.removeContainer(cooledContainer);
        containerShip.replaceContainer(5,cooledContainer);
        var containerShip2 = new ContainerShip(30,280,550);
        ReplaceContainerBetweenShips(containerShip,containerShip2,7);
        Console.WriteLine(containerShip);
        Console.WriteLine(containerShip2);
    }

    public static void ReplaceContainerBetweenShips(ContainerShip ship1, ContainerShip ship2, int containerNumber)
    {
        var container = ship1.getContainer(containerNumber);
        if (container != null)
        {
            ship1.removeContainer(container);
            ship2.loadContainer(container);
        }
        else
        {
            Console.WriteLine("Not found.");
        }
    }
}