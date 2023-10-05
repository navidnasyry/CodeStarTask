namespace Tests;
using SearchAlgorithm;
using FileReader;

public class SearchAlgorithmTest
{
    private string baseDir = Directory.GetParent(System.Environment.CurrentDirectory).Parent.Parent.Parent.ToString();
    private string testDirectoryPath = "/Tests/testDir/";

    [Theory]
    [InlineData("test")]
    // [InlineData("navd nasiri")]
    // [InlineData("navid + nasiri")]
    public void InvertedIndexClass_ReturnValue(string myTerm)
    {
        // string folderPath = "/home/navid/test/";

        MyFolder folderData = new MyFolder(this.baseDir + this.testDirectoryPath);

        InvertedIndex invAlgorithm = new InvertedIndex(
            folderData.GetFileName(),
            folderData.GetFileContext()
        );

        invAlgorithm.CreateHashtable();

        string dist = invAlgorithm.FindTerm(myTerm);

        string realAns = this.baseDir + this.testDirectoryPath + "text5" + ", " ;

        Assert.Equal(dist, realAns);

    }





}