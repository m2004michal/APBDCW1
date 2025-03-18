namespace cw1;

public class MainClass
{
    private static void Main(string[] args)
    {
        // Stworzenie kontenera danego typu
        Console.WriteLine("Stworzenie kontenera danego typu");
        var fluidContainer = new FluidContainer(2, 300, 12, 4000);
        Console.WriteLine();

        // Załadowanie ładunku do danego kontenera
        Console.WriteLine("Załadowanie ładunku do danego kontenera");
        fluidContainer.Load(3000, false);
        Console.WriteLine("cargo weight = " + fluidContainer.CargoWeight);
        Console.WriteLine();

        // Załadowanie kontenera na statek
        Console.WriteLine("Załadowanie kontenera na statek");
        var containerShip = new ContainerShip(10, 66, 1000);
        containerShip.LoadContainer(fluidContainer);
        Console.WriteLine();

        // Załadowanie listy kontenerów na statek
        Console.WriteLine("Załadowanie listy kontenerów na statek");
        var containers = new List<Container?>();
        var gasContainer = new GasContainer(2, 300, 12, 4000);
        var cooledContainer = new CooledContainer(2, 300, 12, 4000, "Banana", 10);
        cooledContainer.Load(3000, "Banana", 11);
        gasContainer.Load(3000, 30);
        containers.Add(cooledContainer);
        containers.Add(gasContainer);
        containers.Add(fluidContainer);
        containerShip.LoadContainers(containers);
        Console.WriteLine();
       
        // Usunięcie kontenera ze statku
        Console.WriteLine("Usunięcie kontenera ze statku");
        containerShip.DeleteContainer("KON-L-4");
        Console.WriteLine();
        
        //  Rozładowanie kontenera
        Console.WriteLine("Rozładowanie kontenera");
        var cooledContainer2 = new CooledContainer(2, 300, 12, 4000, "Banana", 10);
        cooledContainer2.Load(3000, "Banana", 11);
        cooledContainer2.Offload();
        cooledContainer2.Load(3000, "Cheese", 11);
        Console.WriteLine();

        // Zastąpienie kontenera na statku o danym numerze innym kontenerem
        Console.WriteLine("Zastąpienie kontenera na statku o danym numerze innym kontenerem");
        containerShip.ReplaceContainer(cooledContainer2, "KON-C-3");
        Console.WriteLine();
        
        // Możliwość przeniesienie kontenera między dwoma statkami
        Console.WriteLine();
        Console.WriteLine("Możliwość przeniesienie kontenera między dwoma statkami");
        var containerShip3 = new ContainerShip(10, 2, 10);
        var gasContainer2 = new GasContainer(2, 300, 12, 4000);
        gasContainer2.Load(700, 30);
        containerShip3.LoadContainer(gasContainer2);
        var containerShip4 = new ContainerShip(10, 2, 10);
        var gasContainer3 = new GasContainer(2, 300, 12, 4000);
        gasContainer3.Load(3000, 30);
        containerShip4.LoadContainer(gasContainer3);
        containerShip3.SwapContainers("KON-G-3", "KON-G-4", containerShip4);
        containerShip3.PrintContainers();
        Console.WriteLine();
        containerShip4.PrintContainers();
        Console.WriteLine();

        // Wypisanie informacji o danym kontenerze
        Console.WriteLine();
        Console.WriteLine("Wypisanie informacji o danym kontenerze");
        var gasContainer4 = new GasContainer(2, 300, 12, 4000);
        gasContainer4.Load(3000, 30);
        gasContainer4.PrintInformation();
        Console.WriteLine();

        // Wypisanie informacji o danym statku i jego ładunku
        Console.WriteLine();
        Console.WriteLine("Wypisanie informacji o danym statku i jego ładunku");
        var containerShip5 = new ContainerShip(10, 2, 10);
        var gasContainer5 = new GasContainer(2, 300, 12, 4000);
        gasContainer5.Load(3000, 30);
        containerShip5.LoadContainer(gasContainer5);
        containerShip5.PrintInformation();
    }
}