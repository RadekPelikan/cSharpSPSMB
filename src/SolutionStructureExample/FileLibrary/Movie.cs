using System.Reflection.Emit;

namespace FileLibrary
{
    public class Movie
    {
        public string Film;
        private string Genre;
        private string LeadStudio;
        private string Audiencescore;
        private string Profitability;
        private string RottenTomatoes;
        private string WorldwideGross;
        private int Year;

        public Movie(string film, string genre, string leadStudio, string audiencescore, string profitability, string rottenTomatoes, string worldwideGross, int year)
        {
            Film = film;
            Genre = genre;
            LeadStudio = leadStudio;
            Audiencescore = audiencescore;
            Profitability = profitability;
            RottenTomatoes = rottenTomatoes;
            WorldwideGross = worldwideGross;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Film,10} | {Genre,10} | {Year,10}";
        }
    }
}