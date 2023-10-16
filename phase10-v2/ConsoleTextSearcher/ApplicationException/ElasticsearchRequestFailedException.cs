using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleTextSearcher.ApplicationException
{
    [Serializable]
    public class ElasticsearchRequestFailedException: Exception
    {
        public ElasticsearchRequestFailedException()
            : base("Search in Elasticsearch failed...!")
        {
            
        }
    }
}