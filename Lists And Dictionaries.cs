/*
- DEFINITIONS
- LIST<T>
- ADD, INSERT AND REMOVE
- COUNT AND CAPACITY
- DICTIONARY<TKEY, TVALUE>
- TODICTIONARYO
*/
var egypt = new Country { ISOCode = "EGY", Name = "Egypt" };
var jordan = new Country { ISOCode = "JOR", Name = "Jordan" };
var iraq = new Country { ISOCode = "IRQ", Name = "Iraq" };

Country[] countriesArray =
{
                egypt,
                jordan,
                iraq
            };

// Constructors
//List<Country> countries = new List<Country>();
// List<Country> countries = new List<Country>(3);
List<Country> countries = new List<Country>(countriesArray);

// Methods
countries.Add(new Country { ISOCode = "BRA", Name = "Brasil" }); // O(1)
                                                                 //countries.AddRange(countriesArray);


countries.Insert(1, new Country { ISOCode = "FRA", Name = "France" }); // O(n)

Print(countries);
countries.RemoveAt(4);

countries.RemoveAll(x => x.Name.EndsWith("ce"));

countries.Remove(new Country { ISOCode = "IRQ", Name = "Iraq" });

Print(countries);
Console.ReadKey();


static void Print(List<Country> countries)
{
    foreach (var c in countries)
    {
        Console.WriteLine(c);
    }

    // Properties 
    Console.WriteLine($"Count: {countries.Count}"); // actual count
    Console.WriteLine($"Capacity: {countries.Capacity}"); // initial capacity for inner data structure
}


class Country
{
    public string ISOCode { get; set; }
    public string Name { get; set; }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 19;
            hash = hash * 397 + ISOCode.GetHashCode();
            hash = hash * 397 + Name.GetHashCode();
            return hash;
        }
    }

    public override bool Equals(object obj)
    {
        var country = obj as Country;
        if (country is null) // better than country == null
            return false;
        return this.Name.Equals(country.Name, StringComparison.OrdinalIgnoreCase)
               && this.ISOCode.Equals(country.ISOCode, StringComparison.OrdinalIgnoreCase);
    }
    public override string ToString()
    {
        return $"{Name} ({ISOCode})"; // Egypt (EGY)
    }
}
//===========================================================================
//===========================================================================
//===========================================================================

//var article =
//    "Dot NET is a free cross-platform and open source developer platform" +
//    "for building many different types of applications" +
//    "With Dot NET you can use multiple languages and libraries" +
//    "to build for web and IoT";

//// key: 'd', value: "Dot" "Developer"
//Dictionary<char, List<string>> lettersDictionary = new Dictionary<char, List<string>>();
//foreach (var word in article.Split())
//{
//    foreach(var ch in word)
//    {
//        char c = Char.ToLower(ch);
//        if(!lettersDictionary.ContainsKey(c))
//        {
//            lettersDictionary.Add(c, new List<string> { word.ToLower() });
//        }
//        else
//        {
//            lettersDictionary[c].Add(word);
//        }
//    }
//}
//foreach (var entry in lettersDictionary)
//{
//    Console.Write($"'{entry.Key}': ");
//    foreach (var word in entry.Value)
//    {
//        Console.WriteLine($"\t\t \"{word}\"");
//    }
//}

var emps = new List<Employee>
            {
                new Employee {Id = 100, Name = "Reem S.", ReportTo = null},
                new Employee {Id = 101, Name = "Raed M.", ReportTo = 100 },
                new Employee {Id = 102, Name = "Ali B.", ReportTo = 100 },
                new Employee {Id = 103, Name = "Abeer S.", ReportTo = 102 },
                new Employee {Id = 104, Name = "Radwan N.", ReportTo = 102 },
                new Employee {Id = 105, Name = "Nancy R.", ReportTo = 101 },
                new Employee {Id = 106, Name = "Saleh A.", ReportTo = 104 }
            };

//var managers = emps.GroupBy(x => x.ReportTo);
var managers = emps.ToLookup(x => x.ReportTo).ToDictionary(x => x.Key ?? -1, x => x.ToList());

foreach (var entry in managers)
{
    if (entry.Key == -1)
        continue;
    var manager = emps.FirstOrDefault(x => x.Id == entry.Key);

    Console.WriteLine($"{manager}");

    foreach (var emp in entry.Value)
    {
        Console.WriteLine($"\t\t\"{emp}\"");
    }
}
Console.ReadKey();

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ReportTo { get; set; }

    public override string ToString()
    {
        return $"[{Id}] {Name}";
    }
}



