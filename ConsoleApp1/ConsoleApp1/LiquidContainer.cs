namespace ConsoleApp1;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; set; }

    public LiquidContainer(double loadWeight, double containerHeight, double containerWeight,
        double containerDepth, double maxLoad, bool isHazardous) : base("L", loadWeight, containerHeight, containerWeight, containerDepth, maxLoad)
    {
        IsHazardous = isHazardous;
    }

    public override void LoadCargo(double load)
    {
        double limit  = IsHazardous ? MaxLoad * 0.5 : MaxLoad * 0.9;
        if (LoadWeight + load > limit)
        {
            NotifyHazard($"Trying to load too much to {SerialNumber}");
            throw new OverfillException($"Container {SerialNumber} would be overloaded");
        }
        base.LoadCargo(load);
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine("Alert: " + message);
    }
}