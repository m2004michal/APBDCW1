namespace cw1;

public class ContainerShip
{
    public ContainerShip(double maxSpeed, int maximumContainersAmount, double maximumContainersWeight)
    {
        MaxSpeed = maxSpeed;
        MaximumContainersAmount = maximumContainersAmount;
        MaximumContainersWeight = maximumContainersWeight;
    }

    public List<Container?> Containers { get; set; } = new();
    public double MaxSpeed { get; set; }
    public int MaximumContainersAmount { get; }
    public double MaximumContainersWeight { get; set; }

    public void LoadContainer(Container? container)
    {
        if (ValidateLoading(container))
        {
            Console.WriteLine("Loading successful");
            Containers.Add(container);
        }
        else
        {
            Console.WriteLine("Loading failed");
        }
    }

    public void LoadContainers(List<Container?> containers)
    {
        containers.ForEach(LoadContainer);
    }


    public bool ValidateLoading(Container? container)
    {
        if (GetLoadedContainersWeight() + container?.ContainerWeight + container?.CargoWeight >
            MaximumContainersWeight * 1000)
        {
            Console.WriteLine("Przekroczono maksymalna wage załadunku");
            return false;
        }

        if (Containers.Count == MaximumContainersAmount)
        {
            Console.WriteLine("Przekroczono maksymalna ilosc kontenerow");
            return false;
        }

        return true;
    }

    public double? GetLoadedContainersWeight()
    {
        double? weight = 0;
        Containers.ForEach(container => weight += container?.CargoWeight + container.ContainerWeight);
        return weight;
    }

    public void DeleteContainer(string containerId)
    {
        Containers.Remove(Containers.Find(container => container?.SerialNumber == containerId));
        Console.WriteLine($"Container {containerId} deleted");
    }

    public void ReplaceContainer(Container container, string containerId)
    {
        var oldContainer = Containers.Find(container => container?.SerialNumber == containerId);
        Containers.Remove(oldContainer);
        if (ValidateLoading(container) && oldContainer != null)
        {
            Containers.Add(container);
            Console.WriteLine("Replaced successfuly");
        }
        else
        {
            Containers.Add(oldContainer);
            Console.WriteLine("Replace failed");
        }
    }

    public void SwapContainers(string containerFromFirstShipId, string containerFromSecondShipId,
        ContainerShip containerShip)
    {
        var containerFromFirstShip = Containers.Find(container => container?.SerialNumber == containerFromFirstShipId);
        var containerFromSecondShip =
            containerShip.Containers.Find(container => container?.SerialNumber == containerFromSecondShipId);

        if (containerFromFirstShip != null)
            DeleteContainer(containerFromFirstShip.SerialNumber);
        if (containerFromSecondShip != null)
            containerShip.DeleteContainer(containerFromSecondShip.SerialNumber);
        if (CanSwapContainers(containerFromFirstShip, containerFromSecondShip, containerShip))
        {
            LoadContainer(containerFromSecondShip);
            containerShip.LoadContainer(containerFromFirstShip);
            Console.WriteLine("Swapped successfuly");
        }
        else
        {
            LoadContainer(containerFromFirstShip);
            containerShip.LoadContainer(containerFromSecondShip);
            Console.WriteLine("Loading failed");
        }
    }

    public bool CanSwapContainers(Container? containerFromFirstShip, Container? containerFromSecondShip,
        ContainerShip containerShip)
    {
        if (containerFromFirstShip == null || containerFromSecondShip == null) return false;

        if (!ValidateLoading(containerFromSecondShip)) return false;

        if (!containerShip.ValidateLoading(containerFromFirstShip)) return false;

        return true;
    }

    public void PrintContainers()
    {
        Containers.ForEach(container => Console.Write(container + "; "));
    }

    public void PrintInformation()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        var toReturn = " MaxSpeed: " + MaxSpeed + "kts MaximumContainersAmount: " + MaximumContainersAmount +
                       " MaximumContainersWeight: " + MaximumContainersWeight + "t Cargo: ";
        Containers.ForEach(container => toReturn += container + "; ");
        return toReturn;
    }
}