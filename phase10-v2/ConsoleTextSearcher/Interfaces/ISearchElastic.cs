using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleTextSearcher.Models;

namespace ConsoleTextSearcher.Interfaces
{
    public interface ISearchElastic
    {
        List<Document> SearchItem(string index, string inputItem);

    }
}