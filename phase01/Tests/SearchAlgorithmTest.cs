namespace Tests;
using SearchAlgorithm;
using FileReader;

public class SearchAlgorithmTest
{

    [Theory]
    [InlineData("test")]
    // [InlineData("navd nasiri")]
    // [InlineData("navid + nasiri")]
    public void InvertedIndexClass_ReturnValue(string myTerm)
    {
        string folderPath = "/home/navid/test/";

        MyFolder folderData = new MyFolder(folderPath);

        InvertedIndex invAlgorithm = new InvertedIndex(
            folderData.GetFileName(),
            folderData.GetFileContext()
        );

        invAlgorithm.CreateHashtable();

        string dist = invAlgorithm.FindTerm(myTerm);

        string realAns = "/home/navid/test/text3, /home/navid/test/text4, /home/navid/test/text5, /home/navid/test/text, /home/navid/test/text2, ";

        Assert.Equal(dist, realAns);

    }





}