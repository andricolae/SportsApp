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
    }
}
