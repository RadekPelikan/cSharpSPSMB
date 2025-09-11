using System;
using System.Globalization;

namespace Files
{
    public class Movie
    {
        //Film,Genre,Lead Studio,Audience score %,Profitability,Rotten Tomatoes %,Worldwide Gross,Year
        
        public string FilmName { get; set; }
        public string Genre { get; set; }
        public string LeadStudio { get; set; }
        public string AudienceScore { get; set; }
        public decimal Profitability { get; set; }
        public int RottenTomatoes { get; set; }
        public decimal WorldwideGross { get; set; }
        public int Year { get; set; }

        public Movie(string line)
        {
            var values = line.Split(',');
            FilmName = values[0];
            Genre = values[1];
            LeadStudio = values[2];
            AudienceScore = values[3];
            Profitability = parseDecimal(values[4]);
            RottenTomatoes = parseNumber(values[5]);
            WorldwideGross = parseGroossIncome(values[6]);
            Year = parseNumber(values[7]);
        }
        
        public int parseNumber(string number)
        {
            number = number.Trim();
            bool isNumber = int.TryParse(number, out int result);
            if (!isNumber) return 0;
            return result;
        }
        public decimal parseDecimal(string number)
        {
            number = number.Trim();
            bool isNumber = decimal.TryParse(number, NumberStyles.AllowDecimalPoint, CultureInfo.GetCultureInfo("en-Us"), out decimal result);
            if (!isNumber) return 0;
            return result;
        }
        public decimal parseGroossIncome(string number)
        {
            string onlyNumber = number.Substring(1);
            decimal parsedNum = parseDecimal(onlyNumber);
            return parsedNum;
        }
        
    }
}