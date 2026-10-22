

public class Rental
{
    public Customer  Customer { get; private set; }
    public Vehicle Vehicle { get; private set; }
    public int Hours { get; set; }
    public Rental(Customer customer, Vehicle vehicle, int hours)
    {
        Customer = customer;
        Vehicle = vehicle;
        Hours = hours;
    }
    public decimal CalculateBasePrice()
    {
        return Vehicle.CalculateBasePrice(Hours);
    }
    public decimal CalculateDiscount()
    {
        if(Customer.IsMember == true)
        {
            return CalculateBasePrice() * 0.10m;
        }
        else
        {
            return 0m;
        }
    }
    public decimal CalculateFinalPrice()
    {
        decimal totalPrice = CalculateBasePrice() - CalculateDiscount();
        return totalPrice;
    }
}
