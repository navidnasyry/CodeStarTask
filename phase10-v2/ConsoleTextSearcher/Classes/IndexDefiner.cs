using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleTextSearcher.Interfaces;
using ConsoleTextSearcher.Models;

namespace ConsoleTextSearcher.Classes
{
    public class IndexDefiner : IIndexDefiner
    {
        private readonly IElasticClientFactory clientFactory = null;

        public IndexDefiner(IElasticClientFactory clientObj)
        {
            clientFactory = clientObj;
        }

        public bool CreateCustomIndex(string indexName)
        {

            var client = clientFactory.GetElasticClient();
            var preIndex = client.Indices.Delete(indexName);
            var indexResponse = client.Indices.Create(indexName,
                c => c
                .Settings(s => s
                    .Analysis(a => a
                        .Analyzers(an => an.
                            Custom("my_custom", c => c
                                .Tokenizer("whitespace")
                                .Filters("lowercase")
                            )
                        )
                    )
                )
                .Map<Document>(m => m
                    .Properties(p => p
                        .Text(t => t
                            .Name(n => n.Text)
                            .Analyzer("my_custom")
                        )
                        .Text(t => t.
                            Name(n => n.FileName)
                        )
                    )
                )
            );
            if (indexResponse.IsValid)
                return true;
            return false;
        }

    }
}