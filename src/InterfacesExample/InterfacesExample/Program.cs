using InterfacesExample;

IModel model;

// model = new CarModel("superb", "skoda");
model = new RocketModel("superb", 161);

// Console.WriteLine(model.Describe());


if (model is CarModel)
{
    Console.WriteLine("Model is a car!");
}
else if (model is RocketModel)
{
    Console.WriteLine("Model is a rocket!");
}
