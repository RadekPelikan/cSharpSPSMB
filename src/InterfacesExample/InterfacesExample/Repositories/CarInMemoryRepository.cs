namespace InterfacesExample;

public class CarInMemoryRepository : ICarRepository
{
<<<<<<< HEAD
    private List<CarModel> cars = new List<CarModel>(); 
    
    public CarModel Get(Guid id)
    {
        try
        {
            return cars.Single(car => car.Id == id);
        }
        catch (Exception ex)
        {
            return null;
        }
=======
    private List<CarModel> cars = new List<CarModel>();
    
    public CarModel? Get(Guid Id)
    {
        throw new NotImplementedException();
>>>>>>> 25b611731a041367f68210da246b196610c6a408
    }

    public List<CarModel> Get()
    {
<<<<<<< HEAD
        return cars;
=======
        throw new NotImplementedException();
>>>>>>> 25b611731a041367f68210da246b196610c6a408
    }

    public void Insert(CarModel model)
    {
<<<<<<< HEAD
        cars.Add(model);
=======
        throw new NotImplementedException();
>>>>>>> 25b611731a041367f68210da246b196610c6a408
    }

    public void Update(CarModel model)
    {
<<<<<<< HEAD
        int before = RecordSize();
        Delete(model.Id);
        if (RecordSize() < before)
        {
            cars.Add(model);
        }
    }

    public void Delete(Guid id)
    {
        CarModel toDelete = Get(id);
        if(toDelete != null) cars.Remove(toDelete);
    }

    public int RecordSize()
    {
        int count = cars.Count;
        foreach (var carModel in cars)
        {
            if (carModel == null) count--;
        }
        return count;
=======
        throw new NotImplementedException();
    }

    public void Delete(Guid Id)
    {
        throw new NotImplementedException();
    }

    public int RecordCount()
    {
        throw new NotImplementedException();
>>>>>>> 25b611731a041367f68210da246b196610c6a408
    }
}