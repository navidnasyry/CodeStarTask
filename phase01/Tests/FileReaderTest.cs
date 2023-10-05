namespace Tests;
using FileReader;
public class FileReaderTest
{

    private string baseDir = Directory.GetParent(System.Environment.CurrentDirectory).Parent.Parent.Parent.ToString();
    private string testDirectoryPath = "/Tests/testDir/";

    [Fact]
    public void MyFolderClass_ReturnFolderPath()
    {

        MyFolder folder = new MyFolder(this.baseDir + this.testDirectoryPath);


        Assert.Equal(folder.GetFolderPath(), this.baseDir + this.testDirectoryPath);

    }

    [Fact]
    public void MyFolderClass_ReturnFileName()
    {

        MyFolder folder = new MyFolder(this.baseDir + this.testDirectoryPath);

        var fileName = folder.GetFileName();

        foreach (var (file1, file2) in fileName.Zip(Directory.EnumerateFiles(folder.GetFolderPath(), "*")))
        {
            Assert.Equal(file1, file2);
        }

    }

    [Fact]
    public void MyFolderClass_ReturnFileContext()
    {

        MyFolder folder = new MyFolder(this.baseDir + this.testDirectoryPath);
        
        var fileContext = folder.GetFileContext();

        foreach (var (context, file) in fileContext.Zip(Directory.EnumerateFiles(folder.GetFolderPath(), "*")))
        {
            string contents = File.ReadAllText(file);

            Assert.Equal(context, contents);
        }

    }

}