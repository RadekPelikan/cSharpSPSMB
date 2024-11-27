namespace InterfacesExample.Tests;

public class CarRepositoryTests
{
    [Fact]
    public void InsertingNewModel_ShouldIncreaseRecordCount()
    {
        //Arrange
        CarRepository _respository = new CarRepository();
        //Act
        int beforeRecordCountUpdate = _respository.RecordCount();
        _respository.Insert(new CarModel("Idiot", "gej"));
        int afterRecordCountUpdate = _respository.RecordCount();
        //Assert
        Assert.True(beforeRecordCountUpdate < afterRecordCountUpdate);
        Assert.NotEqual(beforeRecordCountUpdate, afterRecordCountUpdate);
    }

    [Fact]
    public void InsertingNull_ShouldSustainRecordCount()
    {
        //Arrange
        CarRepository _respository = new CarRepository();
        //Act
        int beforeRecordCountUpdate = _respository.RecordCount();
        _respository.Insert(null);
        int afterRecordCountUpdate = _respository.RecordCount();
        //Assert
        Assert.Equal(beforeRecordCountUpdate, afterRecordCountUpdate);

    }

    [Fact]
    public void GettingAllRecords_WithTwoRecords_ShouldReturnListOfTwoRecords()
    {
        //Arrange
        CarRepository _respository = new CarRepository();
        
        //Act
        _respository.Insert(new CarModel("a", "a"));
        _respository.Insert(new CarModel("a", "a"));
        //Assert
        Assert.Equal(2, _respository.Get().Count);
        
        
    }

    [Fact]
    public void GettingInsertedRecordWithId_WithTwoRecords_ShouldReturnInsertedRecord()
    {
        //Arrange
        CarRepository _respository = new CarRepository();
        
        //Act
        CarModel carModel = new CarModel("a", "b");
        _respository.Insert(carModel);
        _respository.Insert(new CarModel("b", "b"));
        
        //Assert
       Assert.Equal(carModel, _respository.Get(carModel.Id) );
       
    }

    [Fact]
    public void GettingNotInsertedRecordWithId_WithTwoRecords_ShouldReturnNull()
    {
        //Arrange
        CarRepository _respository = new CarRepository();
        //Act 
        CarModel fejk = new CarModel("null", "null");
        
        _respository.Insert(new CarModel("b", "b"));
        //Assert
        Assert.Null(_respository.Get(fejk.Id));
    }
    
    [Fact]
    public void UpdatingModel_ShouldBeUpdated()
    {
        //Arrange
        CarRepository _respository = new CarRepository();
        CarModel wantModel = new CarModel("a", "a");
        _respository.Insert(wantModel);

        // Act
        CarModel updateCar = _respository.Get(wantModel.Id)!;
        updateCar.Name = "Bohata";
        updateCar.Brand = "Bohata";
        _respository.Update(updateCar);
       

        //Assert
        
        Assert.Equal(wantModel.Brand, updateCar.Brand);
        Assert.Equal(wantModel.Name, updateCar.Name );
    }
    [Fact]
    public void DeletingModel_ShouldBeDeleted()
    {
        //Arrange
        CarRepository respository = new CarRepository();
        CarModel wantModel = new CarModel("a", "a");
        respository.Insert(wantModel);
        
        //Act 
        int countBeforeDelete = respository.RecordCount();
        respository.Delete(wantModel.Id);
        int countAfterDelete = respository.RecordCount();
       
        
        //Assert
        Assert.True(countBeforeDelete > countAfterDelete);
        
    }   
    [Fact]
    public void DeletingModelThatIsNull_ShouldReturnNull()
    {
        //Arrange
        CarRepository respository = new CarRepository();
        CarModel fejk = new CarModel("a", "a");
        
        //Act 
        int countBeforeDelete = respository.RecordCount();
        respository.Delete(fejk.Id);
        int countAfterDelete = respository.RecordCount();
        //Assert
        Assert.Equal(countBeforeDelete, countAfterDelete);
        
    }
    
}