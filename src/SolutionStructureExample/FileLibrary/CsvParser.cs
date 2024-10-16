using System;
using System.Collections.Generic;
using System.IO;

namespace FileLibrary
{
    public class CsvParser
    {
        // properta hasHeader, metoda parseFile
        private bool hasHeader;
        
        public CsvParser(bool hasHeader, string path)
        {
            this.hasHeader = hasHeader;
            this.path = path;
        }

        private string path = "./res/movies.csv";

        private Movie ParseMovie(StreamReader sr)
        {
            string line = sr.ReadLine();

            foreach (var VARIABLE in line)
            {
                
            }
            Movie movie = new Movie();
            
            return movie;

        }
        
        public List<Movie> ParseFile()
        {
            using (StreamReader sr = File.OpenText(path))
            {
                Movie movie = ParseMovie(sr);
            }
            
        }

        public string ReadFile()
        {
            string text = "";
            string line;
            using (StreamReader sr = File.OpenText(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    text += line + '\n';
                    
                }
            }
            return text;
        }
    }
}
