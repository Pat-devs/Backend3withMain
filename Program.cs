namespace Backend3withMain;
class Program
{
    static void Main(string[] args)
    {

        // example of overloads
        Person.Greet("hi");
        
    }
    
    // Greet passes the (String) data to Console.WriteLine
    static void Greet(string data)
    {
        Console.WriteLine(data);
    }
}

class Person
{
    // class properties?
    public string Name { get; set; }
    // The very weird looking `{ get; set; }` must be there. We will explain this later :)


    static void showPersonalNumber()
    {
        Console.WriteLine(12345678);
    }

    // Greet function, prints users name and a greeting
    public static void Greet(string data)
    {
        Console.WriteLine(data);
    }
}