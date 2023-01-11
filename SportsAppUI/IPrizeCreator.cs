using SportsAppLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsAppLibrary;

namespace SportsAppUI
{
    public interface IPrizeCreator
    {
        void PrizeCreated(Prize model);
    }
}
