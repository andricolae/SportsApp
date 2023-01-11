using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Person> GetAllPersons()
        {
            return PERSONSFILE.FullFilePath().LoadFile().ConvertToPerson();
        }
    }
}
