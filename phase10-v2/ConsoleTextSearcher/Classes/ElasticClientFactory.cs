using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nest;
using ConsoleTextSearcher.Interfaces;


namespace ConsoleTextSearcher
{
    public class ElasticClientFactory:IElasticClientFactory
    {
        private static IElasticClient client = null;

        public IElasticClient CreateElasticClient(string elasticUri, bool debugMode= false)
        {
            
            var uri = new Uri (elasticUri);
            var connectionSettings = new ConnectionSettings (uri);
            if(debugMode)
                connectionSettings.EnableDebugMode();
            client = new ElasticClient(connectionSettings);
        
            return client;
        }

        public bool CheckClientConnection()
        {
            if (client.Ping().ToString().Contains("200"))
                return true;
            return false;
        }

        public IElasticClient GetElasticClient()
        {
            return client;
        }
        

    }
}