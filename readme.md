# Backend uke 3

## NB! KI Bruksnotat: *Følgende tekst ble genereret vha. ChatGPT 5.5 utfra mine commit kommentarer, commit innhold og noe ekstra prompting. Det aller meste skal være korrekt men det kan være noen ting er litt uklart.*

## Week 3: Main Method, Overloads, Static Classes, Tag Parsing, Menus, and Files

In this third week, we moved from basic methods and collection examples toward a more structured C# console application.

The main direction of the week was:

> How do we organize a program into methods and classes, then use those pieces to build a small tag manager app?

This week covered:

* Creating a console project with an explicit `Main` method
* Understanding that code should run inside `Main`
* Passing command-line arguments into `Main`
* Built-in method overloads
* Custom method overloads
* Overloads with different parameter types
* Overloads with different numbers of parameters
* The special `char` overload edge case
* A very basic introduction to classes
* Static properties and static methods
* Moving helper methods into a separate class file
* Calling methods from another class
* Creating a `TagPrinter` class
* Using method overloads to print one tag or many tags
* Splitting comma-separated text with `.Split(",")`
* Converting an array into a list manually
* Replacing hardcoded values with real user input
* Extracting parsing logic into a method
* Returning a `List<string>` from a method
* Cleaning tag input with `.Trim()`
* Building a repeating menu with `while`
* Using a `bool running` variable to stop a menu loop
* Changing menu choice handling from `string` to `int`
* Using `int.TryParse`
* Seeing how `out` works through `TryParse`
* Saving tags to a text file with `File.WriteAllLines`
* Loading tags from a text file with `File.ReadAllLines`
* Checking whether a file exists with `File.Exists`

Important note:

Some possible topics were discussed or suggested, but were **not fully implemented in the repository** during this week.

For example, the repository does **not** yet fully implement:

* Skipping empty tags after trimming
* Handling `Console.ReadLine()` with `?? ""`
* Giving a separate error message when `TryParse` fails
* Appending to a file instead of replacing it
* Deleting files
* Creating or deleting folders
* More advanced file formats
* Full exception handling with `try/catch`

Those are good next-step improvements, but this document focuses on what was actually covered in the repository.

---

# Session 1: Explicit Main, CLI Arguments, and Method Overloads

Session 1 focused on understanding the shape of a C# console program when using an explicit `Main` method. It also introduced overloads using both built-in methods and custom methods.

---

## Commit 1: `setup empty project with --program-main`

### Learning objective

Set up a new console project that uses an explicit `Main` method instead of only top-level statements.

### Code changes

The project starts with the basic files:

```bash
dotnet new console --use-program-main
dotnet new gitignore
```

The important program shape is:

```csharp
namespace Backend3withMain;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
```

### Explanation for beginners

In earlier beginner projects, C# may have allowed us to write code directly in `Program.cs`.

This week, we used a more explicit structure:

```csharp
class Program
{
    static void Main(string[] args)
    {
        // code goes here
    }
}
```

The most important beginner rule is:

> The program starts running inside `Main`.

This means code that should run when the program starts belongs inside:

```csharp
static void Main(string[] args)
{
}
```

For now, we do not need to understand every word deeply.

Beginner meaning:

* `class Program` is a container for program code.
* `Main` is the starting method.
* The code inside `{ }` runs when the program starts.
* `string[] args` can receive arguments from the terminal.

### Mini tasks

1. Find the `Main` method in `Program.cs`.
2. Add a second `Console.WriteLine`.
3. Change `"Hello, World!"` to your own message.
4. Explain where the program starts.
5. Add a comment inside `Main`.

### Expected outcome

The learner should understand that the explicit `Main` method is the starting point of the console program.

---

## Commit 2: `show example of supplying an argument from the terminal (CLI)`

### Learning objective

Introduce command-line arguments using `string[] args`.

### Code changes

The program changes from printing a fixed message to printing the first terminal argument:

```csharp
Console.WriteLine(args[0]);
```

Example terminal command:

```bash
dotnet run "god morgen"
```

Expected output:

```text
god morgen
```

### Explanation for beginners

The `Main` method contains this:

```csharp
static void Main(string[] args)
```

The name `args` means arguments.

Arguments are extra values we can send to the program when starting it from the terminal.

Example:

```bash
dotnet run "god morgen"
```

This sends the text `"god morgen"` into the program.

Inside the program, it can be accessed with:

```csharp
args[0]
```

Important:

Indexes start at `0`.

So the first argument is:

```csharp
args[0]
```

A beginner warning:

If we run the program without an argument:

```bash
dotnet run
```

then `args[0]` does not exist, and the program can crash.

This is because we are asking for the first item in an array that may be empty.

### Mini tasks

1. Run the program with one argument.
2. Run the program with a different argument.
3. Try running it without an argument and observe what happens.
4. Explain why `args[0]` means the first argument.
5. Try sending two arguments and print `args[1]`.

### Expected outcome

The learner should understand that `string[] args` can receive text from the terminal when starting a program.

---

## Commit 3: `coding example with the main-method in program.cs`

### Learning objective

Reinforce that code must be written inside the `Main` method.

### Code changes

The command-line argument example is replaced with a simpler example:

```csharp
static void Main(string[] args)
{
    // we need to write code inside here
    Console.WriteLine("hello");
}

// no code here.
```

### Explanation for beginners

This commit emphasizes code placement.

Code inside `Main` runs:

```csharp
static void Main(string[] args)
{
    Console.WriteLine("hello");
}
```

Code outside the class or outside the method is not where normal program instructions should go.

The comment:

```csharp
// no code here.
```

is a reminder that we should not write normal program steps after the class has ended.

