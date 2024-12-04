namespace InterfacesExample;

public class CarInMemoryRepository : ICarRepository
{
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
    }

    public List<CarModel> Get()
    {
        return cars;
    }

    public void Insert(CarModel model)
    {
        cars.Add(model);
    }

    public void Update(CarModel model)
    {
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
    }
}