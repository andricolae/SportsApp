using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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
                lines.Add($"{prize.Id},{prize.Place},{prize.PlaceName},{prize.Amount},{prize.Percentage}");
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
                lines.Add($"{person.Id},{person.FirstName},{person.LastName},{person.Email},{person.Phone}");
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
                output.Add(team);
            }
            return output;
        }

        public static void SaveToTeamFile(this List<Team> models, string fileName)
        {
            List<string> lines = new List<string>();
            foreach (Team team in models)
            {
                lines.Add($"{team.Id},{team.TeamName},{ConvertPeopleToString(team.TeamMembers)}");
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
                output += $"{person.Id}|";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }

        public static List<Tournament> ConvertToTournament(this List<string> lines, string teamFileName, string peopleFileName, string prizeFileName)
        {
            List<Tournament> output = new List<Tournament>();
            List<Team> teams = teamFileName.FullFilePath().LoadFile().ConvertToTeam(peopleFileName);
            List<Prize> prizes = prizeFileName.FullFilePath().LoadFile().ConvertToPrize();
            List<Matchup> matchups = GlobalConfiguration.MATCHUPFILE.FullFilePath().LoadFile().ConvertToMatchup();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                Tournament tournament = new Tournament();
                tournament.Id = int.Parse(cols[0]);
                tournament.TournamentName = cols[1];
                tournament.Fee = double.Parse(cols[2]);

                if (cols[3].Length > 0)
                {
                    string[] teamId = cols[3].Split('|');
                    foreach (string id in teamId)
                    {
                        tournament.Teams.Add(teams.Where(x => x.Id == int.Parse(id)).First());
                    } 
                }

                if (cols[4].Length > 0)
                {
                    string[] prizeId = cols[4].Split('|');
                    foreach (string id in prizeId)
                    {
                        tournament.Prizes.Add(prizes.Where(x => x.Id == int.Parse(id)).First());
                    } 
                }

                if (cols[5].Length > 0)
                {
                    string[] rounds = cols[5].Split('|');
                    foreach (string round in rounds)
                    {
                        string[] msText = round.Split('^');
                        List<Matchup> ms = new List<Matchup>();
                        foreach (string matchupTextId in msText)
                        {
                            ms.Add(matchups.Where(x => x.Id == int.Parse(matchupTextId)).First());
                        }
                        tournament.Rounds.Add(ms);
                    } 
                }
                output.Add(tournament);
            }
            return output;
        }

        private static string ConvertTeamToString(List<Team> teams)
        {
            string output = "";
            if (teams.Count == 0)
            {
                return "";
            }
            foreach (Team team in teams)
            {
                output += $"{team.Id}|";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
        private static string ConvertMatchupEntryToString(List<MatchupEntry> matchupEntries)
        {
            string output = "";
            if (matchupEntries.Count == 0)
            {
                return "";
            }
            foreach (MatchupEntry me in matchupEntries)
            {
                output += $"{me.Id}|";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
        private static string ConvertPrizeToString(List<Prize> prizes)
        {
            string output = "";
            if (prizes.Count == 0)
            {
                return "";
            }
            foreach (Prize prize in prizes)
            {
                output += $"{prize.Id}|";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
        private static string ConvertMatchupToString(List<Matchup> matchups)
        {
            string output = "";
            if (matchups.Count == 0)
            {
                return "";
            }
            foreach (Matchup matchup in matchups)
            {
                output += $"{matchup.Id}^";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
        private static string ConvertRoundToString(List<List<Matchup>> rounds)
        {
            string output = "";
            if (rounds.Count == 0)
            {
                return "";
            }
            foreach (List<Matchup> round in rounds)
            {
                output += $"{ConvertMatchupToString(round)}|";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }

        public static void SaveToTournamentFile(this List<Tournament> models, string fileName)
        {
            List<string> lines = new List<string>();
            foreach (Tournament tournament in models)
            {
                lines.Add($@"{tournament.Id},{tournament.TournamentName},{tournament.Fee},{ConvertTeamToString(tournament.Teams)},{ConvertPrizeToString(tournament.Prizes)},{ConvertRoundToString(tournament.Rounds)}");
            }
            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static List<MatchupEntry> ConvertToMatchupEntry(this List<string> lines)
        {
            List<MatchupEntry> output = new List<MatchupEntry>();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                MatchupEntry m = new MatchupEntry();
                m.Id = int.Parse(cols[0]);
                if (cols[1].Length == 0)
                {
                    m.Team = null;
                }
                else
                {
                    m.Team = FindTeamById(int.Parse(cols[1]));
                }
                m.Score = double.Parse(cols[2]);

                int parentId = 0;
                if (int.TryParse(cols[3], out parentId))
                {
                    m.ParentMatchup = FindMatchupById(parentId);
                }
                else
                {
                    m.ParentMatchup = null;
                }
                output.Add(m);
            }
            return output;
        }
        private static List<MatchupEntry> ConvertStringToMatchupEntry(string input)
        {
            string[] ids = input.Split('|');
            List<MatchupEntry> output = new List<MatchupEntry>();
            List<string> entries = GlobalConfiguration.MATCHUPENTRYFILE.FullFilePath().LoadFile();
            List<string> matchingEntries = new List<string>();

            foreach(string id in ids)
            {
                foreach (string entry in entries)
                {
                    string[] cols = entry.Split(',');
                    if (cols[0] == id)
                    {
                        matchingEntries.Add(entry);
                    }
                }
            }
            output = matchingEntries.ConvertToMatchupEntry();
            return output;
        }
        private static Team FindTeamById(int id)
        {
            List<string> teams = GlobalConfiguration.TEAMSFILE.FullFilePath().LoadFile();
            foreach (string team in teams)
            {
                string[] cols = team.Split(',');
                if (cols[0] == id.ToString())
                {
                    List<string> matchingTeams = new List<string>();
                    matchingTeams.Add(team);
                    return matchingTeams.ConvertToTeam(GlobalConfiguration.PERSONSFILE).First();
                }
            }
            return null;
        }
        private static Matchup FindMatchupById(int id)
        {
            List<string> matchups = GlobalConfiguration.MATCHUPFILE.FullFilePath().LoadFile();
            foreach (string match in matchups)
            {
                string[] cols = match.Split(',');
                if (cols[0] == id.ToString())
                {
                    List<string> matchingMatchups = new List<string>();
                    matchingMatchups.Add(match);
                    return matchingMatchups.ConvertToMatchup().First();
                }
            }
            return null;
        }
        public static List<Matchup> ConvertToMatchup(this List<string> lines)
        {
            List<Matchup> output = new List<Matchup>();
            foreach (string line in lines)
            {
                string[] cols = line.Split(',');
                Matchup p = new Matchup();

                p.Id = int.Parse(cols[0]);
                p.Entries = ConvertStringToMatchupEntry(cols[1]);
                if (cols[2].Length == 0)
                {
                    p.Winner = null;
                }
                else
                {
                    p.Winner = FindTeamById(int.Parse(cols[2]));
                }
                p.MatchupRound = int.Parse(cols[3]);
                output.Add(p);
            }
            return output;
        }
        public static void SaveToMatchupFile(this Matchup match, string matchupFile, string matchupEntryFile)
        {
            List<Matchup> matchups = GlobalConfiguration.MATCHUPFILE.FullFilePath().LoadFile().ConvertToMatchup();
            int currentId = 1;
            if (matchups.Count > 0)
            {
                currentId = matchups.OrderByDescending(x => x.Id).First().Id + 1;
            }
            match.Id = currentId;
            matchups.Add(match);

            foreach (MatchupEntry entry in match.Entries)
            {
                entry.SaveToEntryFile(matchupEntryFile);
            }
            List<string> lines = new List<string>();
            foreach (Matchup m in matchups)
            {
                string winner = "";
                if (m.Winner != null)
                {
                    winner = m.Winner.Id.ToString();
                }
                lines.Add($"{m.Id},{ConvertMatchupEntryToString(m.Entries)},{winner},{m.MatchupRound}");
            }
            File.WriteAllLines(GlobalConfiguration.MATCHUPFILE.FullFilePath(), lines);
        }
        public static void SaveToEntryFile(this MatchupEntry entry, string matchupEntryFile)
        {
            List<MatchupEntry> entries = GlobalConfiguration.MATCHUPENTRYFILE.FullFilePath().LoadFile().ConvertToMatchupEntry();
            int currentId = 1;
            if (entries.Count > 0)
            {
                currentId = entries.OrderByDescending(x => x.Id).First().Id + 1;
            }
            entry.Id = currentId;
            entries.Add(entry);

            List<string> lines = new List<string>();
            foreach (MatchupEntry e in entries)
            {
                string parent = "";
                if (e.ParentMatchup != null)
                {
                    parent = e.ParentMatchup.Id.ToString();
                }
                string team = "";
                if (e.Team != null)
                {
                    team = e.Team.Id.ToString();
                }
                lines.Add($"{e.Id},{team},{e.Score},{parent}");
            }
            File.WriteAllLines(GlobalConfiguration.MATCHUPENTRYFILE.FullFilePath(), lines);
        }
        public static void SaveToRoundsFile(this Tournament model, string matchupFile, string matchupEntryFile)
        {
            foreach (List<Matchup> round in model.Rounds)
            {
                foreach (Matchup match in round)
                {
                    match.SaveToMatchupFile(matchupFile, matchupEntryFile);
                }
            }
        }
        public static void UpdateMatchupFile(this Matchup match)
        {
            List<Matchup> matchups = GlobalConfiguration.MATCHUPFILE.FullFilePath().LoadFile().ConvertToMatchup();

            Matchup temp = new Matchup();
            foreach (Matchup matchup in matchups)
            {
                if (matchup.Id == match.Id)
                {
                    temp = matchup;
                }
            }
            matchups.Remove(temp);

            matchups.Add(match);

            foreach (MatchupEntry entry in match.Entries)
            {
                entry.UpdateEntryFile();
            }
            List<string> lines = new List<string>();
            foreach (Matchup m in matchups)
            {
                string winner = "";
                if (m.Winner != null)
                {
                    winner = m.Winner.Id.ToString();
                }
                lines.Add($"{m.Id},{ConvertMatchupEntryToString(m.Entries)},{winner},{m.MatchupRound}");
            }
            File.WriteAllLines(GlobalConfiguration.MATCHUPFILE.FullFilePath(), lines);
        }
        public static void UpdateEntryFile(this MatchupEntry entry)
        {
            List<MatchupEntry> entries = GlobalConfiguration.MATCHUPENTRYFILE.FullFilePath().LoadFile().ConvertToMatchupEntry();

            MatchupEntry temp = new MatchupEntry();

            foreach (MatchupEntry me in entries)
            {
                if (me.Id == entry.Id)
                {
                    temp = me;
                }
            }
            entries.Remove(temp);

            entries.Add(entry);

            List<string> lines = new List<string>();
            foreach (MatchupEntry e in entries)
            {
                string parent = "";
                if (e.ParentMatchup != null)
                {
                    parent = e.ParentMatchup.Id.ToString();
                }
                string team = "";
                if (e.Team != null)
                {
                    team = e.Team.Id.ToString();
                }
                lines.Add($"{e.Id},{team},{e.Score},{parent}");
            }
            File.WriteAllLines(GlobalConfiguration.MATCHUPENTRYFILE.FullFilePath(), lines);
        }
    }
}