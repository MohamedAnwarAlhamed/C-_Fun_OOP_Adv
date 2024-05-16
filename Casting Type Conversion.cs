/*
- DATA TYPES ARE OBJECT
- IMPLICIT / EXPLICIT CASTING
- BOXING / UNBOXING
- CONVERT CLASS VS PARSE
- TRYPARSE
- BITCONVERTER AND VALUE TYPES
*/
// Int32 (int) Int64 (long)
int numberInt = 100; long numberLong = numberInt;
long nL = 1000;
if (nL <= Int32.MaxValue)
{
    int nI = (int)nL;
}
double d = 1234.8;
int i = (int)d;
Console.WriteLine(i);
Console.ReadKey();
//===========================================================================
//===========================================================================
//===========================================================================
// Boxing, UnBoxing
int x = 10; /
/ value type
Object obj; // reference type
obj = x; // conversion done implicitly (boxing)
int y = (int)obj; // unboxing
Console.ReadKey();
//===========================================================================
//===========================================================================
//===========================================================================
string stringValue = "120";
int number = int.Parse(stringValue);
Console.WriteLine(number);
// 1) type.Parse() => int.Parse(), double.Parse()....
Console.ReadKey();
//===========================================================================
//===========================================================================
//===========================================================================
string stringValue = "9999999999999999";
if (int.TryParse(stringValue, out int number))
{
    Console.WriteLine(number);
}
else
{
    Console.WriteLine("Invalid number provided or doesnt fit integer");
}
//===========================================================================
//===========================================================================
//===========================================================================
string stringValue = "66s";
var i = Convert.ToInt32(stringValue);
//decimal ToDecimal(String)
//float ToSingle(String)
//double ToDouble(String)
//short ToInt16(String)
//int ToInt32(String)
//long ToInt64(String) 
//ushort ToUInt16(String)
//uint ToUInt32(String)
//ulong ToUInt64(String)
Console.WriteLine(i);
//===========================================================================
//===========================================================================
//===========================================================================
// BitConvertor
var number = 10;
var bytes BitConverter.GetBytes(number);
foreach (var b in bytes)
{
    var binary Convert.ToString(b, 2).PadLeft(8, '0'); Console.WriteLine(binary);
}
Console.ReadKey();
//===========================================================================
//===========================================================================
//===========================================================================
var name = "Issam";
char[] letters = name.ToCharArray();
foreach (var l in letters)
{
    int ascii = Convert.ToInt32(l);
    var output = $"'{1}' ASCII: {ascii}, Binary: {Convert.ToString{ascii, 2}.PadLeft(8, '0')}, Hexadecimal: {ascii:x}'";
    Console.WriteLine(out);
}
Console.ReadKey();
//===========================================================================
//===========================================================================
//===========================================================================
string[] hexValues = { "49", "73", "73", "61", "60" };
foreach (var hex in hexValues)
{
    int value = Convert.ToInt32(hex, 16);
    var stringValue Char.ConvertFromUtf32(value); //#1
    var ch = (char)value; //#2
    Console.WriteLine(stringValue);
    Console.WriteLine(ch);
}

var hex = "8E2";
int number = Int32.Parse(hex, System.Globalization.NumberStyles.HexNumber);
Console.WriteLine(number);
Console.ReadKey();



