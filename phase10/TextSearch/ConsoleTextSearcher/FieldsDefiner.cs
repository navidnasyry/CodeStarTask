using Nest;
using ConsoleTextSearcher.Models;

namespace ConsoleTextSearcher
{
    internal static class FieldsDefiner
    {
        public static PropertiesDescriptor<Document> AddAboutFieldMapping(this PropertiesDescriptor<Document> prpertiesDescriptor)
        {
            return prpertiesDescriptor
                .Text(t => t
                    .Name(n => n.Text)
                    .Fields(f => f
                        .Text(ng => ng
                            .Name("ngram")
                            .Analyzer(Analyzers.NgramAnalyzer))));
        }
    }
}