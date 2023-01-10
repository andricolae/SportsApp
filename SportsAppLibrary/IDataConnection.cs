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
    }
}