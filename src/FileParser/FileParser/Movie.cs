using FileParser;

class Movie
{
    public string Film;
    public string Genre;
    public string LeadStudio;
    public double AudienceScore;
    public double Profitability;
    public int rating;
    public Currency WorldwideGross;
    public int Year;

    public Movie(string film, string genre, string leadStudio, double audienceScore, double profitability, int rating, Currency worldwideGross, int year)
    {
        Film = film;
        Genre = genre;
        LeadStudio = leadStudio;
        AudienceScore = audienceScore;
        Profitability = profitability;
        this.rating = rating;
        WorldwideGross = worldwideGross;
        Year = year;
    }
}