using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleTextSearcher.Interfaces
{
    public interface IOpenFolder
    {
        bool ReadFolderContents(string folderPath);

    }
}