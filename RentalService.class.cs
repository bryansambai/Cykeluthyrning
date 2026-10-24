



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
    public void RegisterCustomer()
    {
        Console.Write("Vad heter du? ");
        string name = Console.ReadLine()!;
        

        Console.Write("Hur gammal är du? ");
        int age = int.Parse(Console.ReadLine()!);


        Console.Write("Är du medlem? (ja/nej)? ");
        string isMember = Console.ReadLine()!;

        bool status;
        if(isMember == "ja")
        {
            status = true;
        }
        else
        {
            status = false;
        }
        
        Console.WriteLine($"Namn: {name}.");
        Console.WriteLine($"Ålder: {age} år.");
        Console.WriteLine($"Medlem (ja/nej): {isMember}");

        Console.WriteLine($"{name} är registerad. ");

        Customer newCustomer = new Customer(name, age, status);
        customers.Add(newCustomer);
    }
    public void RentVehicle()
    {
        Console.Write("Ange kunden: ");
        string customerName = Console.ReadLine()!;

        
        bool customerFound = false;
        int customerAge = 0;
        bool isMember = false;
        Customer matchedCustomer = null!;
        foreach (Customer customer in customers)
        {
            if (customerName == customer.Name)
            {
                matchedCustomer = customer;
                isMember = customer.IsMember;
                customerFound = true;
                Console.WriteLine($"Kunden {customer.Name} hittades. ");
                customerAge = customer.Age;
            }
        }

        if (customerFound == false)
        {
            Console.WriteLine($"Kunden hittades inte i listan.");
            return;
        }
        
        Console.Write("Ange fordons nr: ");
        int choicenVehicle = int.Parse(Console.ReadLine()!);

        bool vehicleFound = false;
        Vehicle matchedVehicle = vehicles[0];
        foreach (Vehicle vehicle in vehicles)
        {
           
            if (choicenVehicle == vehicle.VehicleNumber)
            { 
                matchedVehicle = vehicle;
                if (vehicle is ElectricBicycle electricBicycle)
                {
                    if (electricBicycle.BatteryLevel < 30)
                    {
                        Console.WriteLine($"Elcykel batteri nivå: {electricBicycle.BatteryLevel}% behöver laddas först. ");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"Elcykel batteri nivå: {electricBicycle.BatteryLevel}% får hyras ut. ");
                    }
                }
                vehicleFound = true;
                if (vehicle.Rented == false)
                {
                    Console.WriteLine($"Fordonet: {vehicle.VehicleNumber} är ledigt. ");
                }
                else
                {
                    Console.WriteLine("Fordonet är uthyt, välj en annan. ");
                    return;
                }


                if (choicenVehicle == 1 || choicenVehicle == 2)
                {
                    if (customerAge >= 15)
                    {
                        Console.WriteLine("Du får hyra en cykel. ");
                        vehicle.RentOut();
                    }
                    else
                    {
                        Console.WriteLine("Du för ung och får inte hyra cykelen. ");
                        return;
                    }
                }
                else if (choicenVehicle == 3 || choicenVehicle == 4)
                {
                    if (customerAge >= 18)
                    {
                        Console.WriteLine("Du får hyra en elcykel. ");
                        vehicle.RentOut();
                    }
                    else
                    {
                        Console.WriteLine("Du för ung och får inte hyra elcykelen. ");
                        return;
                    }
                }
            }
        }
        if (vehicleFound == false)
        {
            Console.WriteLine("Fordonet hittades inte i listan. ");
            return;
        }
        
        Console.Write("Hur många timmar vill du hyra fordonet? ");
        int hoursRented = int.Parse(Console.ReadLine()!);

        Rental rental = new Rental(matchedCustomer, matchedVehicle, hoursRented);

        if (matchedVehicle is ElectricBicycle electricBicycle1)
        {
            electricBicycle1.UseBattery(hoursRented);
            Console.WriteLine($"Batteri efter uthyrning: {electricBicycle1.BatteryLevel}%");
        }
        decimal finalPrice = rental.CalculateFinalPrice();
        Console.WriteLine($"Totalt pris: {finalPrice} kr");
    }

    public void ReturnVehicle()
    {
        Console.Write("Ange fordonsnummer att lämna tillbaka: ");
        int vehicleNumber = int.Parse(Console.ReadLine()!);

        bool vehicleFound = false;
        Vehicle matchedVehicle = vehicles[0];
        foreach (Vehicle vehicle in vehicles)
        {
            if (vehicleNumber == vehicle.VehicleNumber)
            {
                matchedVehicle = vehicle;
                vehicleFound = true;
            }
        }

        if (vehicleFound == false)
        {
            Console.WriteLine("Fordonet saknas i listan.  ");
            return;
        }

        if (matchedVehicle.Rented == false)
        {
            Console.WriteLine("Fordonet är redan ledigt.");
            return;
        }

        matchedVehicle.ReturnVehicle();
        Console.WriteLine($"Fordon {matchedVehicle.VehicleNumber} har lämnats tillbaka.");
    }

    public void ChargeVehicle()
    {
        Console.Write("Ange fordonsnummer för elcykeln som ska laddas: ");
        int vehicleNumber = int.Parse(Console.ReadLine()!);

        bool vehicleFound = false;
        Vehicle matchedVehicle = vehicles[0];
        foreach (Vehicle vehicle in vehicles)
        {
            if (vehicleNumber == vehicle.VehicleNumber)
            {
                matchedVehicle = vehicle;
                vehicleFound = true;
            }
        }
        if (vehicleFound == false)
        {
            Console.WriteLine("Fordonsnumret finns inte i listan.");
            return;
        }

        if (matchedVehicle is not ElectricBicycle)
        {
            Console.WriteLine("Fordonet är inte en elcykel.");
            return;
        }

        if (matchedVehicle.Rented == true)
        {
            Console.WriteLine("Elcykeln är uthyrd och kan inte laddas.");
            return;
        }

        if (matchedVehicle is ElectricBicycle electricBicycle1)
        {
            if (electricBicycle1.BatteryLevel == 100)
            {
                Console.WriteLine("Batteriet är redan fullt.");
                return;
            }
            else
            {
                electricBicycle1.ChargeBattery();
                Console.WriteLine($"Elcykel {electricBicycle1.VehicleNumber} är nu laddad till {electricBicycle1.BatteryLevel}%.");
            }  
        }
    }
}





