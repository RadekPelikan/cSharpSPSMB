using InterfacesExample;

CarCsvFileRepository carCsvFileRepository = new CarCsvFileRepository();
carCsvFileRepository.Delete(Guid.Parse("2b1b2218-2231-4d31-bbd6-f5e3c090ca04"));
//carCsvFileRepository.Insert(new CarModel("Testt", "twqetw"));
List<CarModel> models = carCsvFileRepository.Get();
foreach (var carModel in models)
{
    Console.WriteLine(carModel.ToString());
}
