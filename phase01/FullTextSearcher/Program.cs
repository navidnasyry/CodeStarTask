// See https://aka.ms/new-console-template for more information
using System.IO;
using FileReader;
using SearchAlgorithm;
// using System.Collections;



Console.WriteLine("Start Program...");

Console.WriteLine("Enter folder path: ");

string folderPath = Console.ReadLine();

Console.WriteLine("Enter the desired word : ");

string myTerm = Console.ReadLine();



MyFolder myData = new MyFolder(folderPath);


InvertedIndex myInvertedIndex = new InvertedIndex(
    myData.GetFileName(), 
    myData.GetFileContext()
);


myInvertedIndex.CreateHashtable();

string dist = myInvertedIndex.FindTerm(myTerm);

Console.WriteLine("Your response : ");

Console.WriteLine(dist);

// myInvertedIndex.WriteHashTable();



