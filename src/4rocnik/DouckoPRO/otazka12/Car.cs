record Car
{
    public string Color {get ; set; }
    public string Brand {get ; set; }
    public string Model {get ; set; }
    public int ProductionYear {get ; set; }
    public int PowerKw { get; set; }

    public void PrintCarProperties()
    {
        // kompilacni reflexe
        // typeof(this);
        // runtime reflexe
        // this.GetType();
        
        var propertyInfos = this.GetType().GetProperties();

        foreach (var propertyInfo in propertyInfos)
        {
            var name = propertyInfo.Name;
            var value = propertyInfo.GetValue(this);

            Console.WriteLine($"{name} = {value}");
        }
    }
}