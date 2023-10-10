using Nest;
using ConsoleTextSearcher.Models;

namespace ConsoleTextSearcher
{
    internal class IndexDefiner
    {
        private readonly IElasticClient client;

        public IndexDefiner()
        {
            client = ElasticClientFactory.CreateElasticClient();
        }

        public void CreateIndex(string indexName)
        {
            var r_response = this.client.Indices.Delete(indexName);
            var response = this.client.Indices.Create(indexName,
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
            Console.WriteLine(response.ToString());
            return;
        }

    }
}