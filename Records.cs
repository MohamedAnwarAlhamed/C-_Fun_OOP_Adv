var p1 = new Point(2, 3);
var p2 = new Point(2, 3);

Console.WriteLine(p1);
Console.WriteLine(p2);

Console.WriteLine($"p1.Equals(p2): {p1.Equals(p2)}");
Console.WriteLine($"(p1 == p2): {p1 == p2}");

Console.ReadKey();



record Point
{
    // override object equal
    // implement IEquatable <Point>
    // override object GetHashCode
    // override ==, !=
    // override ToString();

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X;
    public int Y;
}
//===========================================================================
//===========================================================================
//===========================================================================using System;

var p1 = new Point(2, 3);
var p2 = new Point(2, 3);
var p3 = new Point
{
    X = 2,
    Y = 3
};
var p3 = new Point { X = 10, Y = 11 };
p1.X = 10; // comile time
Console.WriteLine(p1);
Console.WriteLine(p2);

Console.WriteLine($"p1.Equals(p2): {p1.Equals(p2)}");
Console.WriteLine($"(p1 == p2): {p1 == p2}");

Console.ReadKey();

record Point
{
    // override object equal
    // implement IEquatable <Point>
    // override object GetHashCode
    // override ==, !=
    // override ToString();
    public Point()
    {

    }
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; init; }
    public int Y { get; init; }

}

//===========================================================================
//===========================================================================
//===========================================================================

var p1 = new Point(2, 3);
// p1.X = 10; // position record are immutable by default
Console.WriteLine(p1);
var (x, y) = p1;

Console.WriteLine($"x = {x}, y = {y}");

var p2 = new Point { X = 10, Y = 11 };
Console.WriteLine(p2);
Console.ReadKey();

// record Point (int X, int Y);

record Point(int X, int Y)
{
    public Point() : this(0, 0)
    {

    }
}
//===========================================================================
//===========================================================================
//===========================================================================
var p1 = new Point(2, 3);
// p1.X = 10; // position readonly struct record are immutable
Console.WriteLine(p1);

Console.ReadKey();

public readonly record struct Point(int X, int Y);

public record struct PointV2
{
    public int X;
    public int Y;

}
//===========================================================================
//===========================================================================
//===========================================================================
var p1 = new Point(2, 3);

var p2 = new Point(4, p1.Y);

var p3 = p1 with { X = 4 };

Console.WriteLine(p1);
Console.WriteLine(p2);
Console.WriteLine(p3);
Console.ReadKey();


record Point(int X, int Y);

