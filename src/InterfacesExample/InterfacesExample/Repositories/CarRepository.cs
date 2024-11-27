namespace InterfacesExample;

public class CarRepository : IRespository<CarModel>
{
    public List<CarModel> allCars = new List<CarModel>();
    public CarModel? Get(Guid id)
    {
        foreach (var car in allCars)
        {
            if (car.Id == id) return car;
            
        }
        return null;
    }

    public List<CarModel> Get()
    {
        return allCars;
    }

    public void Insert(CarModel model)
    {
        if (model != null)
        {
            allCars.Add(model);
        }
        
    }

    public void Update(CarModel model)
    {
        CarModel car = allCars.Single(car => car.Id == model.Id);
        car.Name = model.Name;
        car.Brand = model.Brand;
    }

    public void Delete(Guid Id)
    {
        CarModel model = Get(Id);
        allCars.Remove(model);
    }

    public int RecordCount()
    {
        return allCars.Count();
        
    }
}