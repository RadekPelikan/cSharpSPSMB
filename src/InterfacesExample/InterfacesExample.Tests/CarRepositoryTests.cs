namespace InterfacesExample.Tests;

public class CarRepositoryTests
{
    [Fact]
    public void InsertingNewModel_ShouldIncreaseRecordCount()
    {
        //arrange
        CarRepository carRepository = new CarRepository();
        int beforeChange = carRepository.RecordCount();
        //act
        carRepository.Insert(new CarModel("car_name", "car_brand"));
        int afterChange = carRepository.RecordCount();
        //assert
        Assert.NotEqual(beforeChange, afterChange);
    }

    [Fact]
    public void InsertingNull_ShouldSustainRecordCount()
    {
        //arrange
        CarRepository carRepository = new CarRepository();
        int beforeChange = carRepository.RecordCount();
        //act
        carRepository.Insert(null);
        int afterChange = carRepository.RecordCount();
        //assert
        Assert.Equal(beforeChange, afterChange);
    }

    [Fact]
    public void GettingAllRecords_WithTwoRecords_ShouldReturnListOfTwoRecords()
    {
        //arrange
        CarRepository carRepository = new CarRepository();
        //act
        carRepository.Insert(new CarModel("car_name1", "car_brand1"));
        carRepository.Insert(new CarModel("car_name2", "car_brand2"));
        //assert
        Assert.True(carRepository.Get().Count() == 2);
    }

    [Fact]
    public void GettingInsertedRecordWithId_WithTwoRecords_ShouldReturnInsertedRecord()
    {
        //arrange
        CarRepository carRepository = new CarRepository();
        //act
        CarModel carModel = new CarModel("car_name1", "car_brand1");
        carRepository.Insert(carModel);
        carRepository.Insert(new CarModel("car_name2", "car_brand2"));
        //assert
        Assert.Equal(carModel, carRepository.Get(carModel.Id));
    }

    [Fact]
    public void GettingNotInsertedRecordWithId_WithTwoRecords_ShouldReturnNull()
    {
        //arrange
        CarRepository carRepository = new CarRepository();
        //act
        CarModel fakeCar = new CarModel("car_nameFake", "car_brandFake");
        carRepository.Insert(new CarModel("car_name1", "car_brand1"));
        carRepository.Insert(new CarModel("car_name2", "car_brand2"));
        //assert
        Assert.Null(carRepository.Get(fakeCar.Id));
    }

    [Fact]
    public void UpdateNameRecord_ShouldReturnUpdatedName()
    {
        //arrange
        string updatedName = "FortniteCar";
        
        CarRepository carRepository = new CarRepository();
        CarModel originalCar = new CarModel("car_name1", "car_brand1");
        carRepository.Insert(originalCar);
        
        //act
        CarModel updateCar = carRepository.Get(originalCar.Id)!;
        updateCar.Name = updatedName;
        carRepository.Update(updateCar);
        
        //assert
        Assert.Equal(updatedName, carRepository.Get(originalCar.Id)!.Name);
    }

    [Fact]
    public void UpdateBrandRecord_ShouldReturnUpdatedBrand()
    {
        //arrange
        string updatedBrand = "FortniteBrand";
        CarRepository carRepository = new CarRepository();
        CarModel originalCar = new CarModel("car_name1", "car_brand1");
        carRepository.Insert(originalCar);
        
        //act
        CarModel updateCar = carRepository.Get(originalCar.Id)!;
        updateCar.Brand = updatedBrand;
        carRepository.Update(updateCar);
        
        //assert
        Assert.Equal(updatedBrand, carRepository.Get(originalCar.Id)!.Brand);
    }

    [Fact]
    public void DeleteRecordWithId_ShouldDeleteRecord()
    {
        //arrange
        CarRepository carRepository = new CarRepository();
        CarModel car = new CarModel("car_name1", "car_brand1");
        carRepository.Insert(car);
        //act
        int carLengthBeforeDelete = carRepository.RecordCount(); 
        carRepository.Delete(car.Id);
        int carLengthAfterDelete = carRepository.RecordCount();
        //Assert
        Assert.True(carLengthBeforeDelete > carLengthAfterDelete);
    }
    
    [Fact]
    public void DeleteNullRecordWithId_ShouldKeepRecordCountSame()
    {
        //arrange
        CarRepository carRepository = new CarRepository();
        CarModel fakeCar = new CarModel("evil_name1", "evil_brand1");
        //act
        int carLengthBeforeDelete = carRepository.RecordCount(); 
        carRepository.Delete(fakeCar.Id);
        int carLengthAfterDelete = carRepository.RecordCount();
        //Assert
        Assert.Equal(carLengthBeforeDelete , carLengthAfterDelete);
    }
}