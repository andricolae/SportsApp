using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAppLibrary
{
    public interface IDataConnection
    {
        Prize CreatePrize(Prize model);
        Person CreatePerson(Person model);
        List<Person> GetAllPersons();
        Team CreateTeam(Team model);
        List<Team> GetAllTeams();
        void CreateTournament(Tournament model);
        List<Tournament> GetTournaments();
    }
}