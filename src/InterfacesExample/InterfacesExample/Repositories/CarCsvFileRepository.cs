namespace InterfacesExample;

public class CarCsvFileRepository : ICarRepository
{
    private string CsvPath = "cars.csv";
    private string DeletedCsvPath = "deletedcars.csv";

    public CarCsvFileRepository()
    {
        if (!File.Exists(CsvPath))
        {
            File.Create(CsvPath);
        }
        if (!File.Exists(DeletedCsvPath))
        {
            File.Create(DeletedCsvPath);
        }
    }
    
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

    private void SaveCsv(List<CarModel> lines, string path)
    {
        StreamWriter streamWriter = new StreamWriter(path);
        if(path.Equals(CsvPath)) streamWriter.WriteLine("id,name,brand,dateCreate,dateModified");
        else streamWriter.WriteLine("id,name,brand,dateDelete,dateModified");
        foreach (CarModel model in lines)
        {
            string line = "";
            line = $"{model.Id},{model.Name},{model.Brand},{model.DateCreate.ToString()},{model.DateModified.ToString()}";
            streamWriter.WriteLine(line);
        }
        streamWriter.Close();
    }
    
    public List<CarModel> Get()
    {
        List<CarModel> models = new List<CarModel>();
        List<String> lines = File.ReadLines(CsvPath).ToList();
        lines.Remove(lines[0]);
        foreach (string line in lines)
        {
            models.Add(new CarModel(Guid.Parse(LineToList(line)[0]), LineToList(line)[1], LineToList(line)[2], DateTime.Parse(LineToList(line)[3]), DateTime.Parse(LineToList(line)[4])));
        }
        
        return models;
    }
    
    private List<CarModel> GetDeleted()
    {
        List<CarModel> models = new List<CarModel>();
        List<String> lines = File.ReadLines(DeletedCsvPath).ToList();
        if(lines.Count > 0) lines.Remove(lines[0]);
        foreach (string line in lines)
        {
            models.Add(new CarModel(Guid.Parse(LineToList(line)[0]), LineToList(line)[1], LineToList(line)[2], DateTime.Parse(LineToList(line)[3]), DateTime.Parse(LineToList(line)[4])));
        }
        
        return models;
    }

    public void Insert(CarModel model)
    {
        List<CarModel> list = Get();
        list.Add(model);
        model.DateModified = DateTime.Now;
        SaveCsv(list, CsvPath);
    }

    public void Update(CarModel model)
    {
        int size = RecordSize();
        Delete(model.Id);
        if (RecordSize() < size)
        {
            Insert(model);
        }
    }

    public void Delete(Guid id)
    {
        CarModel toDelete = Get(id);
        if (toDelete != null)
        {
            List<CarModel> list = Get();
            list.Remove(GetModelFromList(id, list));
            SaveCsv(list, CsvPath);
            
            List<CarModel> deletedList = GetDeleted();
            deletedList.Add(toDelete);
            toDelete.DateCreate = DateTime.Now;
            SaveCsv(deletedList, DeletedCsvPath);
        }
    }

    private CarModel GetModelFromList(Guid id, List<CarModel> list)
    {
        foreach (var carModel in list)
        {
            if (carModel.Id.Equals(id)) return carModel;
        }

        return null;
    }

    public int RecordSize()
    {
        return Get().Count;
    }
}