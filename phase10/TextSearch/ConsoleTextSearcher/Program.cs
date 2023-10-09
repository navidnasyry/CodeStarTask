// See https://aka.ms/new-console-template for more information
using Nest;
using ConsoleTextSearcher;


Console.WriteLine("Hello, World!");



IElasticClient client = ElasticClientFactory.CreateElasticClient();


Console.WriteLine(ElasticClientFactory.CheckClientConnection());