Beginner rule:

> Program instructions go inside methods.

For now, the most important method is `Main`.

### Mini tasks

1. Add another print line inside `Main`.
2. Try writing a print line outside `Main` and see what error appears.
3. Explain why the comment says `// no code here`.
4. Move the print line back inside `Main`.
5. Add a comment explaining what `Main` does.

### Expected outcome

The learner should understand the difference between code inside a method and code outside a method.

---

## Commit 4: `using built in overloads in the "Console.WriteLine" method.`

### Learning objective

Introduce overloads using a method students already know: `Console.WriteLine`.

### Code changes

The program prints different types of values:

```csharp
Console.WriteLine("Hi");   // string
Console.WriteLine(1234);   // int
Console.WriteLine('A');    // char
```

### Explanation for beginners

We have used `Console.WriteLine` many times.

This commit shows that `Console.WriteLine` can accept different types of input.

It can print a string:

```csharp
Console.WriteLine("Hi");
```

It can print an int:

```csharp
Console.WriteLine(1234);
```

It can print a char:

```csharp
Console.WriteLine('A');
```

This works because `Console.WriteLine` has several versions.

These versions are called **overloads**.

Beginner explanation:

> An overload is another version of the same method name, but with different parameters.

So `Console.WriteLine` is not just one method. It has multiple versions, and C# chooses the version that matches the value we give it.

### Mini tasks

1. Print your name using `Console.WriteLine`.
2. Print your age as an integer.
3. Print one character using single quotes.
4. Explain the difference between `"A"` and `'A'`.
5. Write three `Console.WriteLine` calls with three different value types.

### Expected outcome

The learner should understand that built-in methods can have multiple overloads.

---

## Commit 5: `Creating a method with an overload`

### Learning objective

Create custom method overloads.

### Code changes

The program creates two `Greet` methods.

One accepts a `string`:

```csharp
static void Greet(string data)
{
    Console.WriteLine(data);
}
```

One accepts an `int`:

```csharp
static void Greet(int data)
{
    Console.WriteLine(data);
}
```

The methods are called like this:

```csharp
Greet("Hi");
Greet(1234);
```

### Explanation for beginners

Now we are not only using built-in overloads.

We are creating our own overloads.

These two methods have the same name:

```csharp
Greet
```

But they have different parameter types:

```csharp
string
int
```

So C# can tell which version to use.

When we write:

```csharp
Greet("Hi");
```

C# chooses:

```csharp
static void Greet(string data)
```

When we write:

```csharp
Greet(1234);
```

C# chooses:

```csharp
static void Greet(int data)
```

Beginner rule:

> Methods can share a name if their parameter lists are different.

### Mini tasks

1. Change the string message.
2. Change the integer value.
3. Add a comment above each overload.
4. Try calling `Greet(true)` and observe what happens.
5. Explain why `Greet("Hi")` and `Greet(1234)` call different methods.

### Expected outcome

The learner should understand how to define and call custom overloaded methods.

---

## Commit 6: `custom method with overloads`

### Learning objective

Add a `char` overload and observe how type-specific overloads matter.

### Code changes

The program now calls:

```csharp
Greet("Hi");   // string
Greet(1234);   // int
Greet('Q');    // char
```

A new overload is added:

```csharp
static void Greet(char data)
{
    Console.WriteLine(data);
}
```

### Explanation for beginners

A `char` is a single character.

It uses single quotes:

```csharp
'Q'
```

A string uses double quotes:

```csharp
"Q"
```

This commit adds a method overload specifically for `char`.

```csharp
static void Greet(char data)
{
    Console.WriteLine(data);
}
```

This matters because C# can sometimes convert a `char` to a number behind the scenes.

If there is no `char` overload, C# may choose another compatible overload, such as an `int` overload.

That can lead to surprising output, because characters have numeric codes.

Beginner takeaway:

> If we want a method to handle a `char` in a clear way, we can create a `char` overload.

### Mini tasks

1. Change `'Q'` to another character.
2. Change `'Q'` to `"Q"` and observe the difference.
3. Remove the `char` overload temporarily and see what happens.
4. Explain why `'A'` and `"A"` are not the same type.
5. Add another overload for a different type, such as `bool`.

### Expected outcome

The learner should understand that overloaded methods can behave differently depending on the type of argument.

---

## Commit 7: `using overloads so that our methods can consume different number of arguments`

### Learning objective

Show that overloads can differ by number of parameters, not only by type.

### Code changes

The program uses overloads such as:

```csharp
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
```

The method is called with three arguments:

```csharp
Greet("Hi", "Patryk", 1234);
```

### Explanation for beginners

An overload can differ in two common ways:

1. Different parameter types
2. Different number of parameters

Earlier:

```csharp
Greet("Hi");
Greet(1234);
```

used different types.

Now:

```csharp
Greet("Hi");
Greet("Hi", "Patryk");
Greet("Hi", "Patryk", 1234);
```

can use different numbers of arguments.

C# decides which method to run by looking at the arguments we send.

This is why these can all be valid if the matching methods exist:

```csharp
Greet("Hello");
Greet("Hello", "Patryk");
Greet("Hello", "Patryk", 20);
```

Beginner rule:

> Same method name is allowed when the parameter list is different.

### Mini tasks

1. Call the one-argument version.
2. Call the two-argument version.
3. Call the three-argument version.
4. Add spaces between the combined strings.
5. Explain how C# knows which overload to use.

### Expected outcome

The learner should understand that overloads can use the same method name with different parameter counts.

---

# Session 1 Review

After Session 1, students should be able to answer:

