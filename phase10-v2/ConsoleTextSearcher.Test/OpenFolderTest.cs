using ConsoleTextSearcher.Classes;
using ConsoleTextSearcher.Interfaces;

namespace ConsoleTextSearcher.Test;

public class OpenFolderTest
{
    IOpenFolder folderObj = new OpenFolder();
    public static IEnumerable<object[]> Data()
    {
        yield return new object[] { new List<string> { "name/1/2", "name/2/3", "name/3/4" } };
        yield return new object[] { new List<string> { "name", "name 2", "name 3", "name 4" } };
    }

    [Theory]
    [InlineData("Th1sIsapassword!")]

    public void FolderPath_GetSet(string path)
    {
        folderObj.FolderPath = path;
        Assert.Equal(path, folderObj.FolderPath);
    }


    [Theory]
    [MemberData(nameof(Data))]
    public void FileNames_GetSet(List<string> testList)
    {
        folderObj.FileNames = testList;
        Assert.Equal(folderObj.FileNames, testList);

    }

    [Theory]
    [MemberData(nameof(Data))]
    public void FileContents_GetSet(List<string> testList)
    {
        folderObj.FileContents = testList;
        Assert.Equal(folderObj.FileContents, testList);

    }

    [Theory]
    [InlineData("/ConsoleTextSearcher.Test/TestCases/")]
    public void ReadFolderContents_ReturnTrue(string folderPath)
    {
        string baseDir = Directory.GetParent(System.Environment.CurrentDirectory).Parent.Parent.Parent.ToString();
        var res = folderObj.ReadFolderContents(baseDir + folderPath);
        Assert.True(res);
    }


    [Theory]
    [InlineData("./FakePath")]
    public void ReadFolderContents_ReturnFalse(string folderPath)
    {
        var res = folderObj.ReadFolderContents(folderPath);
        Assert.False(res);
    }

}