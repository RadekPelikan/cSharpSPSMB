namespace InterfacesExample;

public class CarCsvFileRepository : ICarRepository
{
    public CarModel? Get(Guid Id)
    {
        throw new NotImplementedException();
    }

    public List<CarModel> Get()
    {
        throw new NotImplementedException();
    }

    public void Insert(CarModel model)
    {
        throw new NotImplementedException();
    }

    public void Update(CarModel model)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid Id)
    {
        throw new NotImplementedException();
    }

    public int RecordCount()
    {
        throw new NotImplementedException();
    }
}