1. What is the `Main` method?
2. Where does a C# console app start running?
3. What is `string[] args`?
4. What is a command-line argument?
5. What does `args[0]` mean?
6. What is a method overload?
7. How can `Console.WriteLine` accept different types?
8. How can we create our own overloaded methods?
9. What is the difference between `"A"` and `'A'`?
10. How can overloads differ by number of arguments?

---

# Session 2: Classes, Static Members, Separate Files, and TagPrinter

Session 2 moved from methods inside `Program.cs` toward classes and separate files. The session ended with a `TagPrinter` class and a first tag-processing example.

---

## Commit 8: `Class example`

### Learning objective

Introduce a very basic custom class.

### Code changes

A `Person` class is added:

```csharp
class Person
{
    public string Name { get; set; }

    static void showPersonalNumber()
    {
        Console.WriteLine(12345678);
    }

    public static void Greet(string data)
    {
        Console.WriteLine(data);
    }
}
```

The program calls:

```csharp
Person.Greet("hi");
```

### Explanation for beginners

A class is a way to group related code.

Here, the class is called:

```csharp
Person
```

Inside the class, there is a method:

```csharp
public static void Greet(string data)
```

We call it like this:

```csharp
Person.Greet("hi");
```

That means:

> Use the `Greet` method that belongs to the `Person` class.

The class also has a property:

```csharp
public string Name { get; set; }
```

The `{ get; set; }` syntax was shown, but not deeply explained yet.

For now, beginner explanation:

> A property is a value that belongs to a class or object.

This was a first look, not a full object-oriented programming lesson.

### Mini tasks

1. Rename `Person` to another class name.
2. Change the greeting text.
3. Add another static method to the class.
4. Explain what `Person.Greet("hi")` means.
5. Identify the property in the class.

### Expected outcome

The learner should have a first mental model of a class as a container for related methods and properties.

---

## Commit 9: `using static class properties and methods`

### Learning objective

Show static properties and static methods.

### Code changes

The `Person` class changes to use static properties:

```csharp
public static string Name { get; set; }
public static int Age { get; set; }
```

The program uses the class like this:

```csharp
Person.Greet("hi");

Person.Name = "test";

Console.WriteLine(Person.Name);
```

### Explanation for beginners

The keyword `static` means we can use the member directly from the class name.

Example:

```csharp
Person.Name = "test";
```

and:

```csharp
Console.WriteLine(Person.Name);
```

We do not create a new `Person` object here.

We use the class directly.

This matches how we have used other static methods:

```csharp
Console.WriteLine(...)
```

and later:

```csharp
TagPrinter.Print(...)
```

Beginner explanation:

> Static means we use the method or property directly from the class.

This week did not go deeply into objects created with `new`. The focus was using static members as helper tools.

### Mini tasks

1. Change `Person.Name` to your own name.
2. Print `Person.Name`.
3. Set `Person.Age`.
4. Print `Person.Age`.
5. Explain why we can write `Person.Name` directly.

### Expected outcome

The learner should understand basic static class access using `ClassName.MemberName`.

---

## Commit 10: `Clean up. And create a static Greeter class, with two simple static overloads of a Greet method.`

### Learning objective

Move helper methods into a separate class file.

### Code changes

A new file is created:

```text
Greeter.cs
```

It contains:

```csharp
class Greeter
{
    public static void Greet()
    {
        Console.WriteLine("Hello world!");
    }

    public static void Greet(string message)
    {
        Console.WriteLine(message);
    }
}
```

`Program.cs` calls the methods:

```csharp
Greeter.Greet();
Greeter.Greet("God morgen");
```

### Explanation for beginners

This commit is important because the program starts to become more organized.

Before this, many examples lived directly in `Program.cs`.

Now we create a separate file:

```text
Greeter.cs
```

The class inside the file is:

```csharp
class Greeter
```

It has two overloaded methods:

```csharp
Greet()
Greet(string message)
```

We call them from `Program.cs`:

```csharp
Greeter.Greet();
Greeter.Greet("God morgen");
```

This shows that code can be split across files.

Beginner rule:

> A class can live in its own file, and `Program.cs` can call methods from that class.

This makes the code easier to read as the project grows.

### Mini tasks

1. Open `Greeter.cs`.
2. Find both `Greet` methods.
3. Change `"Hello world!"` to another default message.
4. Call `Greeter.Greet("Hei!")` from `Program.cs`.
5. Explain why separate files can make a project easier to manage.

### Expected outcome

The learner should understand that helper classes can be placed in separate files and called from `Program.cs`.

---

## Commit 11: `added`

### Learning objective

Add another overload to the `Greeter` class with more than one argument.

### Code changes

A new overload is added:

```csharp
public static void Greet(string message, int age)
{
    Console.WriteLine(message + " you are " + age + " years old.");
}
```

The method is called like this:

```csharp
Greeter.Greet("You are ", 20);
```

### Explanation for beginners

This continues the overload idea from Session 1.

The `Greeter` class now has more than one version of `Greet`.

One version takes no arguments:

```csharp
Greeter.Greet();
```

One version takes one string:

```csharp
Greeter.Greet("God morgen");
```

One version takes a string and an int:

```csharp
Greeter.Greet("You are ", 20);
```

C# chooses the correct method by looking at the arguments.

Beginner takeaway:

> The same method name can support different use cases if we create overloads.

### Mini tasks

1. Change the age value.
2. Change the message.
3. Add a space if the output looks crowded.
4. Try calling `Greeter.Greet(20)` and observe what happens.
5. Explain why `Greeter.Greet("Hello")` and `Greeter.Greet("Hello", 20)` call different methods.

### Expected outcome

The learner should understand overloads inside a separate helper class.

---

## Commit 12: `create a TagPrinter class with a Print method with 2 overloads`

