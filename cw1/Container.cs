public abstract class Container
{
    public double? CargoWeight{get;set;}
    public  double Height{get;set;}
    public double ContainerWeight{get;set;}
    public double Depth {get;set;}
    public string SerialNumber{get;set;}
    public double MaxCapacity{get;set;}
    protected Container(double height, double conteinerWeigth, double depth,
        string serialNumber, double maxCapacity) {
        this.Height = height;
        this.ContainerWeight = conteinerWeigth;
        this.Depth = depth;
        this.SerialNumber = serialNumber;
        this.MaxCapacity = maxCapacity;
    }

    public virtual void Offload() {}

    private protected bool PerformBasicValidation()
    {
        bool result = CargoWeight < MaxCapacity;
        if (!result)
        {
            Console.WriteLine("Error performing basic container validation");
            throw new OverfillException();
        }
        return result;
    }
}

internal class OverfillException : Exception
{
}