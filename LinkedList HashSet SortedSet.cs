/*
- WHAT, WHY LINKEDLIST
- LINKEDLISTNODE
- REAL EXAMPLE LINKEDLIST
- HASHSET,
- SORTEDLIST
- COMPARISON AND EQUALITY
*/
var lesson1 = new YTVideo { Id = "YTV1", Title = "Variables", Duration = new TimeSpan(00, 30, 00) };
var lesson2 = new YTVideo { Id = "YTV2", Title = "Classes and Strcts", Duration = new TimeSpan(01, 20, 00) };
var lesson3 = new YTVideo { Id = "YTV3", Title = "Expressions", Duration = new TimeSpan(00, 45, 00) };
var lesson4 = new YTVideo { Id = "YTV4", Title = "Iterations", Duration = new TimeSpan(01, 10, 00) };
var lesson5 = new YTVideo { Id = "YTV5", Title = "Generics", Duration = new TimeSpan(00, 20, 00) };

//LinkedList<YTVideo> playlist = new LinkedList<YTVideo>(new YTVideo[] {
//    lesson1,
//    lesson2,
//    lesson3,
//    lesson4,
//    lesson5
//});

LinkedList<YTVideo> playlist = new LinkedList<YTVideo>();
playlist.AddFirst(lesson1);

playlist.AddAfter(playlist.First, lesson2);
var node3 = new LinkedListNode<YTVideo>(lesson3);
playlist.AddAfter(playlist.First.Next, node3);
playlist.AddBefore(playlist.Last, lesson4);

playlist.AddLast(lesson5);
Print("C# from zero to hero", playlist);
Console.ReadKey();


static void Print(string title, LinkedList<YTVideo> playlist)
{
    Console.WriteLine($"┌{title}");
    foreach (var item in playlist)
        Console.WriteLine(item);
    Console.WriteLine($"└");
    Console.WriteLine($"Total: {playlist.Count} item(s)");

}


class YTVideo
{
    public string Id { get; set; }
    public string Title { get; set; }
    public TimeSpan Duration { get; set; } // HH:MM:SS

    public override string ToString()
    {
        // C# Variables (00:30:00)
        //      https://www.youtube.com/watch?v=d6EpL33g9tg
        return $"├── {Title} ({Duration})\n│\thttps://www.youtube.com/watch?v={Id}";
    }
}
//===========================================================================
//===========================================================================
//===========================================================================

var customers = new List<Customer>
            {
             new Customer { Name = "Issam A", Telephone = "+1 123 123 4565" },
             new Customer { Name = "Reem S", Telephone = "+1 123 123 4566" },
             new Customer { Name = "Issam B", Telephone = "+1 123 123 4567" },
             new Customer { Name = "Abeer A", Telephone = "+1 123 123 4568" },
             new Customer { Name = "Salem D", Telephone = "+1 123 123 4569" }

            };

Console.WriteLine("Hashset");
Console.WriteLine("-------");



var custhashSet1 = new HashSet<Customer>(customers);

var customers2 = new List<Customer>
            {
             new Customer { Name = "Essam A", Telephone = "+1 123 123 4533" },
             new Customer { Name = "Rim S", Telephone = "+1 123 123 4554" }

            };

var custhashSet2 = new HashSet<Customer>(customers2);

custhashSet1.UnionWith(custhashSet2);

foreach (var item in custhashSet1) Console.WriteLine(item);

Console.WriteLine("SortedSet");
Console.WriteLine("-------");

var customerSortedSet = new SortedSet<Customer>(customers);
customerSortedSet.Add(new Customer { Name = "Baker S", Telephone = "+1 123 123 3354" });
foreach (var item in customerSortedSet) Console.WriteLine(item);

Console.ReadKey();


class Customer : IComparable<Customer>
{
    public string Name { get; set; }
    public string Telephone { get; set; }

    public override int GetHashCode()
    {
        var hash = 17;
        hash = hash * 397 + Telephone.GetHashCode();
        return hash;
    }

    public override bool Equals(object obj)
    {
        var customer = obj as Customer;

        if (customer is null)
            return false;

        return this.Telephone.Equals(customer.Telephone);
    }

    public override string ToString()
    {
        return $"{Name} ({Telephone})";
    }

    public int CompareTo(Customer other)
    {
        if (object.ReferenceEquals(this, other))
            return 0;

        if (other is null)
            return -1;

        return this.Name.CompareTo(other.Name);
    }
}



