namespace FileReader;
public class MyFolder
{



    private string folderPath;
    // private Dictionary<string, string> folderContent = new Dictionary<string, string>();
    private List<string> fileName = new List<string>();
    private List<string> fileContext = new List<string>();
    

    public MyFolder(string folderPath)
    {
        this.folderPath = folderPath;

        foreach (string file in Directory.EnumerateFiles(folderPath, "*"))
        {
            string contents = File.ReadAllText(file);
            // Console.WriteLine(contents);
            // Console.WriteLine(file);
            this.fileName.Add(file);
            this.fileContext.Add(contents);
        }

    }


    public List<string> GetFileName(){
        return this.fileName;
    }

    public List<string> GetFileContext(){
        return this.fileContext;
    }
    public string GetFolderPath(){
        return this.folderPath;
    }
}
