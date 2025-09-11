namespace Files
{
    class Movies
    {
        public string film;
        public string genere;
        public string studio;
        public int audienceScore;
        public double profit;
        public int rottenTomatoes;
        public double worldwideGross;
        public int year;

        public Movies(string film, string genere, string studio, int audienceScore, double profit, int rottenTomatoes, double worldwideGross, int year)
        {
            this.film = film;
            this.genere = genere;
            this.studio = studio;
            this.audienceScore = audienceScore;
            this.profit = profit;
            this.rottenTomatoes = rottenTomatoes;
            this.worldwideGross = worldwideGross;
            this.year = year;
        }
    }
}