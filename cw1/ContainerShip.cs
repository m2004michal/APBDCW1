namespace cw1;

public class ContainerShip
{

    public List<Container?> Containers { get; set; } = new List<Container?>();
    public double MaxSpeed { get; set; }
    public int MaximumContainersAmount { get; private set; }
    public double MaximumContainersWeight { get; set; }

    public ContainerShip(double maxSpeed, int maximumContainersAmount, double maximumContainersWeight)
    {
        MaxSpeed = maxSpeed;
        MaximumContainersAmount = maximumContainersAmount;
        MaximumContainersWeight = maximumContainersWeight;
    }

    public void LoadContainer(Container? container) {
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

    public void LoadContainers(List<Container?> containers) {
        containers.ForEach(LoadContainer);
    }


    public bool ValidateLoading(Container? container)
    {
        if (GetLoadedContainersWeight() + container.ContainerWeight + container.CargoWeight > MaximumContainersWeight)
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

    public double? GetLoadedContainersWeight() {
        double? weight = 0;
        Containers.ForEach((container => weight += container.CargoWeight + container.ContainerWeight));
        return weight;
    }

    public void deleteContainer(string containerId)
    {
        Containers.Remove(Containers.Find((container => container.SerialNumber == containerId)));
    }
}