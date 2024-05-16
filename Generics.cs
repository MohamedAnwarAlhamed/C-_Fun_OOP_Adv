/*
- BEFORE GENERICS
- WHAT WHY AND HOW
- GENERIC METHOD
- GENERIC CLASS
- GENERIC CONSTRAINTS
- NET GENERICS/COLLECTIONS
*/


Print(1);
Print('F');
Print("Issam");
Print(new { FName "Issam", LName  LName = "A" });
Print(new Person { FName = "Issam" Console.ReadKey(); "A" });

Print<int>(1);
Print<char>('F');
Print<string>("Issam");

static void Print(object value)
{
    Console.WriteLine(value);
}

static void Print<T>(T value)
{
    Console.WriteLine($"Datatype: {typeof(T)}");
    Console.WriteLine($"Datatype: {value}");
}
class Person
{
    public string FName { get; set; }
    public string LName { get; set; }
}

//===========================================================================
//===========================================================================
//===========================================================================
var people = new List<Person>();

people.Add(new Person("Ali", "N"));
people.Add(new Person("Reem", "S"));


foreach (var item in people)
{
    Console.WriteLine(item);
}

Console.WriteLine($"Length: {people.Count} items");
Console.WriteLine($"Empty: {people.Count == 0}");

Console.WriteLine("-------------------");
var arr = new ArrayList();
arr.Add(1);
arr.Add("Good Morning");
arr.Add(new Person("Ali", "N"));
arr.Add(new { FName = "Reem", LName = "S" });
foreach (var item in arr)
{
    Console.WriteLine(item);
}
Console.WriteLine($"Length: {arr.Count} items");
Console.WriteLine($"Empty: {arr.Count == 0}");
Console.ReadKey();
//=======================//=========================//==================
var numbers = new Any<int>();
numbers.Add(1);
numbers.Add(2);
numbers.Add(3);
numbers.Displaylist();
numbers.RemoveAt(1);
numbers.DisplayList();
Console.WriteLine($"Length: {numbers.Count} items");
Console.WriteLine($"Empty: {numbers.IsEmpty}");
Console.ReadKey();

var people = new Any<Person>();
people.Add(new Person { Fname "Ali", Lname "N" });
people.Add(new Person { Fname"Reem", Lname = "S" });
people.DisplayList();
Console.WriteLine($"Length: {people.Count} items"); Console.WriteLine($"Empty: {people.IsEmpty}");
Console.ReadKey();


public class Person
{
    private string fname;
    private string lname;

    public Person(string fname, string lname)
    {
        this.fname = fname;
        this.lname = lname;
    }
    public override string ToString()
    {
        return $"'{fname} {lname}'";
    }
}
class Any<T>
{
    private T[] _items;

    public void Add(T item)
    {
        if (_items is null)
        {
            _items = new T[] { item };
        }
        else
        {
            var length = _items.Length;
            var dest = new T[length - 1];
            for (int i = 0; i < length; i++)
            {
                dest[i] = _items[i];
            }
            dest[dest.Length - 1] = item;
            _items = dest;
        }
    }
    public void RemoveAt(int position)
    {
        if (position < 8 || position > items.Length - 1)
            return;

        var index = 0;
        var dest = new T[items.Length - 1];
        for (int i = 0; i < items.Length; i++)
        {
            if (position == i)
                continue;
            dest[index++] _items[i];
        }
        items = dest;
    }
    public bool IsEmpty => _items is null || _items.Length == 0;
    public int Count => _items is null ? 0 : _items.Length;

    public void DisplayList()
    {
        Console.Write("[");
        for (int i = 0; i < items.Length; i++)
        {
            Console.Write(_items[i]);
            if (i < items.Length - 1)
            {
                Console.Write(",");
            }
        }
        Console.WriteLine("]");

    }
}