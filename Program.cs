namespace Backend3withMain;
class Program
{
    static void Main(string[] args)
    {  
        // user writes their words, separeted by comma
        //string userInputWords = "coffee;tea,milk";
        // .Split is useful to convert strings into array by a common separator symbol
        //string[] words = userInputWords.Split("e");

        //foreach(string word in words)
        //{
        //    Console.WriteLine(word);
        //}
        string whateverText = "omglolah0iu8y7gtyadklhh";

        string[] things = whateverText.Split("0");

        Console.Clear();

        foreach (string x in things)
        {
            Console.WriteLine();
            Console.WriteLine(x);
        }
    }
}