using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleTextSearcher.Interfaces;
using ConsoleTextSearcher.Models;
using ConsoleTextSearcher.ApplicationException;

namespace ConsoleTextSearcher.Classes
{
    public class SearchElastic : ISearchElastic
    {
        private readonly IElasticClientFactory clientFactory = null;

        public SearchElastic(IElasticClientFactory clientObj)
        {
            clientFactory = clientObj;
        }

        public List<Document> SearchItem(string index, string inputItem)
        {
            var client = clientFactory.GetElasticClient();

            var searchResponse = client.Search<Document>(s => s
            .Index(index)
            .Query(q => q
                    .Match(m => m
                        .Field(f => f.Text)
                        .Query(inputItem.ToLower())
                    )
                )
            );

            if (searchResponse.IsValid)
                return searchResponse.Documents.ToList();

            throw new ElasticsearchRequestFailedException();
        }

    }
}