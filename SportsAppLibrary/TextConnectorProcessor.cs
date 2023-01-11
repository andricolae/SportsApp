using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
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

        public static List<Person> ConvertToPerson (this List<string> lines)
        {
            List<Person> output = new List<Person>();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                Person person = new Person();
                person.Id = int.Parse(cols[0]);
                person.FirstName = cols[1];
                person.Email = cols[2];
                person.Email = cols[3];
                person.Phone = cols[4];
                output.Add(person);
            }
            return output;
        }

        public static void SaveToPersonFile(this List<Person> models, string fileName)
        {
            List<string> lines = new List<string>();
            foreach (Person person in models)
            {
                lines.Add($"{person.Id}, {person.FirstName}, {person.LastName}, {person.Email}, {person.Phone}");
                File.WriteAllLines(fileName.FullFilePath(), lines);
            }
        }

        public static List<Team> ConvertToTeam (this List<string> lines, string peopleFileName)
        {
            List<Team> output = new List<Team>();
            List<Person> person = peopleFileName.FullFilePath().LoadFile().ConvertToPerson();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                Team team = new Team();
                team.Id = int.Parse(cols[0]);
                team.TeamName = cols[1];

                string[] personId = cols[2].Split('|');

                foreach (string id in personId)
                {
                    team.TeamMembers.Add(person.Where(x => x.Id == int.Parse(id)).First());
                }
            }
            return output;
        }

        public static void SaveToTeamFile(this List<Team> models, string fileName)
        {
            List<string> lines = new List<string>();
            foreach (Team team in models)
            {
                lines.Add($"{team.Id}, {team.TeamName}, {ConvertPeopleToString(team.TeamMembers)}");
            }
            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        private static string ConvertPeopleToString(List<Person> persons)
        {
            string output = "";
            if (persons.Count == 0)
            {
                return "";
            }
            foreach (Person person in persons)
            {
                output += $"{person.Id} | ";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
    }
}
