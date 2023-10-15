using System;
using System.Text.Json.Serialization;
using Nest;

namespace ConsoleTextSearcher.Models
{
    public class Document
    {
        // [JsonPropertyName("fileName")]
        public string FileName { get; set; }

        // [JsonPropertyName("text")]
        public string Text { get; set; }

    }
}