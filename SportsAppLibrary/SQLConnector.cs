using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        // TODO - Make the CreatePrize metod save to the DB
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

        public List<Person> GetAllPersons()
        {
            List<Person> output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfiguration.ConnectionString(DB)))
            {
                output = connection.Query<Person>("dbo.spPerson_SelectAll").ToList();
            }
            return output;
        }
    }
}
