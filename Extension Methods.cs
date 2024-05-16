DateTime dt = DateTime.Now;
Console.WriteLine($"DateTime.Now: {dt}"); // yyyy-MM-dd hh:mm:ss am/pm
dt = new DateTime(2021, 3, 1, 11, 30, 00);
Console.WriteLine($"DateTime: {dt}"); // yyyy-MM-dd hh:mm:ss am/pm
DateTimeOffset dts = DateTimeOffset.Now;
Console.WriteLine($"DateTimeOffset.Now: {dts}");
DateTimeOffset.UtcNow;
Console.WriteLine($"DateTimeOffset.UtcNow: {dts}");
Console.ReadKey();
//===========================================================================
//===========================================================================
//===========================================================================
DateTime dt = DateTime.Now;
Console.WriteLine($"DateTime.Now: {dt}"); // yyyy-MM-dd hh:mm:ss am/pm
TimeSpan ts = new TimeSpan(2, 15, 0);
dt = dt.Add(ts);
Console.WriteLine($"DateTime.Now: {dt}"); // yyyy-MM-dd hh:mm:ss am/pm
dt = dt.AddDays(4);
Console.WriteLine($"DateTime +4 Days: {dt}"); // yyyy-MM-dd hh:mm:ss.am/pm
Console.ReadKey();
//===========================================================================
//===========================================================================
//===========================================================================
DateTime dt = DateTime.Now;
Console.WriteLine($"DateTime.Now: {dt}");
dt = dt.AddDays(4);
//Console.WriteLine($"Is weekend: {dt.IsWeekEnd()}"); // dt.IsWeekEnd()
//Console.WriteLine($"Is weekday: {dt.IsWeekDay()}");// dt.IsWeekEnd() 
Console.WriteLine($"Is weekend: {DateTimeExtensions.IsWeekEnd(dt)}");
Console.WriteLine($"Is weekday: {DateTimeExtensions.IsWeekDay(dt)}");
Console.ReadKey();
public static class DateTimeExtensions
{
    public static bool IsWeekEnd(this DateTime value)
    {
        return value.DayOfWeek == DayOfWeek.Saturday || value.DayOfWeek == DayOfWeek.Sunday;
    }

    public static bool IsWeekDay(this DateTime value)
    {
        return !IsWeekEnd(value);
    }
}
//===========================================================================
//===========================================================================
//===========================================================================
DateTime dt = DateTime.Now;
Console.WriteLine($"DateTime.Now: {dt}");
dt = dt.AddDays(4);
Console.WriteLine($"Is weekend: {DateTimeHelper.IsWeekEnd(dt)}");
Console.WriteLine($"Is weekday: {DateTimeHelper.IsWeekDay(dt)}");
Console.ReadKey();

public static class DateTimeHelper
{
    public static bool IsWeekEnd(DateTime value)
    {
        return value.DayOfWeek == DayOfWeek.Saturday || value.DayOfWeek == DayOfWeek.Sunday;
    }

    public static bool IsWeekDay(DateTime value)
    {
        return !IsWeekEnd(value);
    }
}
//===========================================================================
//===========================================================================
//===========================================================================

Pizza p = new Pizza();

//p = PizzaExtensions.AddDough(PizzaExtensions.AddSauce(PizzaExtensions.AddCheeze(PizzaExtensions.AddToppings(p, "black olives", 3.5m), true)), "thin");

p.AddDough("thin")
  .AddSauce()
  .AddCheeze(true)
  .AddToppings("black olives", 3.5m);

Console.WriteLine(p);
Console.ReadKey();



static class PizzaExtensions
{
    public static Pizza AddDough(this Pizza value, string type)
    {
        value.Content += $"\n{type} Dough X $4.00";
        value.TotalPrice += 4m;
        return value;
    }
    public static Pizza AddSauce(this Pizza value)
    {
        value.Content += $"\nTomato Sauce X $2.00";
        value.TotalPrice += 2m;
        return value;
    }
    public static Pizza AddCheeze(this Pizza value, bool extra)
    {
        value.Content += $"\n{(extra ? "extra" : "regular")} Cheeze Sauce X ${(extra ? "6.00" : "4.00")}";
        value.TotalPrice += extra ? 6m : 4m;
        return value;
    }
    public static Pizza AddToppings(this Pizza value, string type, decimal price)
    {
        value.Content += $"\n{type} X ${price.ToString("#.##")}";
        value.TotalPrice += price;
        return value;
    }
}
class Pizza
{
    public string Content { get; set; }
    public decimal TotalPrice { get; set; }

    public Pizza AddSauce()
    {
        this.Content += $"\nTOMATO SAUCE X $2.00";
        this.TotalPrice += 2m;
        return this;
    }
    public override string ToString()
    {
        return $"{Content}\n-----------------------\nTotal Price: ${TotalPrice.ToString("#.##")}";
    }
}

