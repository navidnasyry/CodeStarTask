using Nest;
using ConsoleTextSearcher;

ElasticClientFactory elasticClientObj = new ElasticClientFactory();
IElasticClient client = elasticClientObj.CreateElasticClient(
    "http://localhost:9200"
    );

Console.WriteLine(elasticClientObj.CheckClientConnection());













