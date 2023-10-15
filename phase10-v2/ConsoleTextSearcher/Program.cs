using Nest;
using ConsoleTextSearcher;
using ConsoleTextSearcher.Classes;
using ConsoleTextSearcher.Interfaces;
try
{

    IInputOutput IOClass = new ConsoleInputOutput();
    ElasticClientFactory elasticClientObj = new ElasticClientFactory();
    IElasticClient client = elasticClientObj.CreateElasticClient(
        "http://localhost:9200"
        );

    if (elasticClientObj.CheckClientConnection())
    {
        string item = IOClass.ReadString();
        string dirPaht = IOClass.ReadString();


        IndexDefiner indexObj = new IndexDefiner(elasticClientObj);

        indexObj.CreateCustomIndex(dirPaht);

        SearchElastic searchObj = new SearchElastic(elasticClientObj);

        var result = searchObj.SearchItem(dirPaht, item);

        IOClass.WriteDocumentList(result, 3);

    }
    else
    {
        IOClass.WriteString("Connection to Elastic failed !!");
    }
}
catch (Exception ex)
{
    Console.Error.WriteLine("An error occurred: " + ex.Message);
}











