namespace cw1;

public class MainClass {
    static void Main(string[] args)
    {
        FluidContainer? fluidContainer = new FluidContainer(2,300, 12, "KON-L-1", 4000);
        fluidContainer.Load(3000, false);
        Console.WriteLine("cargo weight = " + fluidContainer.CargoWeight);
        // fluidContainer.Offload();
        // Console.WriteLine("cargo weight = " + fluidContainer.CargoWeight);
        
        GasContainer? gasContainer = new GasContainer(2,300, 12, "KON-G-2", 4000);
        gasContainer.Load(3000, 30);
        Console.WriteLine("cargo weight = " + gasContainer.CargoWeight);
        // gasContainer.Offload();
        // Console.WriteLine("cargo weight = " + gasContainer.CargoWeight);

        CooledContainer? cooledContainer = new CooledContainer(2, 300, 12, "KON-C-3", 4000, "Banana",10);
        cooledContainer.Load(3000, "Banana", 11);
        Console.WriteLine("cargo weight = " + cooledContainer.CargoWeight);
        // cooledContainer.Offload();
        // Console.WriteLine("cargo weight = " + cooledContainer.CargoWeight);

        ContainerShip containerShip = new ContainerShip(10, 2, 1000000);
        containerShip.LoadContainer(fluidContainer);
        containerShip.LoadContainer(gasContainer);
        containerShip.LoadContainer(cooledContainer);
        ContainerShip containerShip2 = new ContainerShip(10, 2, 1000000);
        List<Container?> containers = new List<Container?>();
        containers.Add(cooledContainer);
        containers.Add(gasContainer);
        containers.Add(fluidContainer);
        containerShip2.LoadContainers(containers);
        containerShip2.Containers.ForEach(Console.WriteLine);
        Console.WriteLine();
        containerShip2.DeleteContainer("KON-C-3");
        containerShip2.Containers.ForEach(Console.WriteLine);
        Console.WriteLine();
        containerShip2.ReplaceContainer(fluidContainer, "KON-G-2");
        containerShip2.Containers.ForEach(Console.WriteLine);

    }
    
}