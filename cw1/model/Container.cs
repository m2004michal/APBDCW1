public abstract class Container
{
    private static int counter;

    protected Container(double height, double conteinerWeigth, double depth,
        string idLetter, double maxCapacity)
    {
        Height = height;
        ContainerWeight = conteinerWeigth;
        Depth = depth;
        SerialNumber = "KON-" + idLetter + "-" + counter;
        counter++;
        MaxCapacity = maxCapacity;
    }

    public double? CargoWeight { get; set; }
    public double Height { get; set; }
    public double ContainerWeight { get; set; }
    public double Depth { get; set; }
    public string SerialNumber { get; set; }
    public double MaxCapacity { get; set; }

    public virtual void Offload()
    {
    }

    public virtual bool ValidateLoading(Container? container)
    {
        return true;
    }

    private protected bool PerformBasicValidation()
    {
        var result = CargoWeight < MaxCapacity;
        if (!result)
        {
            Console.WriteLine("Error performing basic container validation");
            throw new OverfillException();
        }

        return result;
    }

    public override string ToString()
    {
        return "Cargo Weight: " + CargoWeight + "kg Height: " + Height + "cm Depth: " + Depth + "cm Serial Number: " +
               SerialNumber + " Max Capacity: " + MaxCapacity + "kg " + "ContainerWeight " +
               ContainerWeight + "kg ";
    }
}

internal class OverfillException : Exception
{
}