namespace Backend3withMain;
class Program
{
    static void Main(string[] args)
    {  
        Console.Clear();

        // get input tags from user
        Console.WriteLine("Enter tags separated by comma:");
        string userInputTags = Console.ReadLine();

        List<string> tagsList = ParseTags(userInputTags);
        TagPrinter.Print(tagsList);

    }
    static List<string> ParseTags(string input)
    {
        string[] tagsArray = input.Split(",");
        List<string> tagsList = new List<string>();
        
        foreach (string item in tagsArray)
        {
            // cleanup the tag 
            string cleanedItem = item.Trim();
            tagsList.Add(cleanedItem); 
        }

        return tagsList;
    }

}