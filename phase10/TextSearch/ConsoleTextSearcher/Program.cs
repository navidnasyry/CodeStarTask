// See https://aka.ms/new-console-template for more information
using Nest;
using ConsoleTextSearcher;
using ConsoleTextSearcher.Models;


// IElasticClient client = ElasticClientFactory.CreateElasticClient();


InitApp();



static void InitApp()
{
    Console.WriteLine("Enter directory path : ");
    string dirPath = Console.ReadLine();
    Console.WriteLine("Enter your term:");
    string term = Console.ReadLine();

    CheckConnection2Elasticsearch();

    InitIndex(dirPath);

    List<Document> res = SearchTerm(term);

    Console.WriteLine("\nResponse : ");
    foreach (var data in res)
    {
        Console.WriteLine(data.FileName.ToString());
    }

    return;
}



static void InitIndex(string dirPath)
{
    // Create Index
    string indexName = dirPath.Replace('/', '_').ToLower();
    var indexDefiner = new IndexDefiner();
    indexDefiner.CreateIndex(indexName);
    //OpenFolder
    OpenFolder fPathObj = new OpenFolder(dirPath);
    IElasticClient client = ElasticClientFactory.CreateElasticClient();
    // Add Documents
    foreach (var (fName, fContext) in fPathObj.GetFileName().Zip(fPathObj.GetFileContext()))
    {
        var doc = new Document
        {
            FileName = fName,
            Text = fContext
        };
        var indexResponse = client.Index(
            doc,
            i => i.Index(indexName)
        );
        if (!indexResponse.IsValid)
        {
            Console.WriteLine("--Error--");
        }


    }

    return;
}




static void CheckConnection2Elasticsearch()
{

    IElasticClient client = ElasticClientFactory.CreateElasticClient();

    Console.WriteLine(ElasticClientFactory.CheckClientConnection());

    return;
}


static List<Document> SearchTerm(string inputTerm)
{

    IElasticClient client = ElasticClientFactory.CreateElasticClient();
    var searchResponse = client.Search<Document>(s => s
        .Query(q => q
            .Match(m => m
                .Field(f => f.Text)
                .Query(inputTerm.ToLower())
            )
        )
    );

    
    return searchResponse.Documents.ToList();
}