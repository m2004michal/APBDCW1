namespace cw1;

public class CooledContainer : Container, IHazardNotifier
{
    public CooledContainer(double height, double conteinerWeigth, double depth, double maxCapacity, string productName,
        double temperature)
        : base(height, conteinerWeigth, depth, "C", maxCapacity)
    {
        ProductName = productName;
        Temperature = temperature;
    }

    private protected string ProductName { get;}
    private protected double Temperature { get;}

    public void Notify(string situationDescription)
    {
        Console.WriteLine("Zaszła niebezpieczna sytuacja. ");
        Console.WriteLine("Opis sytuacji: " + situationDescription);
        Console.WriteLine("Numer kontenera: " + SerialNumber);
    }

    public override void Offload()
    {
        CargoWeight = null;
    }

    public void Load(double cargoWeight, string productName, double productTemperature)
    {
        CargoWeight = cargoWeight;
        if (ValidateLoading(productName, productTemperature)) return;
        CargoWeight = null;
    }

    private bool ValidateLoading(string productName, double productTemperature)
    {
        if (!PerformBasicValidation()
            || Temperature > productTemperature
            || productName != ProductName)
        {
            Notify("Loading error");
            return false;
        }

        return true;
    }

    public void PrintInformation()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        return base.ToString() + " ProductName" + ProductName + " Temperature" + Temperature;
    }
}