namespace ConsoleApp1;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; set; }

    public GasContainer(double loadWeight, double containerHeight, double containerWeight,
        double containerDepth, double maxLoad, double pressure) : base("G", loadWeight, containerHeight,
        containerWeight, containerDepth, maxLoad)
    {
        Pressure = pressure;
    }

    public override void LoadCargo(double load)
    {
        if (LoadWeight + load > MaxLoad)
        {
            NotifyHazard($"Trying to load too much to {SerialNumber}");
            throw new OverfillException($"Container {SerialNumber} would be overloaded");
        }
        base.LoadCargo(load);
    }

    public override void UnloadCargo()
    {
        LoadWeight *= 0.05;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine("Alert: " + message);
    }
}