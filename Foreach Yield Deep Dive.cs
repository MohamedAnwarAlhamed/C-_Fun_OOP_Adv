var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

Console.WriteLine("\n\n Using For");
for (int i = 0; i < numbers.Length; i++)
{
    Console.Write($" {numbers[i]}");
}


Console.WriteLine("\n\n Using Foreach");
foreach (var n in numbers)
{
    Console.Write($" {n}");
}


Console.WriteLine("\n\n Using Foreach under the hood");
Foreach(numbers);


Console.ReadKey();


static void Foreach<T>(IEnumerable<T> source)
{
    IEnumerator<T> enumerator = source.GetEnumerator();
    IDisposable disposable;
    try
    {
        T item;
        while (enumerator.MoveNext())
        {
            // code
            item = enumerator.Current;
            Console.Write($" {item}");
        }
    }
    finally
    {
        disposable = (IDisposable)enumerator;
        disposable.Dispose();
    }


}

//===========================================================================
//===========================================================================
//===========================================================================

//Console.WriteLine("using GenerateV1()");
//foreach (var n in GenerateV1())
//{
//    Console.Write($" {n}");
//}

//Console.WriteLine("\n\nusing GenerateV2()");
//foreach (var n in GenerateV2())
//{
//    Console.Write($" {n}");
//}

Console.WriteLine("\n\nusing GenerateV3()");
foreach (var n in GenerateV3())
{
    Console.Write($" {n}");
}
Console.ReadKey();

static IEnumerable<int> GenerateV1()
{
    var result = new List<int>();
    for (int i = 1; i <= 5; i++)
    {
        result.Add(i);
    }
    return result;
}

static IEnumerable<int> GenerateV2()
{
    for (int i = 1; i <= 5; i++)
    {
        yield return i;
    }
}

static IEnumerable<int> GenerateV3()
{
    yield return 1;
    yield return 2;
    yield return 3;
    yield return 4;
    yield return 5;
    yield break;
    yield return 6;
    yield return 7;
    yield return 8;
}



