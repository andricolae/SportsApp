using System;
using System.Collections.Generic;
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
            model.Id = 1;
            return model;
        }
    }
}
