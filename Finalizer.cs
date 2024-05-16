/*
- DEFINITION
- WHY FINALIZERS
- GARBAGE COLLECTOR
- IMPICIT VS EXPLICIT
- GC.COLLECTO
*/

class Person
{

    public string Name { get; set; }

    public Person()
    {
        Console.WriteLine("This is Person Constructor");
    }
    ~Person()
    {
        Console.WriteLine("This is Person Desctructor");
    }
}

//===========================================================================
//===========================================================================
//===========================================================================
MakeSomeGarabge();
Console.WriteLine($"Memory used Before Collection: (GC.GetTotalMemory(false):NO}"); // 9,999,999 GC.Collect(); 
// Explicit Cleaning 
Console.WriteLine($"Memory used after collection: [GC.GetTotalMemory(true):N0}");
Console.ReadKey();

static void MakeSomeGarabge()
{
    Version v;

    for (int i = 0; i < 1000; i++)
    {
        v = new Version();
    }
}

