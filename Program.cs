namespace Backend3withMain;
class Program
{
    static void Main(string[] args)
    {
        // example of overloads
        Greet("Hi");
        Greet(1234);
    }
    
    // Greet passes the (String) data to Console.WriteLine
    static void Greet(string data)
    {
        Console.WriteLine(data);
    }
    // Interger friendly overload of Greet.
    static void Greet(int data)
    {
        Console.WriteLine(data);
    }
}
