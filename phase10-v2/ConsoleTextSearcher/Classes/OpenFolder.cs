using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleTextSearcher.Interfaces;

namespace ConsoleTextSearcher.Classes
{
    public class OpenFolder:IOpenFolder
    {
        public string FolderPath { get; set; }
        public List<string> FileNames { get; set; } 
        public List<string> FileContents { get; set; }

        public bool ReadFolderContents(string folderPath)
        {
            if(Directory.Exists(folderPath))
            {
                FolderPath = folderPath;

                foreach (string file in Directory.EnumerateFiles(folderPath, "*"))
                {
                    string contents = File.ReadAllText(file);
                    FileNames.Add(file);
                    FileContents.Add(contents);
                }
                return true;
            }
            return false;
        }

    }   
}