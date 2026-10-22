

public class Customer
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public bool IsMember { get; private set; }
    public Customer(string name, int age, bool isMember)  
    {
        Name = name;
        Age = age;
        IsMember = isMember;
    }
}
