using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleTextSearcher.ApplicationException
{
    [Serializable]
    public class ConnectionFailedException: Exception
    {
        public ConnectionFailedException(string hostName)
            : base(String.Format("Connection failed to : {0}", hostName))
        {
            
        }
    }
}