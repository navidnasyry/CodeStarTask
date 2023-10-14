using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleTextSearcher.Interfaces
{
    public interface IIndexDefiner
    {
        bool CreateCustomIndex(string indexName);

    }
}