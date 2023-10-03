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

    // Constructor
    public InvertedIndex(List<string> fileNames, List<string> fileContext)
    {
        this.fileContext = fileContext;
        this.fileName = fileNames;

    }

    // Private Methods
    private void PrepareContextText(){
        var removedList = new string [] {
            "@", ",", ".", ";", "'","\n",
            "  ", "   ", "    ", "     ",
            "?", "!", "#", "%", "$", "^",
            "&", "*", "(", ")", "-", "_"
            // ,"and", "is", "are", "or"
        };

        for (int i=0; i < this.fileContext.Count ; i++)
        {
            foreach (var c in removedList)
            {
                this.fileContext[i] = this.fileContext[i].Replace(
                    c, " "
                );
                
            }
        }
    }
    
    private void CreateAllTerms(){

        this.PrepareContextText();

        foreach (string context in this.fileContext){
            List<string> splitedContext = context.ToLower().
            Split(' ').ToList().
            Distinct().ToList();

            this.allTerms = this.allTerms.Union(splitedContext).ToList();
        }
    }
    
    // Public Methods
    public void CreateHashtable(){
        this.CreateAllTerms();

        foreach (string item in this.allTerms){
            StringBuilder hashVal = new StringBuilder(); 
            foreach (var (fName, fContext) in this.fileName.Zip(this.fileContext)){
                if(fContext.Contains(item) == true){
                    hashVal.Append(fName);
                    hashVal.Append(" , ");
                }
                
            }
            this.invertedIndexTable.Add(
                item,
                hashVal.ToString()
            );
        }
    }
    
    public string FindTerm(string term){
        if(this.invertedIndexTable.ContainsKey(term))
            return this.invertedIndexTable[term].ToString();
        return "\nError: Not Found\n";
    }
    
    public void WriteHashTable()
    {
        foreach (DictionaryEntry de in this.invertedIndexTable)
            Console.WriteLine("{0} : {1}", de.Key, de.Value);

    }

}
