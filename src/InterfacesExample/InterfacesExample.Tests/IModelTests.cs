namespace InterfacesExample.Tests;

public class IModelTests
{
    [Fact]
    public void ModifyingNameOnCarModel_ShouldChangeDateModified()
    {
        // Arrange
        IModel model = new CarModel("superb", "skoda");
        DateTime dateBefore = model.DateModified;
        
        // Act
        model.Name = "superb 2";
        DateTime dateAfter = model.DateModified;

        // Assert
        Assert.NotEqual(dateBefore, dateAfter);
    }

    [Fact]
    public void ModifyingNameOnRocketModel_ShouldChangeDateModified()
    {
        // Arrange
        IModel model = new RocketModel("Nasa", 5);
        DateTime dateBefore = model.DateModified;
        
        // Act
        model.Name = "Nasa 2";
        DateTime dateAfter = model.DateModified;

        // Assert
        Assert.NotEqual(dateBefore, dateAfter);
    }
}