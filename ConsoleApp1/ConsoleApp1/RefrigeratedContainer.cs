namespace ConsoleApp1;

public class RefrigeratedContainer : Container
{
    public string ProductType { get; set; }
    public double Temperature { get; set; }
    private static Dictionary<String, double> _productTemperature = new Dictionary<String, double>
    {
        {"Bananas", 13.3}, {"Chocolate", 18}, {"Fish", 2}, {"Meat", -15},
        {"Ice cream", -18}, {"Frozen pizza", -30}, {"Cheese", 7.2},
        {"Sausages", 5}, {"Butter", 20.5}, {"Eggs", 19}
    };

    public RefrigeratedContainer(double loadWeight, double containerHeight, double containerWeight,
        double containerDepth, double maxLoad, string productType, double temperature) : base("C", loadWeight,
        containerHeight, containerWeight, containerDepth, maxLoad)
    {
        if (!_productTemperature.ContainsKey(productType))
        {
            throw new Exception("Invalid product type");
        }
        if (_productTemperature.ContainsKey(productType) && temperature < _productTemperature[productType])
        {
            throw new Exception($"Temperature for {productType} is too low");
        }
        ProductType = productType;
        Temperature = temperature;
    }

    public void LoadCargo(double load, string product)
    {
        if (LoadWeight + load > MaxLoad)
        {
            throw new OverfillException($"Container {SerialNumber} would be overloaded");
        }

        if (LoadWeight == 0)
        {
            ProductType = product;
        }
        
        else if (ProductType != product)
        {
            throw new Exception($"Container {SerialNumber} can only contain {ProductType}");
        }
        LoadWeight += load;
    }
}