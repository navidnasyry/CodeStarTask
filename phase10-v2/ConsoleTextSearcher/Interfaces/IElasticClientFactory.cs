using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nest;

namespace ConsoleTextSearcher.Interfaces
{
    public interface IElasticClientFactory
    {
        IElasticClient CreateElasticClient(string es_uri, bool debug_mod);
        bool CheckClientConnection();
        IElasticClient GetElasticClient();
    }
}