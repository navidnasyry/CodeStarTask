using System.Collections;
using System.Text;
namespace SearchAlgorithm;

public class InvertedIndex
{

    // Fields
    private Hashtable invertedIndexTable = new Hashtable();
    private List<string> fileName = new List<string>();
    private List<string> fileContext = new List<string>();
    private List<string> allTerms = new List<string>();
    private string[] removedCharList = new string[] {
            "@", ",", ".", ";", "'","\n",
            "  ", "   ", "    ", "     ",
            "?", "!", "#", "%", "$", "^",
            "&", "*", "(", ")", "-", "_"
        };

    // Constructor
    public InvertedIndex(List<string> fileNames, List<string> fileContext)
    {
        this.fileContext = fileContext;
        this.fileName = fileNames;

    }

    // Private Methods
    private void PrepareContextText()
    {

        for (int i = 0; i < this.fileContext.Count; i++)
        {
            foreach (var c in this.removedCharList)
            {
                this.fileContext[i] = this.fileContext[i].Replace(
                    c, " "
                );

            }
        }
    }

    private void CreateAllTerms()
    {

        this.PrepareContextText();

        foreach (string context in this.fileContext)
        {
            List<string> splitedContext = context.ToLower().
            Split(' ').ToList().
            Distinct().ToList();

            this.allTerms = this.allTerms.Union(splitedContext).ToList();
        }
    }

    private List<string> FindSingleWordContexes(string searchedWord)
    {
        return this.invertedIndexTable[searchedWord].ToString().Split(", ").ToList();
    }
    // Public Methods
    public void CreateHashtable()
    {
        this.CreateAllTerms();

        foreach (string item in this.allTerms)
        {
            StringBuilder hashVal = new StringBuilder();
            foreach (var (fName, fContext) in this.fileName.Zip(this.fileContext))
            {
                if (fContext.Contains(item) == true)
                {
                    hashVal.Append(fName);
                    hashVal.Append(", ");
                }

            }
            this.invertedIndexTable.Add(
                item,
                hashVal.ToString()
            );
        }
    }

    public string FindTerm(string term)
    {

        List<string> resultList = new List<string>();
        List<string> splitedTerms = term.Split(' ').ToList();
        for (int i = 0; i < splitedTerms.Count; i++)
        {
            if (this.invertedIndexTable.ContainsKey(splitedTerms[i]))
            {

                if (i == 0)
                {
                    List<string> findedList = this.FindSingleWordContexes(splitedTerms[i]);
                    resultList = resultList.Union(findedList).ToList();
                    continue;
                }
                if (splitedTerms[i - 1] == "+")
                {
                    // implement OR 
                    List<string> findedList = this.FindSingleWordContexes(splitedTerms[i]);
                    resultList = resultList.Union(findedList).ToList();
                    continue;
                }
                else if (splitedTerms[i - 1] == "-")
                {
                    // implement Exclude
                    List<string> removedResults = this.FindSingleWordContexes(splitedTerms[i]);
                    resultList = resultList.Except(removedResults).ToList();
                    continue;
                }
                else
                {
                    // implement AND 
                    List<string> andResult = this.FindSingleWordContexes(splitedTerms[i]);

                    List<string> list_1 = andResult.Except(resultList).ToList();

                    List<string> list_2 = resultList.Except(andResult).ToList();

                    List<string> concatedLists = list_2.Concat(list_1).ToList();

                    resultList = resultList.Union(andResult).Except(concatedLists).ToList();

                    continue;
                }
            }
        }
        return String.Join(", ", resultList);
    }

    public void WriteHashTable()
    {
        foreach (DictionaryEntry de in this.invertedIndexTable)
            Console.WriteLine("{0} : {1}", de.Key, de.Value);

    }

}
