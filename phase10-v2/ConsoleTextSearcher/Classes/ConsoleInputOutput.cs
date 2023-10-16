using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleTextSearcher.Interfaces;
using ConsoleTextSearcher.Models;

namespace ConsoleTextSearcher.Classes
{
    public class ConsoleInputOutput : IInputOutput
    {

        public bool WriteString(string str)
        {
            try
            {
                Console.WriteLine(str);
                return true;
            }
            catch (System.IO.IOException ex)
            {
                return false;
            }
        }
        public string ReadString()
        {
            try
            {
                var inputStr = Console.ReadLine();
                return inputStr;
            }
            catch (System.IO.IOException ex)
            {
                return false;
            }

        }
        public bool WriteDocumentList(List<Document> docList, int num)
        {
            try
            {
                if (docList.Count != 0)
                {
                    foreach (var doc in docList)
                    {
                        this.WriteString(doc.Text);
                        num--;
                        if (num == 0)
                            return true;
                    }
                }
                else
                {
                    this.WriteString("Error: The List is empty!");
                    return false;
                }
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}