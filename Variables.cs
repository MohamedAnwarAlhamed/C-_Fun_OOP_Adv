/*
- DECLARATION
- INITIALIZATION
- ASSIGNMENT
- INTEGER VALUE TYPE
- STRING REFERENCE TYPE
- STACK VS HEAP
- STRING CONCATENATION
*/
Console.WriteLine($"sbyte: [{sbyte.MinValue} {sbyte.MaxValue}]"); // [-128-127]
Console.WriteLine($"int: [{byte.MinValue} {byte.MaxValue}]"); // [0 - 255]
Console.WriteLine($"int: [{short.MinValue} {short.MaxValue}]"); // [-32,768 32,767]
Console.WriteLine($"ushort: [{ushort.MinValue} {ushort.MaxValue}]"); // [865,535]
Console.WriteLine($"int: [{int.MinValue} {int.MaxValue}]"); // [-2,147,483,648 2,147,483,647]
Console.WriteLine($"uint: [{uint.MinValue} {uint.MaxValue}]"); // [8 4,294,967,295]
Console.WriteLine($"long: [{long.MinValue} {long.MaxValue}]"); // [-9,223,372,036,854,775,808 9,223,372,036,854,775,887] 
Console.WriteLine($"ulong: [{ulong.MinValue} {ulong.MaxValue}]"); // [0 18,446,744,073,789,551,615]
Console.WriteLine($"float: [{float.MinValue} {float.MaxValue}]"); // [±1.5 x 10-45 ±3.4 x 1038]
Console.WriteLine($"double: [{double.MinValue} {double.MaxValue}]"); // [±5.0 x 10-324 ±1.7 × 10388]
Console.WriteLine($"decimal: [{decimal.MinValue} {decimal.MaxValue}]"); // [±1.8 x 10-28 17.9228 x 1028]


// var
var s1 = "Issam";
var f = 0f;
var d = 0d;
var m = 0m;
var u = 0u;
var l = 0l;
var ul = 0ul;
int oneMillion = 1_000_000;
var result = 200 / 3.0;

// dynamic
dynamic x = 9;
x = "abc";
x = 10m;




