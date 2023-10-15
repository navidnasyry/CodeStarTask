using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleTextSearcher.Models;

namespace ConsoleTextSearcher.Interfaces
{
    public interface IInputOutput
    {
        bool WriteString(string str);
        string ReadString();
        bool WriteDocumentList(List<Document> docList, int num);
    }
}