### Learning objective

Create a practical utility class for printing tags, and connect overloads to a real mini-project.

### Code changes

A new class is created:

```csharp
class TagPrinter
{
    public static void Print(string tag)
    {
        Console.WriteLine("Tag: ");
        Console.WriteLine("#" + tag);
    }

    public static void Print(List<string> tags)
    {
        Console.WriteLine("Tags: ");

        foreach (string tag in tags)
        {
            Console.WriteLine("#" + tag);
        }
    }
}
```

The program also works with comma-separated tags:

```csharp
string userInputTags = "coffee,tea,milk";
string[] tagsArray = userInputTags.Split(",");

List<string> tagsList = new List<string>();

foreach (string item in tagsArray)
{
    tagsList.Add(item);
}

TagPrinter.Print(tagsList);
```

### Explanation for beginners

This commit connects several ideas:

* Strings
* `.Split(",")`
* Arrays
* Lists
* `foreach`
* Static helper classes
* Method overloads

The input starts as one string:

```csharp
"coffee,tea,milk"
```

Then this line splits it into an array:

```csharp
string[] tagsArray = userInputTags.Split(",");
```

The comma is used as the separator.

So the text becomes separate pieces:

```text
coffee
tea
milk
```

Then we create a list:

```csharp
List<string> tagsList = new List<string>();
```

And copy the array items into the list:

```csharp
foreach (string item in tagsArray)
{
    tagsList.Add(item);
}
```

Finally, we print all tags:

```csharp
TagPrinter.Print(tagsList);
```

Because `TagPrinter` has two overloads, it can print:

One tag:

```csharp
TagPrinter.Print("coffee");
```

or a list of tags:

```csharp
TagPrinter.Print(tagsList);
```

### Mini tasks

1. Change the hardcoded tag string.
2. Add spaces after commas and observe the output.
3. Add another tag.
4. Call `TagPrinter.Print("coffee")`.
5. Call `TagPrinter.Print(tagsList)`.
6. Explain why `Print(string tag)` and `Print(List<string> tags)` are overloads.

### Expected outcome

The learner should understand how `.Split`, arrays, lists, loops, and overloaded helper methods can work together.

---

# Session 2 Review

After Session 2, students should be able to answer:

1. What is a class?
2. What does `static` allow us to do?
3. What is a static method?
4. What is a static property?
5. Why might we move a class into its own file?
6. What does `Greeter.Greet()` mean?
7. What does `TagPrinter.Print(tagsList)` mean?
8. What does `.Split(",")` do?
9. Why does `.Split(",")` return an array?
10. How can we copy array items into a list?
11. Why is `TagPrinter.Print(string)` different from `TagPrinter.Print(List<string>)`?
12. Why are overloads useful in real code?

---

# Session 3: User Input, Parsing Methods, Menus, TryParse, and File Saving

Session 3 turned the tag-printing example into a small interactive console application.

The final project became a simple tag manager where the user can:

1. Enter tags
2. Show current tags
3. Save tags to a file
4. Load tags from a file
5. Exit

---

## Commit 13: `replace hard coded tags with actual user input. Move code related to Parsing of tags into its own method.`

### Learning objective

Replace hardcoded data with user input and extract parsing logic into a method.

### Code changes

The hardcoded string:

```csharp
string userInputTags = "coffee,tea,milk";
```

is replaced with:

```csharp
Console.WriteLine("Enter tags separated by comma:");
string userInputTags = Console.ReadLine();
```

The parsing logic is moved into a method:

```csharp
static List<string> ParseTags(string input)
{
    string[] tagsArray = input.Split(",");
    List<string> tagsList = new List<string>();

    foreach (string item in tagsArray)
    {
        string cleanedItem = item.Trim();
        tagsList.Add(cleanedItem);
    }

    return tagsList;
}
```

Then `Main` uses the method:

```csharp
List<string> tagsList = ParseTags(userInputTags);
TagPrinter.Print(tagsList);
```

### Explanation for beginners

This commit makes the app more realistic.

Instead of the programmer deciding the tags ahead of time:

```csharp
"coffee,tea,milk"
```

the user can type tags while the program runs.

Example:

```text
coffee, tea, milk
```

The method:

```csharp
ParseTags
```

has one job:

> Convert one input string into a `List<string>` of tags.

A method can:

1. Receive input
2. Do work
3. Return a result

Here, the method receives:

```csharp
string input
```

It does work:

```csharp
input.Split(",");
item.Trim();
tagsList.Add(cleanedItem);
```

It returns:

```csharp
return tagsList;
```

The return type is:

```csharp
List<string>
```

So this line:

```csharp
List<string> tagsList = ParseTags(userInputTags);
```

means:

> Parse the user input and store the returned list in `tagsList`.

### Important note about `.Trim()`

The method uses:

```csharp
string cleanedItem = item.Trim();
```

`.Trim()` removes spaces from the start and end of a string.

Example:

```csharp
" tea ".Trim()
```

becomes:

```text
tea
```

This helps when the user writes:

```text
coffee, tea, milk
```

Without `.Trim()`, the second tag might contain a space:

```text
" tea"
```

With `.Trim()`, it becomes:

```text
"tea"
```

### Important note about what is not finished yet

The repository version trims tags, but it does **not** yet skip empty tags.

So if the user writes:

```text
coffee,,tea
```

the program may still add an empty string as a tag.

A possible future improvement is:

```csharp
if (cleanedItem != "")
{
    tagsList.Add(cleanedItem);
}
```

### Mini tasks

