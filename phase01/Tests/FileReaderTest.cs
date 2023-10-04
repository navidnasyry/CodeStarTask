namespace Tests;
using FileReader;
public class FileReaderTest
{
    [Fact]
    public void MyFolderClass_ReturnFolderPath()
    {
        var path = "/home/navid/test/";

        MyFolder folder = new MyFolder(path);

        // Assert.Signal(folder);
        Assert.Equal(folder.GetFolderPath(), "/home/navid/test/");

    }

    [Fact]
    public void MyFolderClass_ReturnFileName()
    {
        var path = "/home/navid/test/";

        MyFolder folder = new MyFolder(path);

        var fileName = folder.GetFileName();

        foreach (var (file1, file2) in fileName.Zip(Directory.EnumerateFiles(folder.GetFolderPath(), "*")))
        {
            Assert.Equal(file1, file2);
        }

    }

    [Fact]
    public void MyFolderClass_ReturnFileContext()
    {
        var path = "/home/navid/test/";

        MyFolder folder = new MyFolder(path);
        
        var fileContext = folder.GetFileContext();

        foreach (var (context, file) in fileContext.Zip(Directory.EnumerateFiles(folder.GetFolderPath(), "*")))
        {
            string contents = File.ReadAllText(file);

            Assert.Equal(context, contents);
        }

    }

}