namespace Backend3withMain;
class Program
{
    static void Main(string[] args)
    {
        // example of overloads
        Greet("Hi", "Patryk", 1234); // string
    }
    
    // Greet passes the (String) data to Console.WriteLine
    static void Greet(string data)
    {
        Console.WriteLine(data);
    }
    static void Greet(string data, string moreData)
    {
        Console.WriteLine(data + moreData);
    }
    static void Greet(string data, string moreData, int evenMoreData)
    {
        Console.WriteLine(data + moreData + evenMoreData);
    }
}
