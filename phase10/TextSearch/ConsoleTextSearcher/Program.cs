// See https://aka.ms/new-console-template for more information
using Nest;
using ConsoleTextSearcher;
using ConsoleTextSearcher.Models;


InitApp();



static void InitApp()
{
    Console.WriteLine("Enter directory path : ");
    string dirPath = Console.ReadLine();
    Console.WriteLine("Enter your term:");
    string term = Console.ReadLine();

    CheckConnection2Elasticsearch();

    InitIndex(term);

    //SearchTerm(term);

    return;
}



static void InitIndex(string indexName)
{
    var indexDefiner = new IndexDefiner();

    indexDefiner.CreateIndex(indexName);

    
}




static void CheckConnection2Elasticsearch(){

    IElasticClient client = ElasticClientFactory.CreateElasticClient();

    Console.WriteLine(ElasticClientFactory.CheckClientConnection());

    return;
}


static void SearchTerm(string inputTerm)
{

    IElasticClient client = ElasticClientFactory.CreateElasticClient();

    var searchResponse = client.Search<Document>(s => s
        .From(0)
        .Size(10)
        .Query(q => q
            .Match(m => m
                .Field(f => f.Text)
                .Query(inputTerm)
            )
        )
    );

    Console.WriteLine(searchResponse.Documents.ToString());
    return ;
}