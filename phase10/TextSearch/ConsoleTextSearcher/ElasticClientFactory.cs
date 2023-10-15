using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nest;


namespace ConsoleTextSearcher
{
    internal static class ElasticClientFactory
    {
       private static IElasticClient client = CreateInitialClient();

        private static IElasticClient CreateInitialClient()
        {
            var uri = new Uri ("http://localhost:9200");
            var connectionSettings = new ConnectionSettings (uri)
            .DefaultIndex("test");

            connectionSettings.EnableDebugMode();
            return new ElasticClient (connectionSettings);
        }

        public static string CheckClientConnection()
        {
            return client.Ping().ToString();
        }

        public static IElasticClient CreateElasticClient() 
        {
            return client;
        }
        
    }
}