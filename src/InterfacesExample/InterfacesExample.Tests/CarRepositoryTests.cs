namespace InterfacesExample.Tests;

public class CarRepositoryTests
{
    [Fact]
    public void InsertingNewModel_ShouldIncreaseRecordCount()
    {
        //Arrange
        ICarRepository carRepository = new CarRepository();
        int oldCount = carRepository.RecordSize();
        
        //Act
        carRepository.Insert(new CarModel("superb", "skoda"));
        int newCount = carRepository.RecordSize();
        
        //Assert
        Assert.Equal(oldCount + 1, newCount);
    }

    [Fact]
    public void InsertingNull_ShouldSustainRecordCount()
    {
        //Arrange
        ICarRepository carRepository = new CarRepository();
        int oldCount = carRepository.RecordSize();
        
        //Act
        carRepository.Insert(null);
        int newCount = carRepository.RecordSize();
        
        //Assert
        Assert.Equal(oldCount, newCount);
    }

    [Fact]
    public void GettingAllRecords_WithTwoRecords_ShouldReturnListOfTwoRecords()
    {
        //Arrange
        ICarRepository carRepository = new CarRepository();
        List<CarModel> wantedList = new List<CarModel>();
        wantedList.Add(new CarModel("test", "test"));
        wantedList.Add(new CarModel("test", "test"));
        
        //Act
        carRepository.Insert(wantedList[0]);
        carRepository.Insert(wantedList[1]);
        
        //Assert
        Assert.Equal(2, carRepository.Get().Count);
        Assert.Equal(carRepository.Get(wantedList[0].Id), wantedList[0]);
        Assert.Equal(carRepository.Get(wantedList[1].Id), wantedList[1]);
    }

    [Fact]
    public void GettingInsertedRecordWithId_WithTwoRecords_ShouldReturnInsertedRecord()
    {
        //Arrange
        ICarRepository carRepository = new CarRepository();
        CarModel wanted = new CarModel("Wanted", "Wanted");
        
        //Act
        carRepository.Insert(wanted);
        carRepository.Insert(new CarModel("test", "test"));
        
        //Assert
        Assert.Equal(wanted, carRepository.Get(wanted.Id));
    }
    
    [Fact]
    public void GettingNotInsertedRecordWithId_WithTwoRecords_ShouldReturnNull()
    {
        //Arrange
        ICarRepository carRepository = new CarRepository();
        CarModel wanted = new CarModel("Wanted", "Wanted");
        
        //Act
        carRepository.Insert(new CarModel("test", "test"));
        carRepository.Insert(new CarModel("test", "test"));
        
        //Assert
        Assert.Null(carRepository.Get(wanted.Id));
    }
    
    [Fact]
    public void UpdatingModel_ShouldBeChanged()
    {
        //Arrange
        ICarRepository carRepository = new CarRepository();
        CarModel changed = new CarModel("Test", "Test");
        Guid id = changed.Id;
        string before = changed.Name;
        carRepository.Insert(changed);
        
        //Act
        CarModel got = carRepository.Get(id);
        got.Name = "Ahoj";
        carRepository.Update(got);
        
        //Assert
        Assert.NotEqual(before, carRepository.Get(id).Name);
        Assert.Equal(carRepository.Get(id).Name, "Ahoj");
    }

    [Fact]
    public void DeletingModel_ShouldBeDeleted()
    {
        //Arrange
        ICarRepository carRepository = new CarRepository();
        CarModel deleted = new CarModel("Test", "Test");
        
        //Act
        carRepository.Insert(deleted);
        carRepository.Insert(new CarModel("Ahoj", "Ahoj"));
        carRepository.Delete(deleted.Id);
        
        //Assert
        Assert.Equal(1, carRepository.RecordSize());
        Assert.Null(carRepository.Get(deleted.Id));
    }

    [Fact]
    public void DeletingNotInsertedModel_WithTwoRecords_ShouldSustainCount()
    {
        //Arrange
        ICarRepository carRepository = new CarRepository();
        CarModel notInserted = new CarModel("Test", "Test");
        
        //Act
        carRepository.Insert(new CarModel("Ahoj", "Ahoj"));
        carRepository.Insert(new CarModel("Ahoj", "Ahoj"));
        carRepository.Delete(notInserted.Id);
        
        //Assert
        Assert.Equal(2, carRepository.RecordSize());
    }
}