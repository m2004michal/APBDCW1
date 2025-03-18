public abstract class Container
{
    private static int counter = 0;
    public double? CargoWeight{get;set;}
    public  double Height{get;set;}
    public double ContainerWeight{get;set;}
    public double Depth {get;set;}
    public string SerialNumber{get;set;}
    public double MaxCapacity{get;set;}
    protected Container(double height, double conteinerWeigth, double depth,
        string idLetter, double maxCapacity) {
        
        this.Height = height;
        this.ContainerWeight = conteinerWeigth;
        this.Depth = depth;
        this.SerialNumber = "KON-" + idLetter + "-" + counter;
        counter++;
        this.MaxCapacity = maxCapacity;
    }

    public virtual void Offload() {}

    public virtual bool ValidateLoading(Container? container)
    {
        return true;
    }
    
    

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

    public override string ToString()
    {
        return "Cargo Weight: " + CargoWeight + "kg Height: " + Height + "cm Depth: " + Depth + "cm Serial Number: " + SerialNumber + " Max Capacity: " + MaxCapacity + "kg " + "ContainerWeight " +
               ContainerWeight + "kg ";
    }
}

internal class OverfillException : Exception
{
}