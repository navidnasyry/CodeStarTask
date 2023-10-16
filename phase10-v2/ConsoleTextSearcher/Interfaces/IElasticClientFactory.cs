using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nest;

namespace ConsoleTextSearcher.Interfaces
{
    public interface IElasticClientFactory
    {
        IElasticClient CreateElasticClient(string elasticUri, bool debugMode = false);
        bool CheckClientConnection();
        IElasticClient GetElasticClient();
    }
}