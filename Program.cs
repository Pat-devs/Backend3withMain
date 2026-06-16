namespace Backend3withMain;
class Program
{
    static void Main(string[] args)
    {  
        Console.Clear();
        // user writes their words, separeted by comma
        string userInputWords = "coffee,tea,milk";
        // .Split is useful to convert strings into array by a common separator symbol
        string[] words = userInputWords.Split(",");

        foreach(string word in words)
        {
            Console.WriteLine(word);
        }
    }
}