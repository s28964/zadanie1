// See https://aka.ms/new-console-template for more information

using ConsoleApp1;

var liquidContainer1 = new LiquidContainer(0, 200, 1500,400,9000, true);
var liquidContainer2 = new LiquidContainer(0, 300, 2000,500,10000, false);

var gasContainer1 = new GasContainer(0, 250, 3500, 300, 7000, 10);
var gasContainer2 = new GasContainer(0, 350, 4500, 400, 8000, 20);
var gasContainer3 = new GasContainer(0, 350, 4500, 400, 8000, 20);

var refrigeratedContainer1 = new RefrigeratedContainer(0, 300, 2500, 400, 12000, "Butter", 21);
var refrigeratedContainer2 = new RefrigeratedContainer(0, 400, 3000, 450, 15000, "Fish", 5);

var cargoShip1 = new CargoShip("Cheetah", 40, 3, 15000);
var cargoShip2 = new CargoShip("Elephant", 15, 8, 1200000);

liquidContainer1.LoadCargo(3000);
liquidContainer2.LoadCargo(4000);

gasContainer1.LoadCargo(5000);
gasContainer2.LoadCargo(6000);
gasContainer3.LoadCargo(1000);

gasContainer1.UnloadCargo();
Console.WriteLine($"Number: {gasContainer1.SerialNumber}, LoadWeight: {gasContainer1.LoadWeight}, ContainerWeight: {gasContainer1.ContainerWeight}, ContainerHeight: {gasContainer1.ContainerHeight}, ContainerDepth: {gasContainer1.ContainerDepth}, MaxLoad: {gasContainer1.MaxLoad}");

refrigeratedContainer1.LoadCargo(6500, "Butter");
refrigeratedContainer2.LoadCargo(7000, "Fish");

cargoShip1.LoadContainer(liquidContainer1);
cargoShip1.LoadContainer(refrigeratedContainer2);
//cargoShip1.LoadContainer(gasContainer3);

cargoShip2.LoadContainer(gasContainer1);

var listOfContainers = new List<Container>{liquidContainer2, refrigeratedContainer1};
cargoShip2.LoadContainers(listOfContainers);

Console.WriteLine("Ship 1: ");
cargoShip1.PrintInfo();
Console.WriteLine("Ship 2: ");
cargoShip2.PrintInfo();

cargoShip1.RemoveContainer(liquidContainer1.SerialNumber);
cargoShip2.RemoveContainer(gasContainer1.SerialNumber);

liquidContainer2.UnloadCargo();

cargoShip2.ReplaceContainer(refrigeratedContainer1.SerialNumber, gasContainer2);

cargoShip1.TransferContainer(cargoShip2, refrigeratedContainer2.SerialNumber);

Console.WriteLine("refrigeratedContainer2 info: ");
Console.WriteLine($"Number: {refrigeratedContainer2.SerialNumber}, LoadWeight: {refrigeratedContainer2.LoadWeight}, ContainerWeight: {refrigeratedContainer2.ContainerWeight}, ContainerHeight: {refrigeratedContainer2.ContainerHeight}, ContainerDepth: {refrigeratedContainer2.ContainerDepth}, MaxLoad: {refrigeratedContainer2.MaxLoad}");

Console.WriteLine("Ship 1: ");
cargoShip1.PrintInfo();
Console.WriteLine("Ship 2: ");
cargoShip2.PrintInfo();