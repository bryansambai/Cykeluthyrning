

/*
Console.Write("Ange batteri nivå för din nya elcykel: ");
int batteryLevel = int.Parse(Console.ReadLine()!);

if (batteryLevel >= 0 && batteryLevel <= 100)
{
    ElectricBicycle electricBicycle = new ElectricBicycle(3, batteryLevel, 70m);
    Console.WriteLine($"Elsparkcykel är skapad med {electricBicycle.BatteryLevel}% batteri.");
    electricBicycle.ChargeBattery();

    Console.WriteLine($"Efter laddning: {electricBicycle.BatteryLevel}%");
    bool result = electricBicycle.NewBatteryLevel(150);
    Console.WriteLine($"Ändringen lyckades: {result}");
    Console.WriteLine($"Nuvarande batterinivå: {electricBicycle.BatteryLevel}%");
}
else
{
    Console.WriteLine("Ogiltig batterinivå. Ange batteri nivå mellan 0% och 100%.");
}

*/




RentalService rentalService = new RentalService();

rentalService.ShowVehicles();