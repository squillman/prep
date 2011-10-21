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
        public IDictionary<string, int> ColumnHeaders { get; set; }

        public WeatherSpread(string filePath)
        {
            lines = new List<string>();
            ColumnHeaders = new Dictionary<string, int>();
            ReadFileIntoList(filePath);
            GetColumns();
        }

        void ReadFileIntoList(string filePath)
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

        void ComputeSpread()
        {
            
        }

        void GetSpread(string rowData, int colIndex)
        {
            string[] colData = rowData.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            int day;
            try
            {
                day = Convert.ToInt32(colData[0]);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Line is not specific to a day");
            }

        }
    }
}