1. Run the program and enter `coffee,tea,milk`.
2. Run the program and enter `coffee, tea, milk`.
3. Explain what `.Split(",")` does.
4. Explain what `.Trim()` does.
5. Add an `if` statement to skip empty tags.
6. Explain what `ParseTags` receives and what it returns.

### Expected outcome

The learner should understand how user input can be converted into a cleaned list using a helper method.

---

## Commit 14: `add proper menu with choices.`

### Learning objective

Build a repeating menu using `while` and a `running` Boolean.

### Code changes

The program creates an empty tag list before the loop:

```csharp
List<string> tagsList = new List<string>();
```

It creates a running flag:

```csharp
bool running = true;
```

Then it uses a loop:

```csharp
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
}
```

### Explanation for beginners

A menu is not very useful if it appears only once.

A user may want to:

1. Enter tags
2. Show tags
3. Enter new tags
4. Show tags again
5. Exit

That requires repetition.

The loop:

```csharp
while (running)
```

means:

> Keep repeating while `running` is true.

At the start:

```csharp
bool running = true;
```

So the menu runs.

When the user chooses exit:

```csharp
running = false;
```

The loop condition becomes false, and the program stops repeating.

The tag list is created before the loop:

```csharp
List<string> tagsList = new List<string>();
```

That is important because the list needs to survive between menu choices.

If the list were created inside the loop, it could reset every time the menu repeats.

### Mini tasks

1. Choose option `2` before entering tags.
2. Choose option `1` and enter tags.
3. Choose option `2` again.
4. Choose option `3` to exit.
5. Choose an invalid option.
6. Explain why `tagsList` is created before the loop.

### Expected outcome

The learner should understand how a `while` loop can keep a menu-based program running.

---

## Commit 15: `change choice from string to int, and handle its type error with int.TryParse`

### Learning objective

Change menu input from text comparison to number parsing using `int.TryParse`.

### Code changes

The menu choice changes from:

```csharp
string choice = Console.ReadLine();
```

to:

```csharp
int choice = 0;

bool isInputValid = int.TryParse(Console.ReadLine(), out choice);
```

The comparisons change from strings:

```csharp
if (choice == "1")
```

to integers:

```csharp
if (choice == 1)
```

### Explanation for beginners

Earlier, menu choices were compared as text:

```csharp
if (choice == "1")
```

That works, but this commit changes the menu choice into a number.

We cannot safely do this:

```csharp
int choice = int.Parse(Console.ReadLine());
```

because the user might type:

```text
abc
```

and the program could crash.

Instead, we use:

```csharp
bool isInputValid = int.TryParse(Console.ReadLine(), out choice);
```

This line does two things:

1. It returns `true` or `false` into `isInputValid`.
2. It puts the converted number into `choice` if the conversion works.

### What `TryParse` means

`TryParse` means:

> Try to convert this text into a number.

If it works:

```text
input: "3"
isInputValid: true
choice: 3
```

If it fails:

```text
input: "abc"
isInputValid: false
choice: 0
```

The program does not crash.

### What `out` means

The keyword `out` allows the method to send back an extra value.

This method already returns a Boolean:

```csharp
bool isInputValid = ...
```

But it also needs to give us the parsed number.

So it uses:

```csharp
out choice
```

Beginner explanation:

> `TryParse` returns whether parsing worked, and sends the parsed number back through the `out` variable.

### Important note about the repository version

The repository stores the result in:

```csharp
bool isInputValid
```

but the current code does not yet use `isInputValid` in an `if` statement.

That means invalid input still falls through to:

```csharp
Console.WriteLine("invalid choice");
```

A future improvement would be:

```csharp
if (!isInputValid)
{
    Console.WriteLine("Please enter a number.");
}
else if (choice == 1)
{
    // enter tags
}
```

That would let the app separate two cases:

* `"abc"` means not a number
* `99` means number, but not a valid menu choice

### Mini tasks

1. Enter `1`.
2. Enter `2`.
3. Enter `3`.
4. Enter `abc`.
5. Enter `99`.
6. Print `isInputValid` after `TryParse`.
7. Add an `if (!isInputValid)` check.

### Expected outcome

The learner should understand why `TryParse` is safer than `Parse`, and how `out` helps return the parsed number.

---

## Commit 16: `add write (tagsList) to files support`

### Learning objective

Add basic file saving with `File.WriteAllLines`.

### Code changes

The menu changes from:

```text
1. Enter new tags
2. Show current tags
3. Exit
```

to:

```text
1. Enter new tags
2. Show current tags
3. Save tags
4. Load tags
5. Exit
```

Saving is added:

```csharp
else if (choice == 3)
{
    string filePath = "taglist.txt";
    File.WriteAllLines(filePath, tagsList);
}
```

A file named `taglist.txt` is also added with example content:

```text
test
code
coffee
```

### Explanation for beginners

This commit introduces file saving.

A program normally forgets its variables when it stops.

For example, this list exists while the program is running:

```csharp
List<string> tagsList = new List<string>();
```

But when the program closes, the list in memory disappears.

To remember data after the program closes, we can save it to a file.

This line writes the list to a text file:

```csharp
File.WriteAllLines(filePath, tagsList);
```

The file path is:

```csharp
string filePath = "taglist.txt";
```

So the program writes to a file called:

```text
taglist.txt
```

`WriteAllLines` writes each list item as one line in the file.

If the list contains:

```text
coffee
tea
milk
```

then the file becomes:

```text
coffee
tea
milk
```

### Important warning

`File.WriteAllLines` replaces the file content.

If `taglist.txt` already contains old tags, this line overwrites the file with the current list:

```csharp
File.WriteAllLines(filePath, tagsList);
```

Beginner explanation:

> `WriteAllLines` saves a fresh version of the file.

It does not append to the end.

