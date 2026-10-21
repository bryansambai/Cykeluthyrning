


public class Vehicle
{
    public int VehicleNumber { get; private set; }
    public decimal HourlyRate { get; private set; }
    public bool Rented { get; private set; }
    public Vehicle(int vehicleNumber, decimal hourlyRate)
    {
        VehicleNumber = vehicleNumber;
        HourlyRate = hourlyRate;
    }
    public bool RentOut()
    {
        if (Rented == true)
        {
            return false;
        }
        else
        {
            Rented = true;
            return true;
        }
    }
    public bool ReturnVehicle()
    {
        if (Rented == false)
        {
            return false;
        }
        else
        {
            Rented = false;
            return true;
        }
    }
    public decimal CalculateBasePrice(decimal hours)
    {
        decimal total = HourlyRate * hours;
        return total;
    }
}

