namespace FullTextSearcher.FileReader;
public class MyFolder
{

    #region Fields
    // Fields
    private string folderPath;
    private List<string> fileName = new List<string>();
    private List<string> fileContext = new List<string>();
    #endregion

    #region Public Methods
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
    #endregion

    #region Private Methods
    // Public Methods
    public List<string> GetFileName()
    {
        return this.fileName;
    }

    public List<string> GetFileContext()
    {
        return this.fileContext;
    }
    public string GetFolderPath()
    {
        return this.folderPath;
    }

    #endregion

}