### Mini tasks

1. Enter some tags.
2. Choose save.
3. Open `taglist.txt`.
4. Change the tags and save again.
5. Check whether the file was replaced.
6. Explain why saving to a file is different from keeping data in a variable.

### Expected outcome

The learner should understand how to write a list of strings to a text file.

---

## Commit 17: `add loading tagslist from file`

### Learning objective

Load saved tags from a file using `File.Exists` and `File.ReadAllLines`.

### Code changes

The load option is implemented:

```csharp
else if (choice == 4)
{
    string filePath = "taglist.txt";

    if (File.Exists(filePath))
    {
        string[] savedTags = File.ReadAllLines(filePath);
        tagsList = new List<string>(savedTags);

        Console.WriteLine("Tags loaded from disk.");
    }
    else
    {
        Console.WriteLine("Tags failed to load!");
    }
}
```

### Explanation for beginners

Saving writes data to a file.

Loading reads data back from a file.

Before reading, the program checks if the file exists:

```csharp
if (File.Exists(filePath))
```

This asks:

> Is there a file called `taglist.txt`?

If the file exists, the program reads all lines:

```csharp
string[] savedTags = File.ReadAllLines(filePath);
```

`ReadAllLines` returns a string array.

If the file contains:

```text
test
code
coffee
```

then `savedTags` becomes an array with three strings:

```csharp
["test", "code", "coffee"]
```

The program then converts the array into a list:

```csharp
tagsList = new List<string>(savedTags);
```

This matters because the rest of the app works with a `List<string>`.

### Why use `File.Exists`?

If we try to read a file that does not exist:

```csharp
File.ReadAllLines(filePath);
```

the program can crash.

So we check first:

```csharp
if (File.Exists(filePath))
```

Beginner explanation:

> Before reading the file, check that the file is actually there.

### Mini tasks

1. Delete or rename `taglist.txt`, then try loading.
2. Restore `taglist.txt`, then try loading again.
3. Add new lines manually to `taglist.txt`.
4. Load the file and show tags.
5. Explain why `ReadAllLines` gives us an array.
6. Explain why we convert that array into a list.

### Expected outcome

The learner should understand how to load saved text data into a list.

---

# Final Code Shape

By the end of the week, the project has two main code files:

```text
Program.cs
TagPrinter.cs
```

It also has a saved data file:

```text
taglist.txt
```

## Program.cs

The final program:

* Creates an empty `List<string>`
* Shows a menu repeatedly
* Reads a menu choice
* Uses `int.TryParse`
* Lets the user enter comma-separated tags
* Parses tags into a list
* Prints tags with `TagPrinter`
* Saves tags to `taglist.txt`
* Loads tags from `taglist.txt`
* Exits when the user chooses option `5`

Approximate final structure:

```csharp
namespace Backend3withMain;

class Program
{
    static void Main(string[] args)
    {  
        List<string> tagsList = new List<string>();

        Console.Clear();
        bool running = true;

        while (running)
        {       
            Console.WriteLine("Tag manager");
            Console.WriteLine("1. Enter new tags");
            Console.WriteLine("2. Show current tags");
            Console.WriteLine("3. Save tags");
            Console.WriteLine("4. Load tags");
            Console.WriteLine("5. Exit");
            Console.WriteLine();
            Console.Write("Choose an option: ");

            int choice = 0;

            bool isInputValid = int.TryParse(Console.ReadLine(), out choice);

            if (choice == 1)
            {
                Console.WriteLine("Enter tags separated by comma:");
                string userInputTags = Console.ReadLine();
                tagsList = ParseTags(userInputTags);
            }
            else if (choice == 2)
            {
                TagPrinter.Print(tagsList);
            }
            else if (choice == 3)
            {
                string filePath = "taglist.txt";
                File.WriteAllLines(filePath, tagsList);
            }
            else if (choice == 4)
            {
                string filePath = "taglist.txt";

                if (File.Exists(filePath))
                {
                    string[] savedTags = File.ReadAllLines(filePath);
                    tagsList = new List<string>(savedTags);

                    Console.WriteLine("Tags loaded from disk.");
                }
                else
                {
                    Console.WriteLine("Tags failed to load!");
                }
            }
            else if (choice == 5)
            {
                running = false;
            }
            else
            {
                Console.WriteLine("invalid choice");
            }
        }
    }

    static List<string> ParseTags(string input)
    {
        string[] tagsArray = input.Split(",");
        List<string> tagsList = new List<string>();

        foreach (string item in tagsArray)
        {
            string cleanedItem = item.Trim();
            tagsList.Add(cleanedItem); 
        }

        return tagsList;
    }
}
```

## TagPrinter.cs

The `TagPrinter` class contains two overloads:

```csharp
class TagPrinter
{
    public static void Print(string tag)
    {
        Console.WriteLine("Tag: ");
        Console.WriteLine("#" + tag);
    }

    public static void Print(List<string> tags)
    {
        Console.WriteLine("Tags: ");

        foreach (string tag in tags)
        {
            Console.WriteLine("#" + tag);
        }
    }
}
```

One overload prints a single tag:

```csharp
TagPrinter.Print("coffee");
```

The other overload prints a list:

```csharp
TagPrinter.Print(tagsList);
```

---

# Week 3 Review Questions

Students should be able to answer:

## Main method and project structure

1. What is `Main`?
2. Why does code go inside `Main`?
3. What does `string[] args` mean?
4. What is a command-line argument?
5. What can go wrong with `args[0]`?

## Overloads

6. What is a method overload?
7. How is `Console.WriteLine("Hi")` different from `Console.WriteLine(1234)`?
8. Why can two methods have the same name?
9. How can overloads differ by type?
10. How can overloads differ by number of parameters?
11. What is the difference between `"A"` and `'A'`?

