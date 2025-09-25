public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool IsUSA()
    {
        return _address.IsUSA();
    }

    public string GetDisplayName()
    {
        return _name;
    }

    public string GetDisplayAddress()
    {
        return _address.GetDisplayText();
    }
}