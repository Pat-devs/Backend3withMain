namespace Backend3withMain;
class Program
{
    static void Main(string[] args)
    {
        //string Name = "Lol";

        // example of overloads
        Person.Greet("hi");

        Person.Name = "test";
        
        Console.WriteLine(Person.Name);

        
    }
    
    // Greet passes the (String) data to Console.WriteLine
    static void Greet(string data)
    {
        Console.WriteLine(data);
    }
}

// a custom class (note this should normally go into its own file)
class Person
{
    // class properties? (static properties -- similar to "normal" variables)
    public static string Name { get; set; }
    // The very weird looking `{ get; set; }` must be there. We will explain this later :)
    public static int Age { get; set; }

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