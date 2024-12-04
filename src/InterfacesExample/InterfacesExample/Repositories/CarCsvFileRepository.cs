namespace InterfacesExample;

public class CarCsvFileRepository : ICarRepository
{
    private string CsvPath = "cars.csv";
    
    public CarModel Get(Guid id)
    {
        List<CarModel> models = Get();
        foreach (CarModel model in models)
        {
            if (model.Id.ToString().Equals(id.ToString()))
            {
                return model;
            }
        }
        
        return null;
    }

    private List<string> LineToList(string line)
    {
        return new List<string>(line.Split(","));
    }

    private void SaveCsv(List<string> lines)
    {
        StreamWriter streamWriter = new StreamWriter(CsvPath);
        foreach (string line in lines)
        {
            
        }
    }

    public List<CarModel> Get()
    {
        List<CarModel> models = new List<CarModel>();
        foreach (string line in File.ReadLines(CsvPath))
        {
            models.Add(new CarModel(Guid.Parse(LineToList(line)[0]), LineToList(line)[1], LineToList(line)[2]));
        }
        
        return models;
    }

    public void Insert(CarModel model)
    {
        throw new NotImplementedException();
    }

    public void Update(CarModel model)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public int RecordSize()
    {
        throw new NotImplementedException();
    }
}