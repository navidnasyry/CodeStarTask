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
            var response = this.client.Indices.Create(indexName,
                c => c
                .Settings(CreateSettings)
                .Map<Document>(m => m
                .AutoMap()
                )
            );
            Console.WriteLine(response.ToString());

            // var response = client.Indices.Create(index
            //     s => s
            //     .Settings(CreateSettings)
            //     .Map<DocumeCreateSettingsnt>(CreateMapping));
        }

        private IPromise<IIndexSettings> CreateSettings(IndexSettingsDescriptor settingsDescriptor)
        {
            return settingsDescriptor
                // .Setting("max_ngram_diff", 7)
                .Analysis(CreateAnalysis);
        }

        private ITypeMapping CreateMapping(TypeMappingDescriptor<Document> mappingDescriptor)
        {
            return mappingDescriptor
                .Properties(pr => pr.AddAboutFieldMapping());
        }

        private IAnalysis CreateAnalysis(AnalysisDescriptor analysisDescriptor)
        {
            return analysisDescriptor
                .TokenFilters(CreateTokenFilters)
                .Analyzers(CreateAnalyzers);
        }

        private static IPromise<IAnalyzers> CreateAnalyzers(AnalyzersDescriptor analyzersDescriptor)
        {
            return analyzersDescriptor
                .Custom(Analyzers.NgramAnalyzer, custom => custom
                    .Tokenizer("standard")
                    .Filters("lowercase", "whitespace"));
        }

        private static IPromise<ITokenFilters> CreateTokenFilters(TokenFiltersDescriptor tokenFiltersDescriptor)
        {
            return tokenFiltersDescriptor
                .NGram(TokenFilters.NgramFilter, ng => ng
                    .MinGram(3)
                    .MaxGram(10));
        }
 
    }
}