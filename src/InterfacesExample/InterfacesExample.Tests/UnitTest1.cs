namespace InterfacesExample.Tests;

public class UnitTest1
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
        Assert.NotNull(dateBefore);
        Assert.NotNull(dateAfter);
        Assert.True(dateBefore != dateAfter);
        Assert.True(dateAfter > dateBefore);
    }
    
    [Fact]
    public void ModifyingNameOnModelRocket_ShouldChangeDateModified()
    {
        // Arrange
        IModel model = new RocketModel("superb", 10);
        DateTime dateBefore = model.DateModified;
        
        // Act
        model.Name = "superb 2";
        DateTime dateAfter = model.DateModified;
        
        // Assert
        Assert.NotNull(dateBefore);
        Assert.NotNull(dateAfter);
        Assert.True(dateBefore != dateAfter);
        Assert.True(dateAfter > dateBefore);
    }
}