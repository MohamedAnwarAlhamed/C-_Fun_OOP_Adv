/*
- WHAT IS ENUMERATION
- WHY ENUMERATION
- SIMPLE ENUM
- FLAGS ENUM
- PARSE ENUM
- LOOP ON ENUM
*/
var day = (DAY.SATURDAY | DAY.SUNDAY);
if (day.HasFlag(DAY.WEEKEND))
{
    Console.WriteLine("enjoy your weekend");
}
Console.ReadKey();


[Flags]
enum DAY
{
    NONE = 0b_0000_0000, // 0
    MONDAY = 0b_0000_0001, // 1
    TUESDAY = 0b_0000_0010, // 2
    WEDNESDAY = 0b_0000_0100, // 4,
    THURSDAY = 0b_0000_1000, // 8,
    FRIDAY = 0b_0001_0000, // 16,
    SATURDAY = 0b_0010_0000, // 32,
    SUNDAY = 0b_0100_0000, // 64,
    BUSDAY = MONDAY TUESDAY | WEDNESDAY | THURSDAY | FRIDAY,
    WEEKEND = SATURDAY | SUNDAY // 06_0110_0000

}
//===========================================================================
//===========================================================================
//===========================================================================

var day = 2;
// var day = "FEB";
//     Console.WriteLine(Enum.Parse(typeof(Month), day));
if (Enum.IsDefined(typeof(Month), day))
{
    Console.WriteLine((Month)day);
    // Console.WriteLine(Enum.Parse(typeof(Month), day));
}
// if (Enum.TryParse(day, out Month month))
// {
//     Console.WriteLine(month);
//     Console.WriteLine(Enum.Parse(typeof(Month), day));
// }
else
{
    Console.WriteLine("invalid entry");
}
//============
foreach (var month in Enum.GetNames(typeof(Month)))
{
    Console.WriteLine($"{month} = {(int)Enum.Parse(typeof(Month), month)}");
}

foreach (var month in Enum.GetValues(typeof(Month)))
{
    Console.WriteLine($"{month.ToString()} = {(int)month}");
}

Console.WriteLine(Month.JAN);
Console.ReadKey();

enum Month
{
    JAN = 1,
    FEB,
    MAR,
    APR,
    MAY,
    JUN,
    JUL,
    AUG,
    SEP,
    OCT,
    NOV,
    DEC
}