class Greeter
{
    public static void Greet() // default version of greet, takes no arguments
    {
        Console.WriteLine("Hello world!");
    }
    public static void Greet(string message) // overload with message as argument
    {
        Console.WriteLine(message);
    }
    public static void Greet(string message, int age) // overload with message and users age
    {
        Console.WriteLine(message + " you are " + age + " years old.");
    }
}