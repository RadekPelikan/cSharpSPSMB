
using System.Text.Json.Serialization;

public record Movie
{
    public string Film { get; set; }
    
    public string Genre { get; set; }
    
    [JsonPropertyName("Lead Studio")]
    public string LeadStudio { get; set; }
    
    [JsonPropertyName("Audience score %")]
    public double AudienceScore { get; set; }
    
    public double Profitability { get; set; }
    
    [JsonPropertyName("Rotten Tomatoes %")]
    public double RottenTomatoes { get; set; }
    
    [JsonPropertyName("Worldwide Gross")]
    public string WorldWideGross { get; set; }
    
    public int Year { get; set; }
}
