// array reference type (list with fixed size) 
int[] array = { 50, 10, 23, 1, 7, -4 };

// list represents a dynamically-sized list generally contageous
List<int> list = new List<int> { 50, 10, 23, 1, 7, -4 };

list.AddRange(list); // { 50, 10, 23, 1, 7, -4, 50, 10, 23, 1, 7, -4 };



// collection
ArrayList al = new ArrayList { "50", 10, 23.2m, DateTime.Now };


// In .NET Framework new Data Structure is introduced System.Tuple

Tuple<int, int, int, int, int, int> tuples1 =
    new Tuple<int, int, int, int, int, int>(50, 10, 23, 1, 7, -4);

Tuple<int, int, int, int, int, int> tuples2 = Tuple.Create(50, 10, 23, 1, 7, -4);

Tuple<string, decimal> distances = Tuple.Create("hospital", 2.5m);
//===========================================================================
//===========================================================================
//===========================================================================
Console.WriteLine("Using Class DS");
var facilityName = FacilityDistanceCalculator.GetFacilityLocationInfoV1("Hospital");
Console.WriteLine(facilityName);

Console.WriteLine();
Console.WriteLine("Using out Parameter");

string name = "";
double distanceInKm = 0;

FacilityDistanceCalculator
    .GetFacilityLocationInfoV2("Hospital", out name, out distanceInKm);

Console.WriteLine($"{name} ....... {distanceInKm.ToString("F2")} km");
Console.ReadKey();
        }

public class Location
{
    public string Name { get; set; }
    public double DistanceInKm { get; set; }

    public override string ToString()
    {
        return $"{Name} ....... {DistanceInKm.ToString("F2")} km";
    }
}

public static class FacilityDistanceCalculator
{
    private static Random random = new Random();
    public static Location GetFacilityLocationInfoV1(string facilityName)
    {
        return new Location
        {
            Name = facilityName,
            DistanceInKm = random.NextDouble() * 10.0
        };
    }

    public static void GetFacilityLocationInfoV2(
        string facilityName, out string name, out double distanceInKm)
    {
        name = facilityName;
        distanceInKm = random.NextDouble() * 10.0;
    }
}
//===========================================================================
//===========================================================================
//===========================================================================
Console.WriteLine("Get FacilityInfo using Tuple.Create");

var facilityInfo = FacilityDistanceCalculator.CalculateFacilityDistance("Hospital");

Console.WriteLine(facilityInfo);

Console.WriteLine("Get FacilityInfo using Tuple Constructor");

var facilityInfoV2 = FacilityDistanceCalculator.CalculateFacilityDistanceV2("Hospital");

Console.WriteLine(facilityInfoV2);

Console.WriteLine("Get FacilityInfo using Tuple.Create / Access Item");

var facilityInfoV3 = FacilityDistanceCalculator.CalculateFacilityDistanceV3("Hospital");
Console.WriteLine($"{facilityInfoV3.Item1} ....... {facilityInfoV3.Item2.ToString("F2")} km");

// Equality

var t1 = Tuple.Create("hospial1", 2.5);
var t2 = Tuple.Create("hospial1", 2.5);

Console.WriteLine(t1.Equals(t2));

Console.ReadKey();

public static class FacilityDistanceCalculator
{
    private static Random random = new Random();
    public static Tuple<string, string> CalculateFacilityDistance(string facilityName)
    {
        return Tuple.Create(facilityName, ($"{(random.NextDouble() * 10.0).ToString("F2")} km"));
    }

    public static Tuple<string, string> CalculateFacilityDistanceV2(string facilityName)
    {
        return new Tuple<string, string>(facilityName, ($"{(random.NextDouble() * 10.0).ToString("F2")} km"));
    }

    public static Tuple<string, double> CalculateFacilityDistanceV3(string facilityName)
    {
        return Tuple.Create(facilityName, random.NextDouble() * 10.0);
    }
}
//===========================================================================
//===========================================================================
//===========================================================================
Tuple<string, double> t1 = new Tuple<string, double>("Hospital", 2.4);
Console.WriteLine($"t1: {t1}");

ValueTuple<string, double> t2 = new ValueTuple<string, double>("Hospital", 2.4);
Console.WriteLine($"t2: {t2}");

var t3 = FacilityDistanceCalculator.CalculateFacilityDistance("Hospital");
Console.WriteLine($"t3: {t3}");

var t4 = FacilityDistanceCalculator.CalculateFacilityDistanceV2("Hospital");
Console.WriteLine($"t4: {t4}");
Console.WriteLine($"FacilityName: {t4.Item1}");


var t5 = FacilityDistanceCalculator.CalculateFacilityDistanceV3("Hospital");
Console.WriteLine($"t5: {t5.Name}");
Console.WriteLine($"t5: {t5.distanceInKm}");

(string nm, string ds) = t5;

Console.WriteLine($"name: {nm}");
Console.WriteLine($"distance: {ds} km");

public static class FacilityDistanceCalculator
{
    private static Random random = new Random();

    // ValueTuple.Create 
    public static ValueTuple<string, string> CalculateFacilityDistance(string facilityName)
    {
        return ValueTuple.Create(facilityName, $"{(random.NextDouble() * 10.0).ToString("F2")} km");
    }

    // Implicit Names
    public static (string, string) CalculateFacilityDistanceV2(string facilityName)
    {
        return ValueTuple.Create(facilityName, $"{(random.NextDouble() * 10.0).ToString("F2")} km");
    }

    // Explicit Names
    public static (string Name, string distanceInKm) CalculateFacilityDistanceV3(string facilityName)
    {
        return ValueTuple.Create(facilityName, $"{(random.NextDouble() * 10.0).ToString("F2")} km");
    }
}


