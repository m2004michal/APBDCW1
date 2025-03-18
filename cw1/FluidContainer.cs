namespace cw1;

public class FluidContainer : Container, IHazardNotifier  {
    
    private protected bool? IsCargoHazard {get;set;}

    public FluidContainer(double height, double conteinerWeigth,
        double depth, string serialNumber, double maxCapacity) : base(height, conteinerWeigth, depth, serialNumber, maxCapacity) {
    }

    public override void Offload() {
        IsCargoHazard = null;
        CargoWeight = null;
    }

    public void Load(double cargoWeight, bool isCargoHazard) {
        CargoWeight = cargoWeight;
        IsCargoHazard = isCargoHazard;
        if (ValidateLoading(cargoWeight, isCargoHazard)) return;
        CargoWeight = null;
        IsCargoHazard = null;
    }

    private bool ValidateLoading(double cargoWeight, bool isCargoHazard) {
        if (!PerformBasicValidation()) {
            return false;
        }
        if (isCargoHazard && cargoWeight > MaxCapacity * 0.5) {
            Notify("Błąd załadunku");
            return false;
        }
        if (!isCargoHazard && cargoWeight > MaxCapacity * 0.9) {
            Notify("Błąd załadunku");
            return false;
        }
        Console.WriteLine("Loading succesful");
        return true;
    }

    public void Notify(string situationDescription) {
        Console.WriteLine("Zaszła niebezpieczna sytuacja. ");
        Console.WriteLine("Opis sytuacji: " + situationDescription);
        Console.WriteLine("Numer kontenera: " + SerialNumber);
        throw new NotImplementedException();
    }
}