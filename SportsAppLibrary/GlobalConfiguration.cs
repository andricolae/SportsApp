using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAppLibrary
{
    public static class GlobalConfiguration
    {
        public const string PRIZESFILE = "Prizes.csv";
        public const string PERSONSFILE = "Persons.csv";
        public const string TEAMSFILE = "Teams.csv";
        public const string TOURNAMENTFILE = "Tournaments.csv";
        public const string MATCHUPFILE = "Matchups.csv";
        public const string MATCHUPENTRYFILE = "MatchupEntries.csv";

        public static IDataConnection Connection { get; private set; }

        public static void InitializeConnections(DatabaseType db)
        {
            if (db == DatabaseType.Sql)
            {
                SQLConnector sql = new SQLConnector();
                Connection = sql;
            }
            else if (db == DatabaseType.TextFile)
            {
                TextFileConnector text = new TextFileConnector();
                Connection = text;
            }
        }

        public static string ConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}