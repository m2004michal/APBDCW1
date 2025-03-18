namespace cw1;

public class GasContainer : Container
{
    public GasContainer(double height, double conteinerWeigth, double depth, double maxCapacity) : base(height,
        conteinerWeigth, depth, "G", maxCapacity)
    {
    }

    private protected double? Pressure { get; set; }

    public override void Offload()
    {
        Pressure = null;
        CargoWeight *= 0.05;
    }

    public void Load(double cargoWeight, double pressure)
    {
        CargoWeight = cargoWeight;
        Pressure = pressure;
        if (ValidateLoading()) return;
        CargoWeight = null;
        Pressure = null;
    }

    private bool ValidateLoading()
    {
        if (!PerformBasicValidation()) return false;
        return true;
    }

    public void Notify(string situationDescription)
    {
        Console.WriteLine("Zaszła niebezpieczna sytuacja. ");
        Console.WriteLine("Opis sytuacji: " + situationDescription);
        Console.WriteLine("Numer kontenera: " + SerialNumber);
        throw new NotImplementedException();
    }

    public void PrintInformation()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        return base.ToString() + " Pressure: " + Pressure + "atmospheres ";
    }
}