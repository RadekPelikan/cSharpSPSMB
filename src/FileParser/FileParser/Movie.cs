class Movie
{
    public string Film;
    public string Genre;
    public string LeadStudio;
    public double AudienceScore;
    public int Profitability;
    public int rating;
    public int WorldwideGross;
    public int Year;

    public Movie(string film, string genre, string leadStudio, double audienceScore, int profitability, int rating, int worldwideGross, int year)
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