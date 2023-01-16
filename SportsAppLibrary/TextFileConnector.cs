using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SportsAppLibrary.TextHelpers;

namespace SportsAppLibrary
{
    public class TextFileConnector : IDataConnection
    {
        private const string PRIZESFILE = "Prizes.csv";
        private const string PERSONSFILE = "Persons.csv";
        private const string TEAMSFILE = "Teams.csv";
        private const string TOURNAMENTFILE = "Tournaments.csv";
        private const string MATCHUPFILE = "Matchups.csv";
        private const string MATCHUPENTRYFILE = "MatchupEntries.csv";

        public Person CreatePerson(Person model)
        {
            List<Person> persons = PERSONSFILE.FullFilePath().LoadFile().ConvertToPerson();
            int currentId = 1;
            if (persons.Count > 0)
            {
                currentId = persons.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;
            persons.Add(model);
            persons.SaveToPersonFile(PERSONSFILE);
            return model;
        }

        public Prize CreatePrize(Prize model)
        {
            List<Prize> prizes = PRIZESFILE.FullFilePath().LoadFile().ConvertToPrize();
            int currentId = 1;
            if (prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;
            prizes.Add(model);
            prizes.SaveToPrizesFile(PRIZESFILE);
            return model;
        }

        public Team CreateTeam(Team model)
        {
            List<Team> teams = TEAMSFILE.FullFilePath().LoadFile().ConvertToTeam(PERSONSFILE);
            int currentId = 1;
            if (teams.Count > 0)
            {
                currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;
            teams.Add(model);
            teams.SaveToTeamFile(TEAMSFILE);
            return model;
        }

        public void CreateTournament(Tournament model)
        {
            List<Tournament> tournaments = TOURNAMENTFILE.FullFilePath().LoadFile().ConvertToTournament(TEAMSFILE, PERSONSFILE, PRIZESFILE);
            int currentId = 1;
            if (tournaments.Count > 0)
            {
                currentId = tournaments.OrderByDescending(x => x.Id).First().Id + 1;
            }
            model.Id = currentId;
            model.SaveToRoundsFile(MATCHUPFILE, MATCHUPENTRYFILE);
            tournaments.Add(model);
            tournaments.SaveToTournamentFile(TOURNAMENTFILE);
        }

        public List<Person> GetAllPersons()
        {
            return PERSONSFILE.FullFilePath().LoadFile().ConvertToPerson();
        }

        public List<Team> GetAllTeams()
        {
            return TEAMSFILE.FullFilePath().LoadFile().ConvertToTeam(PERSONSFILE);
        }

        public List<Tournament> GetTournaments()
        {
            return TOURNAMENTFILE.FullFilePath().LoadFile().ConvertToTournament(TEAMSFILE, PERSONSFILE, PRIZESFILE);
        }
    }
}
