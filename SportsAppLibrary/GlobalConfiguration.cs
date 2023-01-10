using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsAppLibrary
{
    public static class GlobalConfiguration
    {
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();

        public static void InitializeConnections(bool database, bool textFile)
        {
            if (database)
            {
                // TODO - SetUp the SQL Connector
                SQLConnector sql = new SQLConnector();
                Connections.Add(sql);
            }
            if (textFile)
            {
                // TODO - Create the Text File Connection
                TextFileConnector text = new TextFileConnector();
                Connections.Add(text);
            }
        }
    }
}