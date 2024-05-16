/*
- WHAT, WHY AND HOW
- ACTION DELEGATE
- FUNC DELEGATE
- PREDICATE DELEGATE
- REAL WORLD EXAMPLE
*/
public delegate bool Filter<in T>(T n);

IEnumerable<int> list1 = new int[] { 2, 5, 6, 7, 9, 1, 3, 4, 8 };
Console.WriteLine("Numbers Less than 6");
PrintNumber(list1, n => n < 6);
PrintNumber(list1, n => n < 7);
Console.WriteLine("Numbers Less than 7"); Console.WriteLine("Even Numbers"); PrintNumber(list1, n => n % 2 == 0);
IEnumerable<decimal> list2 = new decimal[] { 2.5m, 5.3m, 6.33m, 7.1m, 6.44m, 1.75m, 3.4m, 4.2m, 8.7m }
Console.WriteLine("Number Greater than equal 6.33");
PrintNumber(list2, n => n >= 6.33m);


static void PrintNumber<T>(IEnumerable<T> numbers, Filter<T> filter)
{
    foreach (var n in numbers)
    {
        if (filter(n))
        {
            Console.WriteLine(n);
        }
    }
}

//===========================================================================
//===========================================================================
//===========================================================================

Action<string> action = Print;
action("Issam");
Func<int, int, int> addD = Add;
Console.WriteLine(addD(2, 2));
Predicate<int> predicate = IsEven;
Console.WriteLine(predicate(3));
Console.ReadKey();

static void Print(string name) => Console.WriteLine(name);
static int Add(int n1, int n2) => n1 + n2;
static bool IsEven(int n) => n % 2 == 0;


//===========================================================================
//===========================================================================
//===========================================================================

public delegate bool Filter<in T>(T n);

IEnumerable<int> list1 = new int[] { 2, 5, 6, 7, 9, 1, 3, 4, 8 };
PrintNumber(list1, n => n < 6, () => Console.WriteLine("Numbers Less than 6"));
PrintNumber(list1, n => n < 7, () => Console.WriteLine("Numbers Less than 7"));
PrintNumber(list1, n => n % 2 == 0, () => Console.WriteLine("Even Numbers"));

IEnumerable<decimal> list2 = new decimal[] { 2.5m, 5.3m, 6.33m, 7.1m, 6.44m, 1.75m, 3.4m, 4.2m, 8.7m };
PrintNumber(list2, n => n >= 6.33m, () => Console.WriteLine("Number Greater than equal 6.33"));


static void PrintNumber<T>(IEnumerable<T> numbers, Func<T, bool> filter, Action action)
{
    action();
    foreach (var n in numbers)
    {
        if (filter(n))
        {
            Console.WriteLine(n);
        }
    }
}