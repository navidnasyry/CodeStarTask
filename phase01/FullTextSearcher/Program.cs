// See https://aka.ms/new-console-template for more information
using System.IO;
using FileReader;



Console.WriteLine("Start Program...");

Console.WriteLine("Enter Your Folder Path : ");

string folderPath = Console.ReadLine();

MyFolder myData = new MyFolder(folderPath);

Console.WriteLine(myData.GetFolderPath());







// for(int i=0 ; i<5 ; i++)
// {
//     Console.WriteLine("LOOP:");
//     Console.WriteLine(myData.GetFileName());
//     Console.WriteLine(myData.GetFileName()[i]);
//     Console.WriteLine(myData.GetFileContext()[i]);
// }


// string getFolderPath(){

//     string folderPath = Console.ReadLine();

//     return folderPath;
// }

