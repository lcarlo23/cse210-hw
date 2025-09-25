public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetOrderTotal()
    {
        double totalCost = 0;

        foreach (Product product in _products)
        {
            totalCost += product.GetTotalCost();
        }

        double shipping = _customer.IsUSA() ? 5 : 35;
        totalCost += shipping;

        return totalCost;
    }

    public string GetDisplayPackingLabel()
    {
        string packingLabel = "";

        foreach (Product product in _products)
        {
            packingLabel += $"""
            {product.GetDisplayId()}: {product.GetDisplayName()}

            """;
        }

        return packingLabel;
    }
    public string GetDisplayShippingLabel()
    {
        string shippingLabel = $"""
        {_customer.GetDisplayName()}
        {_customer.GetDisplayAddress()}

        """;

        return shippingLabel;
    }
}