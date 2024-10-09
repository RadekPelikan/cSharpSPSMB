using System;
using System.IO;

namespace FileLibrary
{
    public class CsvParser
    {
        public CsvParser(string path)
        {
            this.path = path;
        }

        private string path = "./res/movies.csv";

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
