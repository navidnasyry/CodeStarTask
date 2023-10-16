using Nest;
using ConsoleTextSearcher;
using ConsoleTextSearcher.Classes;
using ConsoleTextSearcher.Interfaces;
using System.Configuration;
using System.Collections.Specialized;

try
{
    var elasticUri = ConfigurationManager.AppSettings.Get("ElasticsearchURL");
    IInputOutput inputOutputClass = new ConsoleInputOutput();
    ElasticClientFactory elasticClientObj = new ElasticClientFactory();
    IElasticClient client = elasticClientObj.CreateElasticClient(elasticUri);

    if (elasticClientObj.CheckClientConnection())
    {
        string item = inputOutputClass.ReadString();
        string dirPaht = inputOutputClass.ReadString();


        IndexDefiner indexObj = new IndexDefiner(elasticClientObj);

        indexObj.CreateCustomIndex(dirPaht);

        SearchElastic searchObj = new SearchElastic(elasticClientObj);

        var result = searchObj.SearchItem(dirPaht, item);

        inputOutputClass.WriteDocumentList(result, 3);

    }
    else
    {
        inputOutputClass.WriteString("Connection to Elastic failed !!");
    }
}
catch (Exception ex)
{
    Console.Error.WriteLine("An error occurred: " + ex.Message);
}











