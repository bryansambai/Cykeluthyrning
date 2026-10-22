


public class RentalService
{
    public List<Customer> customers = new List<Customer>();
    public List<Vehicle> vehicles = new List<Vehicle>();
    public RentalService()
    {
        vehicles.Add(new Bicycle(1, 40m));
        vehicles.Add(new Bicycle(2, 40m));
        vehicles.Add(new ElectricBicycle(3, 80, 70m));
        vehicles.Add(new ElectricBicycle(4, 25, 70m));
    }
    public void ShowVehicles()
    {
        foreach (Vehicle vehicle in vehicles)
        {
            string status;
            if (vehicle.Rented == true)
            {
                status = "Uthyrt";
            }
            else
            {
                status = "Ledigt";
            }

            if (vehicle is ElectricBicycle electricBicycle)
            {
                Console.WriteLine($"NR: {electricBicycle.VehicleNumber}, Typ. Elcykel, Batteri: {electricBicycle.BatteryLevel}%, Timpris: {electricBicycle.HourlyRate}kr, Uthyrt: {status}.");
            }
            else if (vehicle is Bicycle bicycle)
            {
                Console.WriteLine($"NR: {bicycle.VehicleNumber}, Typ. Cykel, Timpris: {bicycle.HourlyRate}kr, Uthyrt: {status}.");
            }
        }
    }
}