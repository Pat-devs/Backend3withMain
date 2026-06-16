class Greeter
{
    public static void Greet() // default version of greet, takes no arguments
    {
        Console.WriteLine("Hello world!");
    }
    public static void Greet(string message)
    {
        Console.WriteLine(message);
    }
}