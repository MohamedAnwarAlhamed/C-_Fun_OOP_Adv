/*
- WHAT IS INDEXERS
- SCENARIOS WHEN TO USE
- INDEXER SYNTAX
- SINGLE DIMENTIONAL MAP
- MULTI-DIMENSIONAL MAPS
- SUDUKO EXAMPLE
*/
int[] arr = { 1, 2, 3 };
arr[0] = 10;
string str = "Hello";
var c = str[0];
int x = 10;
x[0] = 2;
Console.ReadKey();
//===========================================================================
//===========================================================================
//===========================================================================
//var ip = new IP(112, 114, 55, 33);
var ip = new IP("112.114.55.33");

var firstSegment = ip[0];

Console.WriteLine($"IP ADDRESS: {ip.Address}");
Console.WriteLine($"First Segment: {firstSegment}");

Console.ReadKey();
public class IP
{
    private int[] segments = new int[4];

    public int this[int index]
    {
        get
        {
            return segments[index];
        }
        set
        {
            segments[index] = value;
        }
    }

    // segment 1-255
    public IP(string IPAddress) // 123.123.123.123
    {
        var segs = IPAddress.Split(".");

        for (int i = 0; i < segs.Length; i++)
        {
            segments[i] = Convert.ToInt32(segs[i]);
        }
    }
    public IP(int segment1, int segment2, int segment3, int segment4)
    {
        segments[0] = segment1;
        segments[1] = segment2;
        segments[2] = segment3;
        segments[3] = segment4;
    }

    public string Address => string.Join(".", segments);
}
//===========================================================================
//===========================================================================
//===========================================================================
int[,] inputs = new int[,]{
{8, 3, 5, 4, 1, 6, 9, 2, 2},
{2, 9, 6, 8, 5, 7, 4, 3, 1},
{4, 1, 7, 2, 9, 3, 6, 5, 8},
{5, 6, 9, 1, 3, 4, 7, 8, 2},
{1, 2, 3, 6, 7, 8, 5, 4, 9},
{7, 4, 8, 5, 2, 9, 1, 6, 3},
{6, 5, 2, 7, 8, 1, 3, 9, 4},
{9, 8, 1, 3, 4, 5, 2, 7, 6},
{3, 7, 4, 9, 6, 2, 8, 1, 5}
};
var suduko new Suduko(inputs);
Console.WriteLine(suduko[5, 5]); // 9
suduko[5, 5] = 10;
Console.WriteLine(suduko[5, 5]); //
Console.ReadKey();

public class Suduko
{
    private int[,] matrix;
    public int this[int row, int col]
    {
        get
        {
            if (rowe < 0 || row > matrix.GetLength(0) - 1) return -1;
            if (col < 0 || col > matrix.GetLength(1) - 1) return -1;
            return _matrix[row, col];
        }
        set
        {
            if (value < 1 || value > matrix.GetLength(0))
                return;
            _matrix[row, col] = value;
        }
    }
    public Suduko(int[,] matrix)
    {
        matrix = matrix;
    }
}

