// See https://aka.ms/new-console-template for more information
using System.IO;
    using FileReader;
using SearchAlgorithm;
// using System.Collections;




MyFolder folderObj = InitApp();

RunInvertedindex(folderObj);

// myInvertedIndex.WriteHashTable();
static MyFolder InitApp()
{
    Console.WriteLine("Start Program...");

    Console.WriteLine("Enter folder path: ");

    string folderPath = Console.ReadLine();

    MyFolder folderData = new MyFolder(folderPath);

    return folderData;
}

static void RunInvertedindex(MyFolder folderData)
{
    Console.WriteLine("Enter the desired word : ");

    string myTerm = Console.ReadLine();

    InvertedIndex myInvertedIndex = new InvertedIndex(
        folderData.GetFileName(),
        folderData.GetFileContext()
    );


    myInvertedIndex.CreateHashtable();

    string dist = myInvertedIndex.FindTerm(myTerm);

    Console.WriteLine("Your response : ");

    Console.WriteLine(dist);
}

