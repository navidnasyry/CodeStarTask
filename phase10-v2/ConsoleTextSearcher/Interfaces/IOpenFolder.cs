using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleTextSearcher.Interfaces
{
    public interface IOpenFolder
    {
        string FolderPath{
            get;
            set;
        }
        List<string> FileNames{
            get;
            set;
        }
        List<string> FileContents{
            get;
            set;
        }
        
        bool ReadFolderContents(string folderPath);

    }
}