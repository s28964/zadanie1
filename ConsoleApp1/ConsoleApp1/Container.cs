namespace ConsoleApp1;

public abstract class Container
{
    private static int _counter = 1;
    public double LoadWeight{ get; set; }
    public double ContainerHeight{ get; set; }
    public double ContainerWeight{ get; set; }
    public double ContainerDepth{ get; set; }
    public string SerialNumber { get; set; }
    public double MaxLoad { get; set; }

    public Container(string type, double loadWeight, double containerHeight, double containerWeight,
        double containerDepth, double maxLoad)
    {
        SerialNumber = $"KON-{type}-{_counter++}";
        LoadWeight = loadWeight;
        ContainerHeight = containerHeight;
        ContainerWeight = containerWeight;
        ContainerDepth = containerDepth;
        MaxLoad = maxLoad;
    }

    public virtual void LoadCargo(double load)
    {
        if (LoadWeight + load > MaxLoad)
        {
            throw new OverfillException($"Container {SerialNumber} would be overloaded");
        }
        LoadWeight += load;
    }

    public virtual void UnloadCargo()
    {
        LoadWeight = 0;
    }
}