

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


bool running = true;

while (running)
{
    Console.WriteLine("\n=== Kajens Cykeluthyrning ===");
    Console.WriteLine("1. Visa fordon");
    Console.WriteLine("2. Registrera kund");
    Console.WriteLine("3. Hyr ut");
    Console.WriteLine("4. Lämna tillbaka");
    Console.WriteLine("5. Ladda");
    Console.WriteLine("6. Avsluta");
    Console.Write("\nVal: ");

    int choice = int.Parse(Console.ReadLine()!);

    if (choice == 1)
    {
        rentalService.ShowVehicles();
    }
    else if (choice == 2)
    {
        rentalService.RegisterCustomer();
    }
    else if (choice == 3)
    {
        rentalService.RentVehicle();
    }
    else if (choice == 4)
    {
        rentalService.ReturnVehicle();
    }
    else if (choice == 5)
    {
        rentalService.ChargeVehicle();
    }

    else if (choice == 6)
    {
        break;
    }
}