## Classes and static methods

12. What is a class?
13. What does `static` mean at beginner level?
14. What does `Greeter.Greet()` mean?
15. Why might we move code into a separate class file?
16. What does `TagPrinter.Print(tagsList)` mean?

## Tags, strings, arrays, and lists

17. What does `.Split(",")` do?
18. Why does `.Split(",")` return an array?
19. How do we copy array items into a list?
20. What does `.Trim()` do?
21. What does `ParseTags` receive?
22. What does `ParseTags` return?

## Menu apps

23. Why does the menu need a loop?
24. What does `bool running = true` do?
25. How does `running = false` stop the program?
26. Why should `tagsList` be created before the loop?

## TryParse and out

27. Why is `int.TryParse` safer than `int.Parse`?
28. What does `TryParse` return?
29. What does `out choice` do?
30. What is the difference between invalid text input and an invalid menu number?

## Files

31. Why do we save data to a file?
32. What does `File.WriteAllLines` do?
33. Does `WriteAllLines` append or replace?
34. What does `File.ReadAllLines` do?
35. Why does `ReadAllLines` return a string array?
36. Why do we use `File.Exists` before reading?

---

# Practice Project: Improve the Tag Manager

Improve the current tag manager without changing the main idea.

The app should still:

1. Show a menu.
2. Let the user enter comma-separated tags.
3. Convert the input into a list.
4. Print tags.
5. Save tags.
6. Load tags.
7. Exit.

## Required improvements

### 1. Use `?? ""` with `Console.ReadLine`

Current style:

```csharp
string userInputTags = Console.ReadLine();
```

Improved style:

```csharp
string userInputTags = Console.ReadLine() ?? "";
```

Why?

`Console.ReadLine()` can technically return `null`.

Using `?? ""` means:

> If no text is returned, use an empty string instead.

### 2. Use `isInputValid`

Current style:

```csharp
bool isInputValid = int.TryParse(Console.ReadLine(), out choice);

if (choice == 1)
{
}
```

Improved style:

```csharp
bool isInputValid = int.TryParse(Console.ReadLine(), out choice);

if (!isInputValid)
{
    Console.WriteLine("Please enter a number.");
}
else if (choice == 1)
{
}
```

Why?

This gives better feedback.

`abc` should mean:

```text
Please enter a number.
```

`99` should mean:

```text
Invalid choice.
```

### 3. Skip empty tags

Current style:

```csharp
string cleanedItem = item.Trim();
tagsList.Add(cleanedItem);
```

Improved style:

```csharp
string cleanedItem = item.Trim();

if (cleanedItem != "")
{
    tagsList.Add(cleanedItem);
}
```

Why?

If the user writes:

```text
coffee,,tea
```

we do not want to add an empty tag.

### 4. Add a message after saving

Current style:

```csharp
File.WriteAllLines(filePath, tagsList);
```

Improved style:

```csharp
File.WriteAllLines(filePath, tagsList);
Console.WriteLine("Tags saved.");
```

Why?

The user should know that the save action worked.

### 5. Add a goodbye message

When the loop ends, print:

```csharp
Console.WriteLine("Goodbye!");
```

---

# Suggested Improved Final Code

```csharp
namespace Backend3withMain;

class Program
{
    static void Main(string[] args)
    {
        List<string> tagsList = new List<string>();
        string filePath = "taglist.txt";

        Console.Clear();

        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Tag manager");
            Console.WriteLine("1. Enter new tags");
            Console.WriteLine("2. Show current tags");
            Console.WriteLine("3. Save tags");
            Console.WriteLine("4. Load tags");
            Console.WriteLine("5. Exit");
            Console.WriteLine();
            Console.Write("Choose an option: ");

            string input = Console.ReadLine() ?? "";

            bool isInputValid = int.TryParse(input, out int choice);

            if (!isInputValid)
            {
                Console.WriteLine("Please enter a number.");
            }
            else if (choice == 1)
            {
                Console.WriteLine("Enter tags separated by comma:");
                string userInputTags = Console.ReadLine() ?? "";

                tagsList = ParseTags(userInputTags);

                Console.WriteLine("Tags updated.");
            }
            else if (choice == 2)
            {
                TagPrinter.Print(tagsList);
            }
            else if (choice == 3)
            {
                File.WriteAllLines(filePath, tagsList);
                Console.WriteLine("Tags saved.");
            }
            else if (choice == 4)
            {
                if (File.Exists(filePath))
                {
                    string[] savedTags = File.ReadAllLines(filePath);
                    tagsList = new List<string>(savedTags);

                    Console.WriteLine("Tags loaded from disk.");
                }
                else
                {
                    Console.WriteLine("No saved tags found.");
                }
            }
            else if (choice == 5)
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        Console.WriteLine("Goodbye!");
    }

    static List<string> ParseTags(string input)
    {
        string[] tagsArray = input.Split(",");

        List<string> tagsList = new List<string>();

        foreach (string item in tagsArray)
        {
            string cleanedItem = item.Trim();

            if (cleanedItem != "")
            {
                tagsList.Add(cleanedItem);
            }
        }

        return tagsList;
    }
}
```

---

# Student README Requirement

Students should add a short `README.md` or `readme.txt` for their own version of the project.

It should contain:

## 1. Program description

Example:

```text
This program is a simple tag manager.
The user can enter tags, show current tags, save tags to a file, and load tags again.
```

## 2. Concepts used

Example:

