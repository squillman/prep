using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace prep.codekata
{
    public class WeatherSpread
    {
        public IList<string> lines { get; set; }

        public WeatherSpread(string filePath)
        {
            lines = new List<string>();
            ReadFileIntoList(filePath);
        }

        public void ReadFileIntoList(string filePath)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
        }
    }
}
