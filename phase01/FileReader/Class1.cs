namespace FileReader;
public class MyFolder
{


    // Fields
    private string folderPath;
    private List<string> fileName = new List<string>();
    private List<string> fileContext = new List<string>();
    
    // Constructor
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

    // Public Methods
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
