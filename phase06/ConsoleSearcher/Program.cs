

if (args.Length == 2)
{
    RunInvertedIndexSearch(
        args[0],
        args[1]
    );
}
else
{
    Console.WriteLine("Error: please Enter 2 parameter");
    Console.WriteLine("Usage: run --project ConsoleSearcher.csproj <FolderPath> <Term>");
    Console.WriteLine("\n<FolderPath> : all files in this folder. enter this folder path.");
    Console.WriteLine("\n<Term> : enter term you want to search it");


}