```text
This project uses:

- Main method
- Static methods
- Static helper class
- Method overloads
- Console input
- while loop menu
- List<string>
- string.Split
- string.Trim
- int.TryParse
- out parameter
- File.WriteAllLines
- File.ReadAllLines
- File.Exists
```

## 3. Pseudocode

Example:

```text
START

Create empty list of tags
Set running to true

WHILE running is true
    Show menu
    Read menu choice
    Try to convert menu choice to number

    IF menu choice is not a number
        Print error message

    ELSE IF choice is 1
        Ask user for comma-separated tags
        Split input by comma
        Trim each tag
        Add non-empty tags to list

    ELSE IF choice is 2
        Print current tags

    ELSE IF choice is 3
        Save tags to file

    ELSE IF choice is 4
        IF file exists
            Read tags from file
            Store loaded tags in list
        ELSE
            Print error message

    ELSE IF choice is 5
        Stop running

    ELSE
        Print invalid choice

Print goodbye message

END
```

## 4. Test values

Students should test:

```text
coffee,tea,milk
coffee, tea, milk
coffee,,tea
  csharp  ,  dotnet
abc as menu choice
99 as menu choice
save then restart program
load after restart
```

## 5. Reflection questions

Students should answer:

1. What does `.Split(",")` do?
2. What does `.Trim()` do?
3. Why do we use a list for tags?
4. Why does the menu need a loop?
5. What does `TryParse` do?
6. What does `out` do?
7. What file does your program save to?
8. What was the hardest part of the project?

---

# Optional Extension Tasks

These were not required in the repository, but they are good next steps.

## Extension 1: Skip duplicate tags

Do not add the same tag twice.

Hint:

```csharp
if (!tagsList.Contains(cleanedItem))
{
    tagsList.Add(cleanedItem);
}
```

## Extension 2: Append new tags instead of replacing the list

Currently, entering new tags replaces the current list:

```csharp
tagsList = ParseTags(userInputTags);
```

Try changing the program so new tags are added to the existing list.

## Extension 3: Add a delete tag option

Add a menu option:

```text
6. Delete tag
```

Ask the user which tag to remove.

Use:

```csharp
tagsList.Remove(tagToRemove);
```

## Extension 4: Add a search option

Add a menu option:

```text
6. Search tag
```

Ask the user for search text and print matching tags.

## Extension 5: Add a clear list option

Add:

```text
6. Clear current tags
```

Use:

```csharp
tagsList.Clear();
```

## Extension 6: Save to a `data` folder

Instead of saving directly to:

```text
taglist.txt
```

save to:

```text
data/taglist.txt
```

This requires learning about:

```csharp
Directory.CreateDirectory(...)
Path.Combine(...)
```

---

# Common Mistakes to Watch For

## Writing code outside `Main`

Problem:

```csharp
class Program
{
    static void Main(string[] args)
    {
    }
}

Console.WriteLine("Hello");
```

Normal program instructions should be inside a method.

Better:

```csharp
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello");
    }
}
```

---

## Confusing strings and chars

String:

```csharp
"A"
```

Char:

```csharp
'A'
```

A string can contain many characters.

A char contains one character.

---

## Forgetting that overloads need different parameter lists

This is not allowed:

```csharp
static void Greet(string message)
{
}

static void Greet(string text)
{
}
```

The parameter names are different, but the parameter types are the same.

C# sees both as:

```csharp
Greet(string)
```

Better:

```csharp
static void Greet(string message)
{
}

static void Greet(string message, int age)
{
}
```

---

## Recreating the list inside the loop

Problem:

```csharp
while (running)
{
    List<string> tagsList = new List<string>();
}
```

This creates a new empty list every loop cycle.

Better:

```csharp
List<string> tagsList = new List<string>();

while (running)
{
}
```

The list should be created before the loop so it can remember values between choices.

---

## Not checking whether `TryParse` worked

Problem:

```csharp
bool isInputValid = int.TryParse(input, out int choice);

if (choice == 1)
{
}
```

Better:

```csharp
bool isInputValid = int.TryParse(input, out int choice);

if (!isInputValid)
{
    Console.WriteLine("Please enter a number.");
}
else if (choice == 1)
{
}
```

---

## Adding empty tags

Problem:

```csharp
string cleanedItem = item.Trim();
tagsList.Add(cleanedItem);
```

If the user writes:

```text
coffee,,tea
```

an empty tag may be added.

Better:

```csharp
string cleanedItem = item.Trim();

if (cleanedItem != "")
{
    tagsList.Add(cleanedItem);
}
```

---

## Forgetting that `WriteAllLines` replaces the file

This replaces the file:

```csharp
File.WriteAllLines(filePath, tagsList);
```

It does not add to the end.

That is useful for saving the current state, but students should know that old file content is overwritten.

---

## Reading a file that does not exist

Problem:

```csharp
string[] savedTags = File.ReadAllLines(filePath);
```

If the file does not exist, the program can crash.

Better:

```csharp
if (File.Exists(filePath))
{
    string[] savedTags = File.ReadAllLines(filePath);
}
else
{
    Console.WriteLine("No saved tags found.");
}
```

---

# Week 3 Summary

This week was an important step from isolated examples toward a small structured application.

The project started with the explicit `Main` method and small examples of command-line arguments and overloads.

Then it moved into custom methods, static classes, and separate class files.

Finally, it became a small tag manager app with:

* user input
* a repeating menu
* a list of tags
* a helper parsing method
* a separate `TagPrinter` class
* method overloads
* safer number parsing with `TryParse`
* basic save/load support using text files

The final app is still small, but it contains many ideas used in real programs:

* Program flow
* Data processing
* Helper methods
* Class organization
* User interaction
* Validation
* Persistence

That is a major step from simple console examples toward building real applications.
