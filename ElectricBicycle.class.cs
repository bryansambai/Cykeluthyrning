

public class ElectricBicycle: Vehicle
{
    public int BatteryLevel { get; private set;}
     public ElectricBicycle(int vehicleNumber, int batteryLevel, decimal hourlyRate): base(vehicleNumber, hourlyRate)
    {
        NewBatteryLevel(batteryLevel);
    }
    public void ChargeBattery()
    {
        BatteryLevel = 100;
    }
    public void UseBattery(int hours)
    {
        int batteryUsed = hours * 10;
        int newLevel = BatteryLevel - batteryUsed;

        if  (newLevel < 0)
        {
            BatteryLevel = 0;
        }
        else
        {
            BatteryLevel = newLevel;
        }
    }
    public bool NewBatteryLevel(int value)
    {
        if (value < 0 || value > 100)
        {
            return false;
        }
        else
        {
            BatteryLevel = value;
            return true;
        }
    }
}
