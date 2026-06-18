using System.Security.Cryptography;

namespace Backend3withMain;
class Program
{
    static void Main(string[] args)
    {  

        // initialize the tagslist as an empty list
        List<string> tagsList = new List<string>();

        Console.Clear();
        bool running = true;

        while (running)
        {       
            Console.WriteLine("Tag manager");
            Console.WriteLine("1. Enter new tags");
            Console.WriteLine("2. Show current tags");
            Console.WriteLine("3. Exit");
            Console.WriteLine();
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                // get input tags from user
                Console.WriteLine("Enter tags separated by comma:");
                string userInputTags = Console.ReadLine();
                tagsList = ParseTags(userInputTags);
            }
            else if (choice == "2")
            {
                TagPrinter.Print(tagsList);
            }
            else if (choice == "3")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("invalid choice");
            }

            //running = false;
        }

    }
    static List<string> ParseTags(string input)
    {
        // TODO-idea; check if tag already exists
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