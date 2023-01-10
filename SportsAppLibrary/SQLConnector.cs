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
        // TODO - Make the CreatePrize metod save to the DB
        /// <summary>
        /// Stores a new generated prize to the database
        /// </summary>
        /// <param name="model"> Prize information </param>
        /// <returns> The prize info together with the id </returns>
        public Prize CreatePrize(Prize model)
        {
            // throw new NotImplementedException();

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfiguration.ConnectionString("Tournaments")))
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
    }
}
