namespace ConsoleApp1;

public class CargoShip
{
    public string Name { get; set; }
    private List<Container> _containers = new List<Container>();
    public double MaxSpeed { get; set; }
    public int MaxContainers { get; set; }
    public double MaxWeight { get; set; }

    public CargoShip(string name, double maxSpeed, int maxContainers, double maxWeight)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
        MaxWeight = maxWeight;
    }

    public void LoadContainer(Container container)
    {
        if (_containers.Count >= MaxContainers)
        {
            throw new Exception("The ship has reached the maximum number of containers.");
        }

        if (TotalWeight() + container.ContainerWeight + container.LoadWeight > MaxWeight)
        {
            throw new Exception("The ship has reached the maximum weight.");
        }
        _containers.Add(container);
    }

    public void LoadContainers(List<Container> newContainers)
    {
        foreach (var container in newContainers)
        {
            LoadContainer(container);
        }
    }

    public void ReplaceContainer(string serialNumber, Container newContainer)
    {
        RemoveContainer(serialNumber);
        LoadContainer(newContainer);
    }

    public void UnloadContainer(string serialNumber)
    {
        var container = _containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            container.UnloadCargo();
        }
    }

    public void TransferContainer(CargoShip newCargoShip, string serialNumber)
    {
        var container = _containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container == null)
        {
            throw new Exception("Cannot find container");
        }
        RemoveContainer(serialNumber);
        newCargoShip.LoadContainer(container);
    }

    public void RemoveContainer(string serialNumber)
    {
        var container = _containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            _containers.Remove(container);
        }
    }

    public double TotalWeight()
    {
        return _containers.Sum(c => c.ContainerWeight + c.LoadWeight);
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Ship: {Name}, Max Speed: {MaxSpeed}, Max Containers: {MaxContainers}, Max Weight: {MaxWeight}");
        Console.WriteLine("Containers on the ship:");
        foreach (var c in _containers)
        {
            Console.WriteLine($" - {c.SerialNumber} (Weight: {c.ContainerWeight + c.LoadWeight} kg)");
        }
    }
}