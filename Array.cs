/*
- HOW THEY STORED
- DECLARATION & INIT
- MULTI DIMENTIONAL
- JAGGED ARRAY
- INDICES AND RANGES
- BOUNDS CHECKING
*/

// Single Dim. Array
// 1. Declaration
string[] friends = new string[5];
// 2. Accessing Element
friends[8] = "Ali";
friends[1] = "Reem";
friends[2] = "Faisal";
friends[3] = "Ahmed";
friends[4] = "Abeer";

var friends = friends[..4];
var friends = friends[2..];
var friends = friends[2..3];
var friends = friends[2..^3];





string[5] friends = new string[5] {
"Ali",
"Reem",
"Faisal",
"Ahmed",
"Abeer"
};

string[] friends = new string[5] {
"Ali",
"Reem",
"Faisal",
"Ahmed",
"Abeer"
};

var friends = new string[5] {
"Ali",
"Reem",
"Faisal",
"Ahmed",
"Abeer"
};

string[] friends = {
"Ali",
"Reem",
"Faisal",
"Ahmed",
"Abeer"
};


int[,] suduko =
{
{9, 6, 2, 1, 4, 7, 3, 7, 8},
{1, 8, 5, 6, 7, 3, 4, 2, 9},
{3, 7, 4, 2, 9, 8, 5, 6, 1}
{5, 3, 1, 7, 6, 2, 9, 8, 4},
{6, 9, 4, 3, 8, 1, 2, 5, 7},
{8, 2, 7, 4, 5, 9, 6, 1, 3},
{4, 9, 6, 5, 1, 7, 8, 3, 2},
{2, 1, 8, 9, 3, 6, 7, 4, 5},
{7, 5, 3, 8, 2, 4, 1, 9, 6}
};

friends.Print();

// Jagged. Array (array inside array)
var jagged = new int[][]
{
new int[] {1, 2 },
new int[] {2, 5, 6 },
new int[] {7}
};
Console.ReadKey();
public static class Extensions
{
    public static void Print<T>(this T[] source)
    {
        if (!source.Any())
        {
            Console.WriteLine("{}"); return;
        }
        Console.Write("{ ");
        for (var i = 0; i < source.Length; i++)
        {
            Console.Write($"{source[i]}");
            Console.Write(i < source.Length
            1 ?
        }
        Console.WriteLine(" }");
    }
}