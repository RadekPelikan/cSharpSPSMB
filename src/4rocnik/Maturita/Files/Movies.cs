namespace Files
{
    class Movies
    {
        private string _film;
        private string _genere;
        private string _studio;
        private int _audienceScore;
        private double _profit;
        private int _rottenTomatoesScore;
        private double _worldWideGross;
        private int _year;

        public Movies(string film, string genere, string studio, int audienceScore, double profit, int rottenTomatoesScore, double worldWideGross, int year)
        {
            _film = film;
            _genere = genere;
            _studio = studio;
            _audienceScore = audienceScore;
            _profit = profit;
            _rottenTomatoesScore = rottenTomatoesScore;
            _worldWideGross = worldWideGross;
            _year = year;
        }
    }
}