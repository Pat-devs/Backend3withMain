namespace Backend3withMain;
class Program
{
    static void Main(string[] args)
    {  
        Console.Clear();
        // user writes their words, separeted by comma
        string userInputTags = "coffee,tea,milk";
        // .Split is useful to convert strings into array by a common separator symbol
        string[] tagsArray = userInputTags.Split(",");

        // if we have an array, but suddenly need a list:
        // 1. Declare an empty list:
        List<string> tagsList = new List<string>();
        // 2. fill the list with items from the array
        foreach (string item in tagsArray) // item is the tag in the tagsArray
        {
            tagsList.Add(item); 
        }

        TagPrinter.Print(tagsList);

    }
}