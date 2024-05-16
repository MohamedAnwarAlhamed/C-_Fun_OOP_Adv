string input = "123A";
// "compile time" building source code and convert it to IL
// int num1 = input; // CS0029 can't convert string to int

//  "runtime" when you excuted the compiled code
int num2 = int.Parse(input);
Console.ReadKey();
//===========================================================================
//===========================================================================
//===========================================================================
// string is reference type
string str1 = default; // default is null string str1 = null;
string str2 = "Issam";
// dereferencing follow tge reference pointed to access the
// underlying object
Console.WriteLine(str2.Length); // 5
Console.WriteLine(str1.Length); // Null reference exception

// value type
DateTime datetime = default; // default is '0001/01/01 00:00 AM'
Console.WriteLine(datetime.Month);
Console.ReadKey();
//===========================================================================
//===========================================================================
//===========================================================================

int mark1 = 15;
int mark2 = default; // 0

Nullable<int> mark3 = default; // null

if (mark3 is null)
{
    Console.WriteLine("not available!!");
}
else
{
    Console.WriteLine($"mark3 = {mark3}");
}


int? mark4 = default; // null

if (!mark4.HasValue)
{
    Console.WriteLine("not available!!");
}
else
{
    Console.WriteLine($"mark4 = {mark4}");
}

Nullable<int> mark5 = default; // null
Console.WriteLine($"mark5 = {(mark5.HasValue ? mark5 : "null")}");

Nullable<int> mark6 = new Nullable<int>(); // null
Console.WriteLine($"mark6 = {(mark6.HasValue ? mark6 : "null")}");

int? mark7 = default(int?); // null
Console.WriteLine($"mark7 = {(mark7.HasValue ? mark7 : "null")}");

Nullable<int> mark8 = new(); // 0
Console.WriteLine($"mark8 = {(mark8.HasValue ? mark8 : "null")}");

Console.ReadKey();
//===========================================================================
//===========================================================================
//===========================================================================

string name = null;
string decision = IsLongName(name) ? "long" : "short";
Console.WriteLine($"{name} is {decision}");
Console.ReadKey();


static bool IsLongName(string? name)
{
    if (name is null)
        return false;

    return name.Length > 10; // assumption name could be null 

}
//===========================================================================
//===========================================================================
//===========================================================================

Console.ReadKey();


private static string? GetName()
{
    return null;
}


static bool Scenario1()
{
    string name = String.Empty; // Assignment of non null value
    return name.Length > 10;
}
static bool Scenario2()
{
    string? name = GetName();
    if (name == null) // checked against null
        return false;
    return name.Length > 10; // name shouldn't be null
}



static bool MaybeNullScenario()
{
    string? name = GetName();
    return name.Length > 10; // maybe null
}
//===========================================================================
//===========================================================================
//===========================================================================
// var person = new Person(null, null);
Console.ReadKey();

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}

public class Student : Person
{
    public string Major { get; set; }

    public Student(string firstName, string lastName, string major)
        : base(firstName, lastName)
    {
        SetMajor(major);
    }

    public Student(string firstName, string lastName) :
        base(firstName, lastName)
    {
        SetMajor();
    }

    [MemberNotNull(nameof(Major))]
    public void SetMajor(string? major = default)
    {
        Major = major ?? "Undeclared";
    }
}
//===========================================================================
//===========================================================================
//===========================================================================

string fname = null!;
string lname = null!;

var person = new Person(fname, lname);

Console.WriteLine(person.FirstName!.Length);

Student st1 = new Student();

Student? st2 = new Student();

var st3 = new Student();

Console.ReadKey();

class Student { }
public class Person
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }


    public Person(string firstName, string lastName)
    {
        if (firstName is null)
        {
            FirstName = "Annonymous";
        }
        else
        {
            FirstName = firstName;
        }
        if (lastName is null)
        {
            LastName = "Annonymous";
        }
        else
        {
            LastName = lastName;
        }
    }
}
//===========================================================================
//===========================================================================
//===========================================================================
static void Main(string[] args)
{
    Console.WriteLine("Hello World!");
}

static T? DoSomething<T>(T source)
{
    return source;
}
//===========================================================================
//===========================================================================
//===========================================================================
//Print(default);

string[] names = new string[10];
var firstValue = names[0];
Console.WriteLine(firstValue.ToUpper());
Console.ReadLine();
        }

        static void Print(Student student)
{
    Console.WriteLine($"First Name: {student.FirstName.ToUpper()}");
    Console.WriteLine($"Middle Name: {student.FirstName?.ToUpper()}");
    Console.WriteLine($"Last Name: {student.LastName.ToUpper()}");
}



// struct contains reference types
public struct Student
{
    public string FirstName;
    public string? MiddleName;
    public string LastName;
}
//===========================================================================
//===========================================================================
//===========================================================================














