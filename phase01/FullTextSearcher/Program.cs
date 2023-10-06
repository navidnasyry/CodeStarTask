// See https://aka.ms/new-console-template for more information
using System.IO;
using FullTextSearcher.FileReader;
using FullTextSearcher.SearchAlgorithm;
// using System.Collections;



InitApp();



// myInvertedIndex.WriteHashTable();
static void InitApp()
{
    Console.WriteLine("Start Program...");

    Console.WriteLine("Enter folder path: ");

    string folderPath = Console.ReadLine();

    Console.WriteLine("Enter the desired word : ");

    string myTerm = Console.ReadLine();

    RunInvertedIndexSearch(folderPath, myTerm);

    return ;
}


static void RunInvertedIndexSearch(string folderPath,
                                    string searchedTerm)
{

    MyFolder folderData = new MyFolder(folderPath);

    InvertedIndex myInvertedIndex = new InvertedIndex(
        folderData.GetFileName(),
        folderData.GetFileContext()
    );

    myInvertedIndex.CreateHashtable();

    string dist = myInvertedIndex.FindTerm(searchedTerm);

    Console.WriteLine("Your response : ");

    Console.WriteLine(dist);
}
