using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SportsAppLibrary
{
    public class SQLConnector : IDataConnection
    {
        private const string DB = "Tournaments";
        public Person CreatePerson(Person model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfiguration.ConnectionString(DB)))
            {
                var p = new DynamicParameters();
                p.Add("@FirstName", model.FirstName);
                p.Add("@LastName", model.LastName);
                p.Add("@Email", model.Email);
                p.Add("@Phone", model.Phone);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPerson_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");

                return model;
            }
        }

        /// <summary>
        /// Stores a new generated prize to the database
        /// </summary>
        /// <param name="model"> Prize information </param>
        /// <returns> The prize info together with the id </returns>
        public Prize CreatePrize(Prize model)
        {
            // throw new NotImplementedException();

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfiguration.ConnectionString(DB)))
            {
                var p = new DynamicParameters();
                p.Add("@PlaceNumber", model.Place);
                p.Add("@PlaceName", model.PlaceName);
                p.Add("@PrizeAmount", model.Amount);
                p.Add("@PrizePercentage", model.Percentage);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPrizes_Insert", p, commandType: CommandType.StoredProcedure);

                model.Id = p.Get<int>("@id");

                return model;
            }
        }

        public Team CreateTeam(Team model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfiguration.ConnectionString(DB)))
            {
                var t = new DynamicParameters();
                t.Add("@TeamName", model.TeamName);
                t.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spTeam_Insert", t, commandType: CommandType.StoredProcedure);

                model.Id = t.Get<int>("@id");

                foreach (Person tM in model.TeamMembers)
                {
                    t = new DynamicParameters();
                    t.Add("@TeamId", model.Id);
                    t.Add("@PersonId", tM.Id);

                    connection.Execute("dbo.spTeamMembers_Insert", t, commandType: CommandType.StoredProcedure);
                }

                return model;
            }
        }

        public void CreateTournament(Tournament model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfiguration.ConnectionString(DB)))
            {
                var t = new DynamicParameters();
                t.Add("@TournamentName", model.TournamentName);
                t.Add("@EntryFee", model.Fee);
                t.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spTournament_Insert", t, commandType: CommandType.StoredProcedure);

                model.Id = t.Get<int>("@id");

                foreach (Prize pz in model.Prizes)
                {
                    t = new DynamicParameters();
                    t.Add("@TournamentId", model.Id);
                    t.Add("@PrizeId", pz.Id);
                    t.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                    connection.Execute("dbo.spTournamentPrize_Insert", t, commandType: CommandType.StoredProcedure);
                }

                foreach (Team tm in model.Teams)
                {
                    t = new DynamicParameters();
                    t.Add("@TournamentId", model.Id);
                    t.Add("@Team.Id", tm.Id);
                    t.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                    connection.Execute("dbo.spTournamentEntry_Insert", t, commandType: CommandType.StoredProcedure);
                }

                foreach (List<Matchup> round in model.Rounds)
                {
                    foreach (Matchup match in round)
                    {
                        var r = new DynamicParameters();
                        r.Add("TournamentId", model.Id);
                        r.Add("@MatchupRound", match.MatchupRound);
                        r.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                        connection.Execute("dbo.spMatchup_Insert", r, commandType: CommandType.StoredProcedure);

                        match.Id = r.Get<int>("@id");

                        foreach (MatchupEntry entry in match.Entries)
                        {
                            r = new DynamicParameters();
                            r.Add("@MatchupId", match.Id);
                            r.Add("@ParentMatchupId", entry.ParentMatchup);
                            r.Add("@TeamCompetingId", entry.Team.Id);
                            r.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                            connection.Execute("dbo.spMatchupEntry_Insert", e, commandType: CommandType.StoredProcedure)
                        }
                    }
                }
            }
        }

        public List<Person> GetAllPersons()
        {
            List<Person> output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfiguration.ConnectionString(DB)))
            {
                output = connection.Query<Person>("dbo.spPerson_SelectAll").ToList();
            }
            return output;
        }

        public List<Team> GetAllTeams()
        {
            List<Team> output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfiguration.ConnectionString(DB)))
            {
                output = connection.Query<Team>("dbo.spTeam_SelectAll").ToList();

                foreach (Team team in output)
                {
                    var t = new DynamicParameters();
                    t.Add("@TeamId", team.Id);
                    team.TeamMembers = connection.Query<Person>("dbo.spTeamMembers_SelectByTeam", t, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            return output;
        }
    }
}
