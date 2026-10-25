
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






