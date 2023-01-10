using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAppLibrary.TextHelpers
{
    public static class TextConnectorProcessor
    {
        public static string FullFilePath(this string fileName)
        {
            return $"{ConfigurationManager.AppSettings["filePath"]}\\{fileName}";
        }
        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            { 
                return new List<string>();
            }
            return File.ReadAllLines(file).ToList();
        }
        public static List<Prize> ConvertToPrize (this List<string> lines)
        {
            List<Prize> output = new List<Prize>();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                Prize p = new Prize();
                p.Id = int.Parse(cols[0]);
                p.Place = int.Parse(cols[1]);
                p.PlaceName = cols[2];
                p.Amount = decimal.Parse(cols[3]);
                p.Percentage = double.Parse(cols[4]);
                output.Add(p);
            }
            return output;
        }
        public static void SaveToPrizesFile(this List<Prize> models, string fileName)
        {
            List<string> lines = new List<string>();
            foreach (Prize prize in models)
            {
                lines.Add($"{prize.Id}, {prize.Place}, {prize.PlaceName}, {prize.Amount}, {prize.Percentage}");
            }
            File.WriteAllLines(fileName.FullFilePath(), lines);
        }
    }
}
