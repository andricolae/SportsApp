using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAppLibrary
{
    public class TextFileConnector : IDataConnection
    {
        // TODO - Dev the CreatePrize for text file
        public Prize CreatePrize(Prize model)
        {
            // throw new NotImplementedException();
            model.Id = 1;
            return model;
        }
    }
}
