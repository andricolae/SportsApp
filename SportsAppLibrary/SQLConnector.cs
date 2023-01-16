using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Management.Instrumentation;
using System.Net;
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
        private void SaveTournament(Tournament model, IDbConnection connection)
        {
            var p = new DynamicParameters();
            p.Add("@TournamentName", model.TournamentName);
            p.Add("@EntryFee", model.Fee);
            p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("dbo.spTournament_Insert", p, commandType: CommandType.StoredProcedure);

            model.Id = p.Get<int>("@id");
        }
        private void SaveTournamentPrize(Tournament model, IDbConnection connection)
        {
            foreach (Prize pz in model.Prizes)
            {
                var p = new DynamicParameters();
                p.Add("@TournamentId", model.Id);
                p.Add("@PrizeId", pz.Id);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spTournamentPrize_Insert", p, commandType: CommandType.StoredProcedure);
            }
        }
        private void SaveTournamentEntries(Tournament model, IDbConnection connection)
        {
            foreach (Team tm in model.Teams)
            {
                var p = new DynamicParameters();
                p.Add("@TournamentId", model.Id);
                p.Add("@TeamId", tm.Id);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spTournamentEntry_Insert", p, commandType: CommandType.StoredProcedure);
            }
        }
        private void SaveTournamentMatchups(Tournament model, IDbConnection connection)
        {
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
                        if (entry.ParentMatchup == null)
                        {
                            r.Add("@ParentMatchupId", null);
                        }
                        else
                        {
                            r.Add("@ParentMatchupId", entry.ParentMatchup.Id);
                        }
                        if (entry.Team == null)
                        {
                            r.Add("@TeamCompetingId", null);
                        }
                        else
                        {
                            r.Add("@TeamCompetingId", entry.Team.Id);

                        }
                        r.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                        connection.Execute("dbo.spMatchupEntry_Insert", r, commandType: CommandType.StoredProcedure);
                    }
                }
            }
        }
        public void CreateTournament(Tournament model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfiguration.ConnectionString(DB)))
            {
                SaveTournament(model, connection);

                SaveTournamentPrize(model, connection);

                SaveTournamentEntries(model, connection);

                SaveTournamentMatchups(model, connection);
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
        public List<Tournament> GetTournaments()
        {
            List<Tournament> output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfiguration.ConnectionString(DB)))
            {
                output = connection.Query<Tournament>("dbo.spTournament_SelectAll").ToList();
                var p = new DynamicParameters();

                foreach (Tournament t in output)
                {
                    p = new DynamicParameters();
                    p.Add("@TournamentId", t.Id);
                    t.Prizes = connection.Query<Prize>("dbo.spPrize_GetByTournament", p, commandType: CommandType.StoredProcedure).ToList();

                    p = new DynamicParameters();
                    p.Add("@TournamentId", t.Id);
                    t.Teams = connection.Query<Team>("dbo.spTeam_GetByTournament", p, commandType: CommandType.StoredProcedure).ToList();

                    foreach (Team team in t.Teams)
                    {
                        p = new DynamicParameters();
                        p.Add("@TeamId", team.Id);
                        team.TeamMembers = connection.Query<Person>("dbo.spTeamMembers_SelectByTeam", p, commandType: CommandType.StoredProcedure).ToList();
                    }

                    p = new DynamicParameters();    
                    p.Add("@TournamentId", t.Id);
                    List<Matchup> matchups = connection.Query<Matchup>("dbo.spMatchup_GetByTournament", p, commandType: CommandType.StoredProcedure).ToList();
                    foreach (Matchup m in matchups)
                    {
                        p = new DynamicParameters();
                        p.Add("@MatchupId", m.Id);
                        m.Entries = connection.Query<MatchupEntry>("dbo.spMatchupEntry_GetByMatchup", p, commandType: CommandType.StoredProcedure).ToList();
                       
                        List<Team> allTeams = GetAllTeams();
                        
                        if (m.WinnerId > 0)
                        {
                            m.Winner = allTeams.Where(x => x.Id == m.WinnerId).First();
                        }

                        foreach (var me in m.Entries)
                        {
                            if (me.TeamCompetingId > 0)
                            {
                                me.Team = allTeams.Where(x => x.Id == me.TeamCompetingId).First();
                            }
                            if (me.ParentMatchupId > 0)
                            {
                                me.ParentMatchup = matchups.Where(x => x.Id == me.ParentMatchupId).First();
                            }
                        }
                    }
                    List<Matchup> currentRow = new List<Matchup>();
                    int currentRound = 1;
                    foreach (Matchup m in matchups)
                    {
                        if (m.MatchupRound > currentRound)
                        {
                            t.Rounds.Add(currentRow);
                            currentRow = new List<Matchup>();
                            currentRound += 1;
                        }
                        currentRow.Add(m);
                    }
                    t.Rounds.Add(currentRow);
                }
            }
            return output;
        }

        public void UpdateMatchup(Matchup model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfiguration.ConnectionString(DB)))
            {
                var m = new DynamicParameters();
                if (model.Winner != null)
                {
                    m.Add("@id", model.Id);
                    m.Add("@WinnerId", model.Winner.Id);
                    connection.Execute("dbo.spMatchup_Update", m, commandType: CommandType.StoredProcedure); 
                }

                foreach (MatchupEntry me in model.Entries)
                {
                    if (me.Team != null)
                    {
                        m = new DynamicParameters();
                        m.Add("@id", me.Id);
                        m.Add("@TeamCompetingId", me.Team.Id);
                        m.Add("@Score", me.Score);
                        connection.Execute("dbo.spMatchupEntry_Update", m, commandType: CommandType.StoredProcedure); 
                    }
                }
            }
                
        }
    }
}