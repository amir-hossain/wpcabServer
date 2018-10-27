using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WpcabServer.Link;

namespace WpcabServer.Utils
{
    public class Factory
    {
        public static Connector GetConnector()
        {
            return Connector.getInstance();
        }
    }
}
