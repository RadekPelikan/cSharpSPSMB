namespace InterfacesExample;


public class CarRepository : IRespository<CarModel>
{
    public List<CarModel> Allcars = new List<CarModel>();
    public CarModel? Get(Guid Id)
    {
        foreach (var car in Allcars)
        {
            if (car.Id == Id) return car;
        }

        return null;

    }

    public List<CarModel> Get()
    {
        return Allcars;
    }

    public void Insert(CarModel model)
    { 
        if(model != null) Allcars.Add(model);
    }

    public void Update(CarModel model)
    {
       CarModel car = Allcars.Single(car => car.Id == model.Id);
       car.Name = model.Name;
       car.Brand = model.Brand;

    }

    public void Delete(Guid Id)
    {
        Allcars.Remove(Get(Id));
    }

    public int RecordCount()
    {
        return Allcars.Count();
    }
}