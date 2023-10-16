using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using Nest;
using ConsoleTextSearcher.Classes;
using ConsoleTextSearcher.Interfaces;
using ConsoleTextSearcher.Models;

namespace ConsoleTextSearcher.Classes
{
    public class General
    {

        private string ReadElasticUri()
        {
            var elasticUri = ConfigurationManager.AppSettings.Get("ElasticsearchURL");
            return elasticUri.ToString();
        }

        private IElasticClientFactory CreateElasticObject()
        {
            var elasticUri = this.ReadElasticUri();
            IElasticClientFactory elasticClientObj = new ElasticClientFactory();
            IElasticClient client = elasticClientObj.CreateElasticClient(elasticUri);
            return elasticClientObj;

        }

        private (string, string, string) GetInputFromUser()
        {
            IInputOutput inputOutputClass = new ConsoleInputOutput();
            inputOutputClass.WriteString("Enter item:");
            var item = inputOutputClass.ReadString();
            inputOutputClass.WriteString("Enter directory path:");
            var dirPath = inputOutputClass.ReadString();
            inputOutputClass.WriteString("Enter top N number:");
            var topN = inputOutputClass.ReadString();
            return (item, dirPath, topN);
        }

        private List<Document> SearchTermInElasticsearch(string item, string indexName)
        {
            IElasticClientFactory elasticClientObj = this.CreateElasticObject();
            IndexDefiner indexObj = new IndexDefiner(elasticClientObj);
            indexObj.CreateCustomIndex(indexName);
            SearchElastic searchObj = new SearchElastic(elasticClientObj);
            var result = searchObj.SearchItem(indexName, item);
            return result;

        }


        private void WriteOutput(List<Document> list, int num)
        {
            IInputOutput inputOutputClass = new ConsoleInputOutput();
            inputOutputClass.WriteDocumentList(list, 3);
        }
        public bool RunProgram()
        {

            try
            {

                var (item, dirPath, topN) = this.GetInputFromUser();

                var searchResult = this.SearchTermInElasticsearch(item, dirPath);

                this.WriteOutput(searchResult, int.Parse(topN));

                return true;

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
        }


    }
}