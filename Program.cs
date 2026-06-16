namespace Backend3withMain;
class Program
{
    static void Main(string[] args)
    {  
        Greeter.Greet(); // invoke Greet method 
        Greeter.Greet("God morgen"); // invoke the Greet method overload that supports a string as argument
        Greeter.Greet("You are ", 20); // // invoke the Greet method overload that supports a string (message) as argument and a number (age) as second argument
    }
}